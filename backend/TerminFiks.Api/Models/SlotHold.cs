namespace TerminFiks.Api.Models;

/// <summary>R2: a time held for 5 minutes while a customer fills in the form.</summary>
public class SlotHold
{
    public int Id { get; set; }

    public int StaffMemberId { get; set; }
    public StaffMember StaffMember { get; set; } = null!;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;

    /// <summary>UTC.</summary>
    public DateTime StartsAt { get; set; }

    /// <summary>UTC.</summary>
    public DateTime EndsAt { get; set; }

    /// <summary>CreatedAt + 5 minutes. Expired holds are ignored.</summary>
    public DateTime ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
