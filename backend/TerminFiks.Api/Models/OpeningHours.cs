namespace TerminFiks.Api.Models;

/// <summary>
/// One open interval on a weekday, in the shop's local time (R14).
/// A day with a lunch break has two rows, e.g. 09:00–13:00 and 14:00–20:00.
/// </summary>
public class OpeningHours
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public Shop Shop { get; set; } = null!;

    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly OpensAt { get; set; }
    public TimeOnly ClosesAt { get; set; }
}
