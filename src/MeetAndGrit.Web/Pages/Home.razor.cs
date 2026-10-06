using MeetAndGrit.Web.Models;
using MeetAndGrit.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MeetAndGrit.Web.Pages;

public partial class Home
{
    private static readonly IReadOnlyList<(string Word, string Detail)> Uses =
    [
        ("Work", "Outlets at every seat, steady Wi-Fi, and aircon that keeps up with Cebu afternoons."),
        ("Study", "Long tables for group reviews, and quieter seats when you need to cram alone."),
        ("Read", "Borrow from the community bookshelf, or bring the one you can't put down."),
        ("Meet", "A glass meeting room with a door that closes, bookable by the hour."),
        ("Unwind", "Coffee, something from the pastry case, and maybe a cat on the next chair."),
    ];

    [Inject]
    private ISpaceCatalog SpaceCatalog { get; set; } = default!;

    [Inject]
    private ICafeInfoService CafeInfoService { get; set; } = default!;

    [Inject]
    private IAnnouncementService AnnouncementService { get; set; } = default!;

    private IReadOnlyList<Rate> Rates { get; set; } = [];

    private CafeInfo? Info { get; set; }

    private Announcement? FullyBookedNotice { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Rates = await SpaceCatalog.GetRatesAsync();
        Info = await CafeInfoService.GetInfoAsync();

        var announcements = await AnnouncementService.GetLatestAsync();
        FullyBookedNotice = announcements.FirstOrDefault(a => a.Kind == AnnouncementKind.FullyBooked);
    }
}
