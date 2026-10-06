using MeetAndGrit.Web.Models;

namespace MeetAndGrit.Tests.Models;

public class OccupancySummaryTests
{
    [Fact]
    public void From_CountsOnlyOpenSeatsAsOpen()
    {
        Seat[] seats =
        [
            new("A", "Zone", 0, 0, SeatStatus.Open),
            new("B", "Zone", 0, 0, SeatStatus.Occupied),
            new("C", "Zone", 0, 0, SeatStatus.Reserved),
            new("D", "Zone", 0, 0, SeatStatus.Open),
        ];

        var summary = OccupancySummary.From(seats);

        Assert.Equal(2, summary.Open);
        Assert.Equal(4, summary.Total);
        Assert.False(summary.IsFullyBooked);
    }

    [Fact]
    public void IsFullyBooked_WhenNoSeatIsOpen()
    {
        Seat[] seats =
        [
            new("A", "Zone", 0, 0, SeatStatus.Occupied),
            new("B", "Zone", 0, 0, SeatStatus.Reserved),
        ];

        Assert.True(OccupancySummary.From(seats).IsFullyBooked);
    }

    [Fact]
    public void IsFullyBooked_IsFalseWhenThereAreNoSeats()
    {
        Assert.False(OccupancySummary.From([]).IsFullyBooked);
    }
}
