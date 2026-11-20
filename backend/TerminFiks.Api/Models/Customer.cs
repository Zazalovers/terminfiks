namespace TerminFiks.Api.Models;

/// <summary>
/// A customer of one shop. No account, no password (R8): the WhatsApp number identifies them.
/// Stored per shop because customer data belongs to the shop (R13).
/// </summary>
public class Customer
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public Shop Shop { get; set; } = null!;

    /// <summary>WhatsApp number in E.164. Unique per shop.</summary>
    public required string Phone { get; set; }

    /// <summary>At most 40 characters (R8).</summary>
    public required string FirstName { get; set; }

    /// <summary>R6: no online booking at this shop until this time. Owner can clear it.</summary>
    public DateTime? BlockedUntil { get; set; }

    /// <summary>R13: customer asked to delete their number; must be deleted within 30 days.</summary>
    public DateTime? DeletionRequestedAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<Booking> Bookings { get; set; } = [];
}
