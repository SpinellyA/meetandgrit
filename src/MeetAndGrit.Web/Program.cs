using MeetAndGrit.Web;
using MeetAndGrit.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Prototype: every service returns sample data. Swap these for API-backed
// implementations once the backend exists; the pages won't need to change.
builder.Services.AddScoped<ISeatAvailabilityService, MockSeatAvailabilityService>();
builder.Services.AddScoped<IAnnouncementService, MockAnnouncementService>();
builder.Services.AddScoped<ISpaceCatalog, MockSpaceCatalog>();
builder.Services.AddScoped<IMenuCatalog, MockMenuCatalog>();
builder.Services.AddScoped<ICafeInfoService, MockCafeInfoService>();

await builder.Build().RunAsync();
