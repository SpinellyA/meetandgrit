namespace MeetAndGrit.Web.Models;

public record SpaceZone(
    string Name,
    int Seats,
    string GoodFor,
    string Description,
    IReadOnlyList<string> Amenities);
