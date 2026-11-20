# TerminFiks: instructions for Claude Code

TerminFiks is a booking link + WhatsApp reminders for barbershops in Kosovo and North Macedonia. Before writing any code, read these files and follow them:

1. `docs/business.md`: who the customer is, what we sell, price, costs.
2. `docs/rules-and-flows.md`: roles, flows and **business rules R1–R15**. Implement the rules exactly. If a rule is unclear or seems wrong, ask; don't guess.
3. `docs/brand-book.md`: colours, fonts, logo files and tone of voice.

## Non-negotiables

- **UI language:** Albanian first (informal "ti", short sentences, time first). English only in code, comments and docs.
- **Brand:** Ink `#14161C`, Foam `#F6F1E8`, Fiks Orange `#F2541B`. Headings in Unbounded, text in Inter. Buttons are orange with Ink text. No small orange text on Foam. Use the logo files in `docs/brand/`; don't redraw them.
- **Cost rule:** at most 2 WhatsApp messages per booking (rule R4). Every new message type must be checked against this rule and the price (400 reminders per shop per month).
- **Customers have no accounts** (rule R8). Don't add sign-up for customers.
- **Out of scope for v1:** everything listed under "What v1 will NOT do" in `docs/rules-and-flows.md`. Don't build it, even if it seems easy.
- **Mobile first:** barbers use the app on their phone between haircuts. Every main action takes at most 2 taps.
