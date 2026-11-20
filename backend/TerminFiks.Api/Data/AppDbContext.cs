using Microsoft.EntityFrameworkCore;
using TerminFiks.Api.Models;

namespace TerminFiks.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Shop> Shops => Set<Shop>();
    public DbSet<StaffMember> StaffMembers => Set<StaffMember>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<OpeningHours> OpeningHours => Set<OpeningHours>();
    public DbSet<TimeBlock> TimeBlocks => Set<TimeBlock>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<SlotHold> SlotHolds => Set<SlotHold>();
    public DbSet<WhatsAppMessage> WhatsAppMessages => Set<WhatsAppMessage>();
    public DbSet<LoginCode> LoginCodes => Set<LoginCode>();
    public DbSet<Payment> Payments => Set<Payment>();

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        // Store every enum as text so the SQLite file is readable.
        builder.Properties<Enum>().HaveConversion<string>().HaveMaxLength(30);
    }

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Shop>(e =>
        {
            e.HasIndex(x => x.Slug).IsUnique();
            e.Property(x => x.Slug).HasMaxLength(60);
            e.Property(x => x.Name).HasMaxLength(80);
            e.Property(x => x.City).HasMaxLength(60);
            e.Property(x => x.Address).HasMaxLength(160);
            e.Property(x => x.CountryCode).HasMaxLength(2);
            e.Property(x => x.TimeZone).HasMaxLength(40);
            e.Property(x => x.Phone).HasMaxLength(16);
            e.Property(x => x.InstagramHandle).HasMaxLength(30);
            e.Property(x => x.PhotoKey).HasMaxLength(200);
        });

        b.Entity<StaffMember>(e =>
        {
            e.HasIndex(x => new { x.ShopId, x.Phone }).IsUnique();
            e.Property(x => x.FirstName).HasMaxLength(40);
            e.Property(x => x.Phone).HasMaxLength(16);
            e.HasOne(x => x.Shop).WithMany(s => s.Staff).HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<Service>(e =>
        {
            e.Property(x => x.Name).HasMaxLength(60);
            e.HasOne(x => x.Shop).WithMany(s => s.Services).HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<OpeningHours>(e =>
        {
            e.HasIndex(x => new { x.ShopId, x.DayOfWeek });
            e.HasOne(x => x.Shop).WithMany(s => s.OpeningHours).HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<TimeBlock>(e =>
        {
            e.HasIndex(x => new { x.StaffMemberId, x.StartsAt });
            e.Property(x => x.Reason).HasMaxLength(80);
            e.HasOne(x => x.StaffMember).WithMany(s => s.TimeBlocks).HasForeignKey(x => x.StaffMemberId).OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<Customer>(e =>
        {
            e.HasIndex(x => new { x.ShopId, x.Phone }).IsUnique();
            e.Property(x => x.Phone).HasMaxLength(16);
            e.Property(x => x.FirstName).HasMaxLength(40); // R8
            e.HasOne(x => x.Shop).WithMany(s => s.Customers).HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<Booking>(e =>
        {
            // R2: one customer per barber per start time. Cancelled bookings free the slot.
            e.HasIndex(x => new { x.StaffMemberId, x.StartsAt })
                .IsUnique()
                .HasFilter("\"Status\" <> 'Cancelled'");
            e.HasIndex(x => x.ManageToken).IsUnique();
            e.HasIndex(x => new { x.ShopId, x.StartsAt });
            e.HasIndex(x => x.ReminderDueAt);
            e.Property(x => x.ManageToken).HasMaxLength(64);
            e.Property(x => x.WalkInName).HasMaxLength(40);

            e.HasOne(x => x.Shop).WithMany(s => s.Bookings).HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.StaffMember).WithMany(s => s.Bookings).HasForeignKey(x => x.StaffMemberId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.Service).WithMany().HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Restrict);
            // R13: deleting a customer keeps the booking history without the person.
            e.HasOne(x => x.Customer).WithMany(c => c.Bookings).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.SetNull);
        });

        b.Entity<SlotHold>(e =>
        {
            e.HasIndex(x => new { x.StaffMemberId, x.StartsAt });
            e.HasIndex(x => x.ExpiresAt);
            e.HasOne(x => x.StaffMember).WithMany().HasForeignKey(x => x.StaffMemberId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Service).WithMany().HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<WhatsAppMessage>(e =>
        {
            e.HasIndex(x => x.BookingId);
            e.HasIndex(x => new { x.ShopId, x.ScheduledFor });
            e.HasIndex(x => new { x.Status, x.ScheduledFor });
            e.Property(x => x.ToPhone).HasMaxLength(16);
            e.Property(x => x.ProviderMessageId).HasMaxLength(100);
            e.HasOne(x => x.Booking).WithMany(bk => bk.Messages).HasForeignKey(x => x.BookingId).OnDelete(DeleteBehavior.SetNull);
            e.HasOne(x => x.Shop).WithMany().HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<LoginCode>(e =>
        {
            e.HasIndex(x => new { x.Phone, x.CreatedAt });
            e.Property(x => x.Phone).HasMaxLength(16);
            e.Property(x => x.CodeHash).HasMaxLength(128);
        });

        b.Entity<Payment>(e =>
        {
            e.Property(x => x.Note).HasMaxLength(200);
            e.HasOne(x => x.Shop).WithMany(s => s.Payments).HasForeignKey(x => x.ShopId).OnDelete(DeleteBehavior.Cascade);
        });
    }
}
