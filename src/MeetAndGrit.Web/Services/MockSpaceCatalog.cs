using MeetAndGrit.Web.Models;

namespace MeetAndGrit.Web.Services;

/// <summary>
/// Placeholder zones and prices. Replace with the real ones after the client interview.
/// </summary>
public class MockSpaceCatalog : ISpaceCatalog
{
    private static readonly IReadOnlyList<SpaceZone> Zones =
    [
        new(MockSeatAvailabilityService.WindowBar, 8, "Solo work, quick sessions",
            "High stools facing the street. Bright, a little lively, and close to the counter for refills.",
            ["Outlet at every stool", "Natural light"]),
        new(MockSeatAvailabilityService.LongTables, 16, "Studying, group projects",
            "Two long oak tables under warm track lights. The main room, where most people settle in.",
            ["Outlets along the table", "Ergonomic chairs", "Aircon"]),
        new(MockSeatAvailabilityService.MeetingRoom, 4, "Meetings, calls, thesis defenses",
            "A glass-walled room with a door that closes. Book it by the hour for your team.",
            ["Closed door", "Whiteboard", "TV screen for presenting"]),
        new(MockSeatAvailabilityService.ReadingNook, 4, "Reading, unwinding",
            "Armchairs next to the bookshelf. The cats' favorite corner, so expect company.",
            ["Community bookshelf", "Armchairs", "Cat visits likely"]),
    ];

    private static readonly IReadOnlyList<Rate> Rates =
    [
        new("Hourly", 60m, "per hour", "Drop in for a quick session.",
            ["Any open seat", "Wi-Fi and outlets"]),
        new("Day pass", 300m, "per day", "Stay from opening to closing.",
            ["Any open seat", "Wi-Fi and outlets", "Come and go all day"]),
        new("Meeting room", 250m, "per hour", "Up to 4 people, door closed.",
            ["Whiteboard and TV", "Reserve ahead"]),
        new("Monthly pass", 3500m, "per month", "For regulars who basically live here.",
            ["Unlimited day access", "Priority reservations", "Loyalty stamps on every visit"],
            IsMembership: true),
    ];

    public Task<IReadOnlyList<SpaceZone>> GetZonesAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(Zones);

    public Task<IReadOnlyList<Rate>> GetRatesAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(Rates);
}
