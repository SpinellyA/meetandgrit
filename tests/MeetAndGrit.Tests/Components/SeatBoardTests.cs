using Bunit;
using MeetAndGrit.Tests.Fakes;
using MeetAndGrit.Web.Components;
using MeetAndGrit.Web.Models;
using MeetAndGrit.Web.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MeetAndGrit.Tests.Components;

public class SeatBoardTests : BunitContext
{
    [Fact]
    public void ShowsHowManySeatsAreOpen()
    {
        UseSeats(
            new Seat("A", "Zone", 10, 10, SeatStatus.Open),
            new Seat("B", "Zone", 30, 10, SeatStatus.Occupied),
            new Seat("C", "Zone", 50, 10, SeatStatus.Open));

        var board = Render<SeatBoard>();

        var count = board.Find("[data-testid=open-count]");
        Assert.Equal("2 of 3 open", count.TextContent.Trim());
    }

    [Fact]
    public void DrawsOneMarkerPerSeat_StyledByStatus()
    {
        UseSeats(
            new Seat("A", "Zone", 10, 10, SeatStatus.Open),
            new Seat("B", "Zone", 30, 10, SeatStatus.Occupied),
            new Seat("C", "Zone", 50, 10, SeatStatus.Reserved));

        var board = Render<SeatBoard>();

        Assert.Equal(3, board.FindAll("g.seat").Count);
        Assert.Single(board.FindAll("g.seat-open"));
        Assert.Single(board.FindAll("g.seat-occupied"));
        Assert.Single(board.FindAll("g.seat-reserved"));
    }

    [Fact]
    public void DrawsTheNappingCat_OnlyWhenOneIsOnASeat()
    {
        UseSeats(new Seat("A", "Zone", 10, 10, SeatStatus.Occupied, NappingCat: "Kape"));

        var board = Render<SeatBoard>();

        var cat = board.Find("g.cat title");
        Assert.Equal("Kape is napping here", cat.TextContent);
    }

    [Fact]
    public void DescribesAvailabilityForScreenReaders()
    {
        UseSeats(new Seat("A", "Zone", 10, 10, SeatStatus.Open));

        var board = Render<SeatBoard>();

        var label = board.Find("svg[role=img]").GetAttribute("aria-label");
        Assert.Contains("1 of 1 seats are open", label);
    }

    private void UseSeats(params Seat[] seats) =>
        Services.AddSingleton<ISeatAvailabilityService>(new FakeSeatAvailabilityService(seats));
}
