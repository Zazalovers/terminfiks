namespace TerminFiks.Api.Models;

/// <summary>
/// Every WhatsApp message we send or plan to send. Used to enforce
/// "at most 2 messages per booking" (R4) and to count reminders per shop per month (R11).
/// </summary>
public class WhatsAppMessage
{
    public int Id { get; set; }

    /// <summary>Null for login codes.</summary>
    public int? BookingId { get; set; }
    public Booking? Booking { get; set; }

    /// <summary>Set for every message tied to a shop, so monthly counts don't need a join.</summary>
    public int? ShopId { get; set; }
    public Shop? Shop { get; set; }

    public MessageTemplate Template { get; set; }

    /// <summary>E.164.</summary>
    public required string ToPhone { get; set; }

    public MessageStatus Status { get; set; } = MessageStatus.Scheduled;

    /// <summary>UTC.</summary>
    public DateTime ScheduledFor { get; set; }
    public DateTime? SentAt { get; set; }

    /// <summary>Message id returned by the WhatsApp Cloud API.</summary>
    public string? ProviderMessageId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
