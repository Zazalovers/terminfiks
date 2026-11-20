# TerminFiks · Stack

| Part | Choice | Why (one sentence) |
|---|---|---|
| **Front end** | Vite + React + TypeScript (`frontend/`) | Vite starts in under a second and builds a small, fast mobile web app, which is what barbers use between haircuts. |
| **Back end** | ASP.NET Core minimal API on .NET 10 (`backend/TerminFiks.Api/`) | A fast, typed, long-term-supported back end that I know well, with built-in background services for the reminder sender later. |
| **Database** | SQLite through Entity Framework Core 10 | One file in the project and no server to install, and EF Core migrations let me move to Postgres later without rewriting the models. |
| **Media** (shop photos, later) | S3-compatible object storage | Photos don't belong in the database; SQLite only stores the object key (`Shop.PhotoKey`). |
| **Dev runner** | npm scripts + `concurrently` (root `package.json`) | One `npm run dev` starts both sides, so a classmate needs three commands. |

## Versions

- Node 24, npm 11
- .NET SDK 10, EF Core 10.0.15, `dotnet-ef` 10.0.15 (local tool in `backend/dotnet-tools.json`)
- React 19, Vite 8, TypeScript 7

## Ports (development)

| What | URL |
|---|---|
| Landing page | http://localhost:5173 |
| API | http://localhost:5080 (health check: `/health`) |
| Database file | `backend/TerminFiks.Api/terminfiks.db` (git-ignored, created on first start) |

## Note on hosting

`docs/business.md` assumes Cloudflare Workers + Neon Postgres for cost. With a .NET back end that changes: .NET doesn't run on Workers. To decide before launch: a small container host for the API (and Postgres or a hosted SQLite), and Cloudflare Pages for the front end.
