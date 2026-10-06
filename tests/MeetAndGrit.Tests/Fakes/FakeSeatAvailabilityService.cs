using MeetAndGrit.Web.Models;
using MeetAndGrit.Web.Services;

namespace MeetAndGrit.Tests.Fakes;

public class FakeSeatAvailabilityService(IReadOnlyList<Seat> seats) : ISeatAvailabilityService
{
    public Task<IReadOnlyList<Seat>> GetSeatsAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(seats);
}
