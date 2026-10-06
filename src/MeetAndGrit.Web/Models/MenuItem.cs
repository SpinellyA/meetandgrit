namespace MeetAndGrit.Web.Models;

public record MenuItem(string Name, string Description, decimal Price, bool IsHouseFavorite = false);
