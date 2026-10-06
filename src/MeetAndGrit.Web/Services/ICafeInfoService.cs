using MeetAndGrit.Web.Models;

namespace MeetAndGrit.Web.Services;

public interface ICafeInfoService
{
    Task<CafeInfo> GetInfoAsync(CancellationToken cancellationToken = default);
}
