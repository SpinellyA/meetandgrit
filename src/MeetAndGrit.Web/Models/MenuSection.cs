namespace MeetAndGrit.Web.Models;

public record MenuSection(string Title, string Note, IReadOnlyList<MenuItem> Items);
