using MeetAndGrit.Web.Models;
using MeetAndGrit.Web.Services;
using Microsoft.AspNetCore.Components;

namespace MeetAndGrit.Web.Pages;

public partial class Visit
{
    [Inject]
    private ICafeInfoService CafeInfoService { get; set; } = default!;

    private CafeInfo? Info { get; set; }

    protected override async Task OnInitializedAsync() =>
        Info = await CafeInfoService.GetInfoAsync();
}
