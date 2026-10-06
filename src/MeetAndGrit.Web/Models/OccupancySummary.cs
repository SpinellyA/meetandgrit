namespace MeetAndGrit.Web.Models;

public record OccupancySummary(int Open, int Total)
{
    public bool IsFullyBooked => Total > 0 && Open == 0;

    public static OccupancySummary From(IReadOnlyCollection<Seat> seats) =>
        new(seats.Count(seat => seat.Status == SeatStatus.Open), seats.Count);
}
