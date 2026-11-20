namespace TerminFiks.Api.Models;

// Enums are stored as text in SQLite (see AppDbContext) so the database stays readable.

/// <summary>Shop lifecycle (Flow 1, R11, R12).</summary>
public enum ShopStatus
{
    Draft,            // owner is still filling in the setup steps
    PendingApproval,  // owner tapped "Dërgo"; waiting for admin (R12)
    Active,           // approved and visible
    Paused            // payment 7 days late or paused by admin (R11)
}

public enum StaffRole
{
    Owner,
    Barber
}

/// <summary>Booking status (Flow 3). Never set to Cancelled automatically (R5).</summary>
public enum BookingStatus
{
    Booked,     // "Booked – no answer" until the customer taps a button
    Confirmed,  // customer tapped "Po, vij"
    Cancelled,
    Came,       // "Erdhi"
    NoShow      // "Nuk erdhi", only from 15 min after start (R6)
}

public enum BookingSource
{
    Online,  // customer booked through the shop link
    WalkIn,
    Phone
}

public enum CancelledBy
{
    Customer,
    Staff   // a barber or the owner (R9)
}

/// <summary>The WhatsApp templates in docs/rules-and-flows.md.</summary>
public enum MessageTemplate
{
    Reminder,
    CancelledByCustomer,
    CancelledByShop,
    LoginCode
}

public enum MessageStatus
{
    Scheduled,
    Sent,
    Delivered,
    Failed
}
