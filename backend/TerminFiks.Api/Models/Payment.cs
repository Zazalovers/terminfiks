namespace TerminFiks.Api.Models;

/// <summary>A subscription payment (R11). v1 collects by bank transfer and the admin records it.</summary>
public class Payment
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public Shop Shop { get; set; } = null!;

    public DateOnly PeriodStart { get; set; }
    public DateOnly PeriodEnd { get; set; }

    /// <summary>Euro cents, e.g. 1200 for €12, plus extra reminder packs.</summary>
    public int AmountCents { get; set; }

    public DateTime PaidAt { get; set; }
    public string? Note { get; set; }
}
