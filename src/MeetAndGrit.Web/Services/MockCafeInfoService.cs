using MeetAndGrit.Web.Models;

namespace MeetAndGrit.Web.Services;

/// <summary>
/// Placeholder hours and cats. Confirm the real details with the owners.
/// </summary>
public class MockCafeInfoService : ICafeInfoService
{
    private static readonly CafeInfo Info = new(
        Address: "Sambag, Urgello, Cebu City",
        MapUrl: "https://www.google.com/maps/search/?api=1&query=Meet+%26+Grit+Coworking+Cafe+Cebu",
        FacebookUrl: "https://www.facebook.com/search/top?q=Meet%20%26%20Grit%20Coworking%20Cafe",
        Hours:
        [
            new("Monday to Friday", new TimeOnly(9, 0), new TimeOnly(22, 0)),
            new("Saturday", new TimeOnly(10, 0), new TimeOnly(22, 0)),
            new("Sunday", new TimeOnly(10, 0), new TimeOnly(20, 0)),
        ],
        Cats:
        [
            new("Kape", "Naps on whichever armchair you wanted.", "Reading nook"),
            new("Mochi", "Walks across keyboards during deadlines.", "Long tables"),
            new("Tofu", "Greets everyone at the door, then ignores them.", "By the counter"),
        ]);

    public Task<CafeInfo> GetInfoAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(Info);
}
