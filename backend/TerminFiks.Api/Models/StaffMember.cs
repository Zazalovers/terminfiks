namespace TerminFiks.Api.Models;

/// <summary>The owner or a barber. Logs in with their WhatsApp number (no password).</summary>
public class StaffMember
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public Shop Shop { get; set; } = null!;

    public required string FirstName { get; set; }

    /// <summary>WhatsApp number in E.164. Unique per shop.</summary>
    public required string Phone { get; set; }

    public StaffRole Role { get; set; } = StaffRole.Barber;

    /// <summary>False for an owner who doesn't cut.</summary>
    public bool TakesBookings { get; set; } = true;

    /// <summary>R15: order used by "Kushdo" to pick the first free barber.</summary>
    public int SortOrder { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<TimeBlock> TimeBlocks { get; set; } = [];
    public List<Booking> Bookings { get; set; } = [];
}
