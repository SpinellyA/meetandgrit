using MeetAndGrit.Web.Models;

namespace MeetAndGrit.Web.Services;

public interface IAnnouncementService
{
    Task<IReadOnlyList<Announcement>> GetLatestAsync(CancellationToken cancellationToken = default);
}
