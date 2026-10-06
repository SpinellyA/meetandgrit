using MeetAndGrit.Web.Models;

namespace MeetAndGrit.Web.Services;

public interface ISeatAvailabilityService
{
    Task<IReadOnlyList<Seat>> GetSeatsAsync(CancellationToken cancellationToken = default);
}
