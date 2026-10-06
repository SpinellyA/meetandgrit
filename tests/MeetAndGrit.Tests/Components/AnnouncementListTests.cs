using Bunit;
using MeetAndGrit.Tests.Fakes;
using MeetAndGrit.Web.Components;
using MeetAndGrit.Web.Models;
using MeetAndGrit.Web.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MeetAndGrit.Tests.Components;

public class AnnouncementListTests : BunitContext
{
    private static readonly Announcement[] Announcements =
    [
        new("Fully booked Saturday", "Body", new DateOnly(2026, 10, 7), AnnouncementKind.FullyBooked),
        new("Late hours", "Body", new DateOnly(2026, 10, 5), AnnouncementKind.ScheduleChange),
        new("New books", "Body", new DateOnly(2026, 9, 28), AnnouncementKind.News),
    ];

    public AnnouncementListTests() =>
        Services.AddSingleton<IAnnouncementService>(new FakeAnnouncementService(Announcements));

    [Fact]
    public void ShowsEveryAnnouncement_ByDefault()
    {
        var list = Render<AnnouncementList>();

        Assert.Equal(3, list.FindAll("li.announcement").Count);
    }

    [Fact]
    public void ShowsOnlyTheNewest_WhenMaxItemsIsSet()
    {
        var list = Render<AnnouncementList>(parameters => parameters.Add(p => p.MaxItems, 2));

        var titles = list.FindAll("li.announcement h3").Select(h => h.TextContent).ToList();
        Assert.Equal(["Fully booked Saturday", "Late hours"], titles);
    }

    [Fact]
    public void HighlightsFullyBookedNotices()
    {
        var list = Render<AnnouncementList>();

        var tag = list.Find(".kind-booked");
        Assert.Equal("Fully booked", tag.TextContent);
    }
}
