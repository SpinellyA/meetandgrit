using MeetAndGrit.Web.Models;
using MeetAndGrit.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MeetAndGrit.Web.Pages;

public partial class Menu
{
    [Inject]
    private IMenuCatalog MenuCatalog { get; set; } = default!;

    private IReadOnlyList<MenuSection> Sections { get; set; } = [];

    protected override async Task OnInitializedAsync() =>
        Sections = await MenuCatalog.GetMenuAsync();

    private static string SectionId(MenuSection section) =>
        "menu-" + section.Title.ToLowerInvariant().Replace(' ', '-');
}
