using MeetAndGrit.Web.Models;
using MeetAndGrit.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MeetAndGrit.Web.Components;

public partial class SeatBoard
{
    [Inject]
    private ISeatAvailabilityService SeatAvailability { get; set; } = default!;

    private IReadOnlyList<Seat> Seats { get; set; } = [];

    private OccupancySummary? Summary { get; set; }

    private string AccessibleDescription => Summary is null
        ? "Floor plan of Meet & Grit, loading seat availability."
        : $"Floor plan of Meet & Grit. {Summary.Open} of {Summary.Total} seats are open right now.";

    protected override async Task OnInitializedAsync()
    {
        Seats = await SeatAvailability.GetSeatsAsync();
        Summary = OccupancySummary.From(Seats);
    }

    private static string DescribeSeat(Seat seat)
    {
        var status = seat.Status switch
        {
            SeatStatus.Open => "open",
            SeatStatus.Reserved => "reserved",
            _ => "taken",
        };

        return $"{seat.Zone}, seat {seat.Id}: {status}";
    }
}
