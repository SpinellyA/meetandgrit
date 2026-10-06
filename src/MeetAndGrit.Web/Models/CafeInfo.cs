namespace MeetAndGrit.Web.Models;

public record CafeInfo(
    string Address,
    string MapUrl,
    string FacebookUrl,
    IReadOnlyList<OpeningHours> Hours,
    IReadOnlyList<CafeCat> Cats);
