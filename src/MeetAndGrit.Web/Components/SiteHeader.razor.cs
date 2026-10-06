using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace MeetAndGrit.Web.Components;

public partial class SiteHeader : IDisposable
{
    public static readonly IReadOnlyList<(string Text, string Href)> Links =
    [
        ("Space & rates", "space"),
        ("Menu", "menu"),
        ("Visit", "visit"),
    ];

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    private bool IsMenuOpen { get; set; }

    protected override void OnInitialized() =>
        Navigation.LocationChanged += CloseMenuOnNavigate;

    private void ToggleMenu() => IsMenuOpen = !IsMenuOpen;

    private void CloseMenuOnNavigate(object? sender, LocationChangedEventArgs e)
    {
        IsMenuOpen = false;
        StateHasChanged();
    }

    public void Dispose() =>
        Navigation.LocationChanged -= CloseMenuOnNavigate;
}
