using MeetAndGrit.Web.Services;

namespace MeetAndGrit.Tests.Services;

/// <summary>
/// The sample data is shown side by side on several pages,
/// so the numbers in each mock have to agree with each other.
/// </summary>
public class MockDataConsistencyTests
{
    [Fact]
    public async Task SeatIds_AreUnique()
    {
        var seats = await new MockSeatAvailabilityService().GetSeatsAsync();

        Assert.Equal(seats.Count, seats.Select(seat => seat.Id).Distinct().Count());
    }

    [Fact]
    public async Task SeatCountPerZone_MatchesTheSpaceCatalog()
    {
        var seats = await new MockSeatAvailabilityService().GetSeatsAsync();
        var zones = await new MockSpaceCatalog().GetZonesAsync();

        foreach (var zone in zones)
        {
            Assert.Equal(zone.Seats, seats.Count(seat => seat.Zone == zone.Name));
        }
    }

    [Fact]
    public async Task ExactlyOneCatIsNapping_AndItIsAHouseCat()
    {
        var seats = await new MockSeatAvailabilityService().GetSeatsAsync();
        var info = await new MockCafeInfoService().GetInfoAsync();

        var napping = Assert.Single(seats, seat => seat.NappingCat is not null);
        Assert.Contains(info.Cats, cat => cat.Name == napping.NappingCat);
    }
}
