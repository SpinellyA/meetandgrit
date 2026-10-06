using MeetAndGrit.Web.Models;
using MeetAndGrit.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MeetAndGrit.Web.Components;

public partial class AnnouncementList
{
    [Inject]
    private IAnnouncementService AnnouncementService { get; set; } = default!;

    /// <summary>Show only the newest few. Leave null to show all.</summary>
    [Parameter]
    public int? MaxItems { get; set; }

    private IReadOnlyList<Announcement> Announcements { get; set; } = [];

    protected override async Task OnParametersSetAsync()
    {
        var latest = await AnnouncementService.GetLatestAsync();
        Announcements = MaxItems is int max ? latest.Take(max).ToList() : latest;
    }

    private static string KindLabel(AnnouncementKind kind) => kind switch
    {
        AnnouncementKind.FullyBooked => "Fully booked",
        AnnouncementKind.ScheduleChange => "Schedule change",
        _ => "News",
    };

    private static string KindClass(AnnouncementKind kind) => kind switch
    {
        AnnouncementKind.FullyBooked => "booked",
        AnnouncementKind.ScheduleChange => "schedule",
        _ => "news",
    };
}
