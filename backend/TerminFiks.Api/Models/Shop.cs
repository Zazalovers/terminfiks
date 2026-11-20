namespace TerminFiks.Api.Models;

/// <summary>One barbershop, one location (no chains in v1).</summary>
public class Shop
{
    public int Id { get; set; }

    /// <summary>Public link: terminfiks.com/{Slug}. Unique.</summary>
    public required string Slug { get; set; }
    public required string Name { get; set; }
    public required string City { get; set; }
    public required string Address { get; set; }

    /// <summary>ISO code: XK (Kosovo), MK (North Macedonia), CH (Switzerland). Pre-fills the customer's phone prefix.</summary>
    public required string CountryCode { get; set; }

    /// <summary>IANA time zone, e.g. Europe/Belgrade (R14). All times are shown in this zone.</summary>
    public required string TimeZone { get; set; }

    /// <summary>Shop phone in E.164, shown when it's too late to cancel online.</summary>
    public required string Phone { get; set; }

    public string? InstagramHandle { get; set; }

    /// <summary>Object key of the shop photo in S3 (media is not stored in SQLite).</summary>
    public string? PhotoKey { get; set; }

    public ShopStatus Status { get; set; } = ShopStatus.Draft;

    /// <summary>R1: minimum notice, 0–120 minutes. Default 30.</summary>
    public int MinNoticeMinutes { get; set; } = 30;

    /// <summary>R1: how far ahead customers can book, 7–60 days. Default 14.</summary>
    public int MaxDaysAhead { get; set; } = 14;

    /// <summary>R3: free cancellation until this many hours before, 1–24. Default 2.</summary>
    public int CancelDeadlineHours { get; set; } = 2;

    /// <summary>R12: set when the admin approves the shop.</summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>R11: ApprovedAt + 30 days.</summary>
    public DateTime? TrialEndsAt { get; set; }

    /// <summary>R11: subscription is paid until this date (manual bank transfer in v1).</summary>
    public DateTime? PaidUntil { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<StaffMember> Staff { get; set; } = [];
    public List<Service> Services { get; set; } = [];
    public List<OpeningHours> OpeningHours { get; set; } = [];
    public List<Customer> Customers { get; set; } = [];
    public List<Booking> Bookings { get; set; } = [];
    public List<Payment> Payments { get; set; } = [];
}
