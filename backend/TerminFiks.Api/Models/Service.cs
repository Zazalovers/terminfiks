namespace TerminFiks.Api.Models;

/// <summary>Something the shop offers, e.g. "Qethje" 20 min €5.</summary>
public class Service
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public Shop Shop { get; set; } = null!;

    public required string Name { get; set; }
    public int DurationMinutes { get; set; }

    /// <summary>Price in euro cents. Information only; customers pay in the shop (R10).</summary>
    public int PriceCents { get; set; }

    public int SortOrder { get; set; }
    public bool IsActive { get; set; } = true;
}
