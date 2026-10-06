using System.Globalization;

namespace MeetAndGrit.Web.Models;

/// <summary>
/// One place for how prices, times and dates look on screen.
/// </summary>
public static class DisplayFormat
{
    private static readonly CultureInfo English = CultureInfo.GetCultureInfo("en-US");

    public static string Peso(decimal amount) =>
        "₱" + amount.ToString(amount % 1 == 0 ? "#,0" : "#,0.00", English);

    public static string Time(TimeOnly time) =>
        time.ToString(time.Minute == 0 ? "h tt" : "h:mm tt", English);

    public static string ShortDate(DateOnly date) =>
        date.ToString("MMM d", English);
}
