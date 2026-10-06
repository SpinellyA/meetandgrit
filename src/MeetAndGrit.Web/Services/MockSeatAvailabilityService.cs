using MeetAndGrit.Web.Models;

namespace MeetAndGrit.Web.Services;

/// <summary>
/// Sample floor plan until the API exists. Positions match the drawing in
/// Components/SeatBoard.razor, which uses a 400 x 300 coordinate space.
/// </summary>
public class MockSeatAvailabilityService : ISeatAvailabilityService
{
    public const string WindowBar = "Window bar";
    public const string LongTables = "Long tables";
    public const string MeetingRoom = "Meeting room";
    public const string ReadingNook = "Reading nook";

    // Which seats are taken in the sample data, by seat id.
    private static readonly HashSet<string> OccupiedSeatIds =
        ["W2", "W3", "W6", "T1", "T2", "T5", "T7", "T10", "T11", "T14", "N1"];

    private static readonly HashSet<string> ReservedSeatIds = ["M1", "M2", "M3", "M4", "T15"];

    private const string NappingSeatId = "N1";

    public Task<IReadOnlyList<Seat>> GetSeatsAsync(CancellationToken cancellationToken = default)
    {
        var seats = new List<Seat>();

        for (var i = 0; i < 8; i++)
        {
            seats.Add(CreateSeat($"W{i + 1}", WindowBar, 52 + i * 42, 34));
        }

        // Two long tables, four seats on each side.
        var tableSeatNumber = 1;
        foreach (var tableLeft in new[] { 30.0, 215.0 })
        {
            foreach (var y in new[] { 92.0, 152.0 })
            {
                for (var i = 0; i < 4; i++)
                {
                    seats.Add(CreateSeat($"T{tableSeatNumber++}", LongTables, tableLeft + 22 + i * 40, y));
                }
            }
        }

        foreach (var (x, y, number) in new[] { (60.0, 224.0, 1), (110.0, 224.0, 2), (60.0, 270.0, 3), (110.0, 270.0, 4) })
        {
            seats.Add(CreateSeat($"M{number}", MeetingRoom, x, y));
        }

        foreach (var (x, y, number) in new[] { (248.0, 226.0, 1), (312.0, 226.0, 2), (248.0, 270.0, 3), (312.0, 270.0, 4) })
        {
            seats.Add(CreateSeat($"N{number}", ReadingNook, x, y));
        }

        return Task.FromResult<IReadOnlyList<Seat>>(seats);
    }

    private static Seat CreateSeat(string id, string zone, double x, double y)
    {
        var status = OccupiedSeatIds.Contains(id) ? SeatStatus.Occupied
            : ReservedSeatIds.Contains(id) ? SeatStatus.Reserved
            : SeatStatus.Open;

        var cat = id == NappingSeatId ? "Kape" : null;

        return new Seat(id, zone, x, y, status, cat);
    }
}
