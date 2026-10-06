using MeetAndGrit.Web.Models;

namespace MeetAndGrit.Web.Services;

public interface IMenuCatalog
{
    Task<IReadOnlyList<MenuSection>> GetMenuAsync(CancellationToken cancellationToken = default);
}
