namespace TerminFiks.Api.Models;

/// <summary>Time a barber is not bookable: a break, a day off.</summary>
public class TimeBlock
{
    public int Id { get; set; }
    public int StaffMemberId { get; set; }
    public StaffMember StaffMember { get; set; } = null!;

    /// <summary>UTC.</summary>
    public DateTime StartsAt { get; set; }

    /// <summary>UTC.</summary>
    public DateTime EndsAt { get; set; }

    public string? Reason { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
