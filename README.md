# Meet & Grit — Cafe + Coworking

Frontend prototype for Meet & Grit's reservation and coworking system (CMSC 128, team Acrylik).
Built with Blazor WebAssembly. There's no backend yet; every page reads sample data from the mock services in `src/MeetAndGrit.Web/Services`.

## Run it locally

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
dotnet run --project src/MeetAndGrit.Web
```

Then open http://localhost:5103.

## Run the tests

```bash
dotnet test
```

## Project layout

```
src/MeetAndGrit.Web
  Pages/        One page per route (Home, SpaceAndRates, Menu, Visit, stubs)
  Components/   Shared pieces: header, footer, seat board, rate card, announcements
  Models/       Records for seats, rates, menu items, announcements
  Services/     Interfaces + mock implementations (swap for API clients later)
  wwwroot/      index.html, global CSS (design tokens), images
tests/MeetAndGrit.Tests
  xUnit + bUnit tests for models, mock data, components, and pages
```

## Deployment

Every push to `main` runs `.github/workflows/deploy.yml`. It runs the tests, publishes the app, and deploys it to GitHub Pages.
The workflow sets Blazor's base path to the repository name automatically, so renaming the repo doesn't break anything.
