# TerminFiks · Business rules and flows (v1)

This file is the rulebook for building v1. If the code and this file disagree, this file wins until we change it on purpose.

---

## Users and roles

| Role | Who | Can | Cannot |
|---|---|---|---|
| **Owner** (*Pronari*) | The person who runs and pays for the shop | Create the shop · edit services, prices, opening hours · add and remove barbers · see all bookings · block or unblock customers · pay the subscription | See other shops · send marketing messages to customers |
| **Barber** (*Berberi*) | Someone cutting in the shop (the owner can be a barber too) | Log in with their phone number · see their own calendar · add walk-ins and phone bookings · block time (break, day off) · mark "came" / "didn't come" · cancel or move their own bookings | Change services or prices · see the subscription · edit other barbers' calendars |
| **Customer** (*Klienti*) | Anyone with the shop's link | Book · cancel before the deadline · get a WhatsApp reminder | Have an account or password · see other customers · book online while blocked |
| **Admin** (TerminFiks, me) | The TerminFiks team | Approve new shops · help with support · manage billing · pause a shop | Look at a shop's bookings except to solve a support request from that shop |

---

## Flow 1: A shop signs up and goes live (owner)

1. The owner opens **terminfiks.com** and taps **"Hap dyqanin"** (*Open your shop*).
2. They enter their first name and WhatsApp number, get a 6-digit code on WhatsApp and type it in.
3. Shop details: shop name, city, address, and optionally an Instagram handle and a photo.
4. Services: name, duration (15/20/30/45/60 min) and price. Suggestions are pre-filled: *Qethje 20 min €5 · Qethje + mjekër 30 min €7 · Mjekër 10 min €2*.
5. Opening hours for each day, plus breaks.
6. Team: "I work alone", or add barbers by name + WhatsApp number. Each one gets a WhatsApp invite.
7. Rules: minimum notice (default 30 min) and cancellation deadline (default 2 h).
8. The owner sees their booking page and makes a test booking.
9. The owner taps **"Dërgo"** (*Send*). The status becomes *Waiting for approval*.
10. The admin approves within 24 h. The owner gets a WhatsApp message with their link (**terminfiks.com/emri-i-dyqanit**) and a QR code to print or post. The 30 free days start now.

## Flow 2: A customer books

1. The customer taps the shop's link (Instagram bio, WhatsApp status, or the QR code on the mirror).
2. They see the shop: name, photo, services with duration and price.
3. They pick a service.
4. They pick a barber, or **"Kushdo"** (*anyone free*).
5. They pick a day (the next 14 days are shown) and a free time. Only free times are shown.
6. They type their first name and WhatsApp number. The country code is pre-filled from the shop's country.
7. They tap **"Rezervo"**. The system checks rules R1, R2, R6 and R7. If the time was just taken, it suggests the nearest free time.
8. The success screen shows *"U bë! E premte, 17:00 te Arbeni."*, an **Add to calendar** button and a **Cancel** link. No WhatsApp message is sent now, except under rule R4.
9. The booking appears in the barber's calendar straight away.

## Flow 3: Reminder, cancel and no-show

