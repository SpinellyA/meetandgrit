using Bunit;
using MeetAndGrit.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace MeetAndGrit.Tests.Components;

public class SiteHeaderTests : BunitContext
{
    [Fact]
    public void MenuButton_OpensAndClosesTheMobileMenu()
    {
        var header = Render<SiteHeader>();
        var toggle = header.Find("button.menu-toggle");

        Assert.Equal("false", toggle.GetAttribute("aria-expanded"));

        toggle.Click();
        Assert.Equal("true", header.Find("button.menu-toggle").GetAttribute("aria-expanded"));
        Assert.Contains("is-open", header.Find("#site-nav").ClassList);

        header.Find("button.menu-toggle").Click();
        Assert.Equal("false", header.Find("button.menu-toggle").GetAttribute("aria-expanded"));
    }

    [Fact]
    public void Navigating_ClosesTheMobileMenu()
    {
        var header = Render<SiteHeader>();
        header.Find("button.menu-toggle").Click();

        Services.GetRequiredService<NavigationManager>().NavigateTo("menu");

        header.WaitForAssertion(() =>
            Assert.Equal("false", header.Find("button.menu-toggle").GetAttribute("aria-expanded")));
    }

    [Fact]
    public void LinksToEveryPublicPage_AndToReservations()
    {
        var header = Render<SiteHeader>();

        var hrefs = header.FindAll("a").Select(a => a.GetAttribute("href")).ToList();
        Assert.Contains("space", hrefs);
        Assert.Contains("menu", hrefs);
        Assert.Contains("visit", hrefs);
        Assert.Contains("login", hrefs);
        Assert.Contains("reserve", hrefs);
    }
}
