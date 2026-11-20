namespace TerminFiks.Api.Models;

/// <summary>One appointment with one barber for one service.</summary>
public class Booking
{
    public int Id { get; set; }

    public int ShopId { get; set; }
    public Shop Shop { get; set; } = null!;

    public int StaffMemberId { get; set; }
    public StaffMember StaffMember { get; set; } = null!;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;

    /// <summary>Null for a walk-in without a phone number.</summary>
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    /// <summary>Name for walk-ins without a customer record.</summary>
    public string? WalkInName { get; set; }

    /// <summary>UTC. Unique per barber while not cancelled (R2, enforced by an index).</summary>
    public DateTime StartsAt { get; set; }

    /// <summary>UTC.</summary>
    public DateTime EndsAt { get; set; }

    /// <summary>Copied from the service when booked, so later price changes don't rewrite history.</summary>
    public int DurationMinutes { get; set; }
    public int PriceCents { get; set; }

    public BookingStatus Status { get; set; } = BookingStatus.Booked;
    public BookingSource Source { get; set; } = BookingSource.Online;

    public CancelledBy? CancelledBy { get; set; }
    public DateTime? CancelledAt { get; set; }

    /// <summary>Random secret in the customer's cancel link. Unique.</summary>
    public required string ManageToken { get; set; }

    /// <summary>R4: when the single reminder goes out (3 h before, now, or 20:00 the evening before).</summary>
    public DateTime? ReminderDueAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<WhatsAppMessage> Messages { get; set; } = [];
}