1. **3 hours before** the appointment (see rule R4 for the exceptions), the customer gets one WhatsApp reminder with two buttons: **"Po, vij"** (*Yes, I'm coming*) and **"Anuloj"** (*Cancel*).
2. If they tap **"Po, vij"**, the status becomes *Confirmed*. Nothing more is sent.
3. If they tap **"Anuloj"**, the status becomes *Cancelled* and the time is free again. The barber sees it at once. The customer gets one reply with a link to book again.
4. If there's no answer, the status stays *Booked – no answer* and the booking is **not** cancelled (rule R5).
5. If the customer tries to cancel with the link after the deadline, the page says *"It's too late to cancel online, call the shop"* and shows the shop's number.
6. After the start time, the barber marks **"Erdhi"** (*Came*), or from 15 minutes after the start, **"Nuk erdhi"** (*Didn't come*).
7. On a second no-show (rule R6), that number is blocked from online booking at that shop for 30 days. The booking page tells them *"Për termin, thirr dyqanin"* (*To book, call the shop*). The owner can unblock at any time.

---

## Business rules

| # | Rule |
|---|---|
| **R1** | A customer can book **at least 30 minutes ahead** and **at most 14 days ahead**. The owner can change this to 0–120 minutes and 7–60 days. |
| **R2** | One time slot belongs to one customer per barber. **No double bookings.** While a customer fills in the form, the slot is held for 5 minutes. |
| **R3** | Cancelling is **free until 2 hours before** the appointment (the owner can set 1–24 h). After that, only by phone with the shop. |
| **R4** | **Every booking gets exactly one WhatsApp reminder, 3 hours before.** If the booking is made less than 3 hours ahead, the reminder goes out right away as the confirmation. If the 3-hour point falls between 21:00 and 08:00, the reminder goes out at 20:00 the evening before. **We never send more than 2 messages per booking**: the reminder, plus one reply if they cancel. Messages cost money. |
| **R5** | **No answer is not a cancellation.** A booking is only cancelled by the customer, the barber or the owner, never automatically. |
| **R6** | "Didn't come" can only be marked from 15 minutes after the start time. **2 no-shows within 90 days at the same shop → 30 days without online booking at that shop.** The owner can lift this at any time. |
| **R7** | One phone number can have at most **2 upcoming bookings per shop**. |
| **R8** | Customers have **no account and no password.** Their WhatsApp number identifies them. Their name is at most 40 characters. |
| **R9** | If a barber cancels or moves a booking, the customer gets a WhatsApp message right away with a link to choose a new time. |
| **R10** | Prices on the booking page are information only. **Customers pay in the shop**, cash or card, like today. TerminFiks never takes money from customers in v1. |
| **R11** | **Subscription:** 30 days free from the day the shop is approved, then €12/month per shop including up to 400 reminders. Above 400, it's €3 per 100 more, and the owner gets a warning at 80%. If a payment is 7 days late, the booking page is paused: no new bookings, but existing bookings and their reminders still happen. If a shop stays unpaid for 90 days, its data is deleted. |
| **R12** | A new shop is only visible after the admin approves it, within 24 hours. This keeps out fake shops. |
| **R13** | Customer data belongs to the shop. We only send booking messages, **never marketing**. A customer can ask to have their number deleted, and it's deleted within 30 days. |
| **R14** | All times are in the shop's local time zone: Europe/Belgrade for Kosovo, Europe/Skopje for North Macedonia, Europe/Zurich for Switzerland. |
| **R15** | "Kushdo" (*anyone*) gives the time to the first free barber, in the order the owner set. |

---

## WhatsApp messages (templates to submit to Meta)

| Template | Type | Albanian | English |
|---|---|---|---|
| `reminder` | Utility, buttons: **Po, vij** / **Anuloj** | "Përshëndetje {emri}! {Sot/Nesër} në {ora} te {berberi}, {dyqani}. Vjen?" | "Hi {name}! {Today/Tomorrow} at {time} with {barber}, {shop}. Coming?" |
| `cancelled_by_customer` | Reply inside the open conversation | "U anulua. Kur të duash, rezervo prapë: {link}" | "Cancelled. Book again whenever you like: {link}" |
| `cancelled_by_shop` | Utility | "{dyqani}: termini yt në {ora} u anulua. Zgjidh një orë tjetër: {link}" | "{shop}: your appointment at {time} was cancelled. Pick another time: {link}" |
| `login_code` | Authentication (for owners and barbers) | Meta's fixed verification-code text in Albanian; Meta doesn't allow custom wording for this type | "{code} is your verification code." |

---

## What v1 will NOT do

- **No online payments or deposits.** Customers pay in the shop. Deposits for no-show-heavy shops come in v2.
- **No customer app.** Booking happens in the browser, and the barber's side is a mobile web app, not an App Store app.
- **No marketplace.** No search across shops; every shop shares its own link.
- **No Viber, SMS or email reminders.** WhatsApp only.
- **No Macedonian or English booking page.** Albanian only in v1; Macedonian comes in v2.
- **No chatbot and no AI.** We don't answer free-text WhatsApp messages.
- **No reviews, loyalty points, gift cards or product sales.**
- **No payroll, commissions or accounting** for the team.
- **No chains.** One location per shop, at most 6 barbers.
