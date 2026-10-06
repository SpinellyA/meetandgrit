using Bunit;
using MeetAndGrit.Tests.Fakes;
using MeetAndGrit.Web.Models;
using MeetAndGrit.Web.Pages;
using MeetAndGrit.Web.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MeetAndGrit.Tests.Pages;

public class HomeTests : BunitContext
{
    public HomeTests()
    {
        Services.AddSingleton<ISeatAvailabilityService, MockSeatAvailabilityService>();
        Services.AddSingleton<ISpaceCatalog, MockSpaceCatalog>();
        Services.AddSingleton<ICafeInfoService, MockCafeInfoService>();
    }

    [Fact]
    public void ShowsTheHeroAndAReserveButton()
    {
        UseAnnouncements();

        var home = Render<Home>();

        Assert.Equal("Pull up a chair.", home.Find("h1").TextContent.Trim());
        Assert.Contains(home.FindAll("a.btn"), a => a.GetAttribute("href") == "reserve");
    }

    [Fact]
    public void ShowsTheFullyBookedNotice_WhenThereIsOne()
    {
        UseAnnouncements(new Announcement("Fully booked Saturday", "Body", new DateOnly(2026, 10, 7), AnnouncementKind.FullyBooked));

        var home = Render<Home>();

        Assert.Contains("Fully booked Saturday", home.Find("a.notice").TextContent);
    }

    [Fact]
    public void HidesTheNotice_WhenNothingIsFullyBooked()
    {
        UseAnnouncements(new Announcement("New books", "Body", new DateOnly(2026, 9, 28), AnnouncementKind.News));

        var home = Render<Home>();

        Assert.Empty(home.FindAll("a.notice"));
    }

    [Fact]
    public void IntroducesEveryHouseCat()
    {
        UseAnnouncements();

        var home = Render<Home>();

        var names = home.FindAll(".cat-card h3").Select(h => h.TextContent).ToList();
        Assert.Equal(["Kape", "Mochi", "Tofu"], names);
    }

    private void UseAnnouncements(params Announcement[] announcements) =>
        Services.AddSingleton<IAnnouncementService>(new FakeAnnouncementService(announcements));
}
