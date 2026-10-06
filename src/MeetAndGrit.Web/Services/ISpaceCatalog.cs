using MeetAndGrit.Web.Models;

namespace MeetAndGrit.Web.Services;

public interface ISpaceCatalog
{
    Task<IReadOnlyList<SpaceZone>> GetZonesAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Rate>> GetRatesAsync(CancellationToken cancellationToken = default);
}
