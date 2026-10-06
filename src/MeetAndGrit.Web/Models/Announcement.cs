namespace MeetAndGrit.Web.Models;

public record Announcement(
    string Title,
    string Body,
    DateOnly Date,
    AnnouncementKind Kind);
