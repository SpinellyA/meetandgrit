using MeetAndGrit.Web.Models;
using MeetAndGrit.Web.Services;

namespace MeetAndGrit.Tests.Fakes;

public class FakeAnnouncementService(IReadOnlyList<Announcement> announcements) : IAnnouncementService
{
    public Task<IReadOnlyList<Announcement>> GetLatestAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(announcements);
}
