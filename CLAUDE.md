# TerminFiks: instructions for Claude Code

TerminFiks is a booking link + WhatsApp reminders for barbershops in Kosovo and North Macedonia.

**Read `docs/` before you change anything.** In particular:

1. `docs/business.md`: who the customer is, what we sell, price, costs.
2. `docs/rules-and-flows.md`: roles, flows and **business rules R1–R15**. Implement the rules exactly. If a rule is unclear or seems wrong, ask; don't guess.
3. `docs/brand-book.md`: colours, fonts, logo files and tone of voice.
4. `docs/stack.md` and `docs/data-model.md`: the stack and the tables. Update both when you change them.

## Stack

- **Front end:** Vite + React + TypeScript in `frontend/`.
- **Back end:** ASP.NET Core minimal API on .NET 10 in `backend/TerminFiks.Api/`.
- **Database:** SQLite through EF Core 10. File: `backend/TerminFiks.Api/terminfiks.db` (git-ignored). Migrations run on start.
- **Media:** S3 later; the database only stores the object key.

## Folder layout

```
package.json              root scripts (install + run both sides)
frontend/                 Vite app; src/App.tsx = landing page, src/index.css = brand tokens
backend/
  TerminFiks.slnx
  dotnet-tools.json       local dotnet-ef tool
  TerminFiks.Api/
    Program.cs            startup, CORS, GET /health
    Data/AppDbContext.cs  tables, indexes, relations
    Models/               one class per table + Enums.cs
    Migrations/           EF Core migrations
docs/                     business, rules, brand, stack, data model
```

## Commands

```
npm install                     # front end packages + dotnet tools + NuGet restore
npm run dev                     # API on http://localhost:5080, web on http://localhost:5173
npm run build                   # build both
npm run migration:add -- Name   # new EF Core migration after changing Models/
```

## Non-negotiables

- **UI language:** Albanian first (informal "ti", short sentences, time first). English only in code, comments and docs.
- **Brand:** Ink `#14161C`, Foam `#F6F1E8`, Fiks Orange `#F2541B`. Headings in Unbounded, text in Inter. Buttons are orange with Ink text. No small orange text on Foam. Use the logo files in `docs/brand/`; don't redraw them.
- **Cost rule:** at most 2 WhatsApp messages per booking (rule R4). Every new message type must be checked against this rule and the price (400 reminders per shop per month).
- **Customers have no accounts** (rule R8). Don't add sign-up for customers.
- **Out of scope for v1:** everything listed under "What v1 will NOT do" in `docs/rules-and-flows.md`. Don't build it, even if it seems easy.
- **Mobile first:** barbers use the app on their phone between haircuts. Every main action takes at most 2 taps.
- **Data:** times in UTC, shown in the shop's time zone (R14). Money in integer cents. Never commit the `.db` file.
