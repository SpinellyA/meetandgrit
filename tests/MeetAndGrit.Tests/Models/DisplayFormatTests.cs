using MeetAndGrit.Web.Models;

namespace MeetAndGrit.Tests.Models;

public class DisplayFormatTests
{
    [Theory]
    [InlineData(60, "₱60")]
    [InlineData(3500, "₱3,500")]
    [InlineData(99.5, "₱99.50")]
    public void Peso_FormatsWithSignAndThousandsSeparator(decimal amount, string expected)
    {
        Assert.Equal(expected, DisplayFormat.Peso(amount));
    }

    [Theory]
    [InlineData(9, 0, "9 AM")]
    [InlineData(22, 0, "10 PM")]
    [InlineData(9, 30, "9:30 AM")]
    public void Time_DropsMinutesOnTheHour(int hour, int minute, string expected)
    {
        Assert.Equal(expected, DisplayFormat.Time(new TimeOnly(hour, minute)));
    }

    [Fact]
    public void ShortDate_UsesMonthAbbreviationAndDay()
    {
        Assert.Equal("Oct 7", DisplayFormat.ShortDate(new DateOnly(2026, 10, 7)));
    }
}
