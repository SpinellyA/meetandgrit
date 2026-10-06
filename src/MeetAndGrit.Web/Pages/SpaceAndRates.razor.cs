using MeetAndGrit.Web.Models;
using MeetAndGrit.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MeetAndGrit.Web.Pages;

public partial class SpaceAndRates
{
    private static readonly IReadOnlyList<(string Title, string Detail)> VisitSteps =
    [
        ("Pick a seat", "Check the floor plan and choose an open seat, or the meeting room."),
        ("Reserve it", "Choose your date and time. You'll get a confirmation and a reminder before you're due."),
        ("Check in", "Scan the QR code at the counter when you arrive. Your time starts then."),
        ("Stay or extend", "We'll let you know when your time is almost up. Ask the counter if you want more."),
    ];

    private static readonly IReadOnlyList<string> HouseRules =
    [
        "Reservations are held for 15 minutes past your start time.",
        "Cancel ahead if you can't make it, so someone else can take the seat.",
        "Calls go in the meeting room or outside, not at the long tables.",
        "Let the cats come to you. Please don't pick them up.",
        "Leave the seat the way you'd want to find it.",
    ];

    [Inject]
    private ISpaceCatalog SpaceCatalog { get; set; } = default!;

    private IReadOnlyList<SpaceZone> Zones { get; set; } = [];

    private IReadOnlyList<Rate> Rates { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        Zones = await SpaceCatalog.GetZonesAsync();
        Rates = await SpaceCatalog.GetRatesAsync();
    }
}
