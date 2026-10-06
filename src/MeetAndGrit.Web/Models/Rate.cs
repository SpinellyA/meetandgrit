namespace MeetAndGrit.Web.Models;

public record Rate(
    string Name,
    decimal Price,
    string Unit,
    string Summary,
    IReadOnlyList<string> Includes,
    bool IsMembership = false);
