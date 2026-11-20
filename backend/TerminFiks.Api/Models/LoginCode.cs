namespace TerminFiks.Api.Models;

/// <summary>6-digit WhatsApp login code for owners and barbers (Flow 1, step 2).</summary>
public class LoginCode
{
    public int Id { get; set; }

    /// <summary>E.164.</summary>
    public required string Phone { get; set; }

    /// <summary>Hash of the code; the plain code is never stored.</summary>
    public required string CodeHash { get; set; }

    public DateTime ExpiresAt { get; set; }
    public DateTime? UsedAt { get; set; }
    public int Attempts { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
