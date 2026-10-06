using MeetAndGrit.Web.Models;

namespace MeetAndGrit.Web.Services;

public class MockAnnouncementService : IAnnouncementService
{
    private static readonly IReadOnlyList<Announcement> Announcements =
    [
        new("Fully booked Saturday afternoon",
            "All seats are reserved on Sat, Oct 10 from 1 PM to 6 PM. Walk-ins are welcome again from 6 PM.",
            new DateOnly(2026, 10, 7),
            AnnouncementKind.FullyBooked),
        new("Open until midnight during finals week",
            "From Oct 19 to 24 we stay open until 12 AM. Same rates, more coffee.",
            new DateOnly(2026, 10, 5),
            AnnouncementKind.ScheduleChange),
        new("New on the shelf: the community bookshelf",
            "Borrow a book while you stay, or leave one you've finished for the next person.",
            new DateOnly(2026, 9, 28),
            AnnouncementKind.News),
    ];

    public Task<IReadOnlyList<Announcement>> GetLatestAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(Announcements);
}
