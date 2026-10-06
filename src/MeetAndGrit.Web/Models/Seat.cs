namespace MeetAndGrit.Web.Models;

/// <summary>
/// A single seat on the floor plan. X and Y are positions inside the
/// 400 x 300 floor-plan drawing, not real-world measurements.
/// </summary>
public record Seat(
    string Id,
    string Zone,
    double X,
    double Y,
    SeatStatus Status,
    string? NappingCat = null);
