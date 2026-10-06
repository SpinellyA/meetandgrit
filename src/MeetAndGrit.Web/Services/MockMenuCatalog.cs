using MeetAndGrit.Web.Models;

namespace MeetAndGrit.Web.Services;

/// <summary>
/// Placeholder menu. Swap in the client's actual items and prices.
/// </summary>
public class MockMenuCatalog : IMenuCatalog
{
    private static readonly IReadOnlyList<MenuSection> Menu =
    [
        new("Coffee", "Hot or iced",
        [
            new("Americano", "Double shot, hot water or over ice.", 110m),
            new("Spanish latte", "Espresso, milk, a little condensed sweetness.", 150m, IsHouseFavorite: true),
            new("Sea salt latte", "Salted cream on top of an iced latte.", 160m),
            new("Cafe mocha", "Espresso, dark chocolate, steamed milk.", 155m),
        ]),
        new("Not coffee", "For the late shift",
        [
            new("Matcha latte", "Ceremonial-grade matcha with milk.", 160m),
            new("Chocolate", "Thick, hot, and not too sweet.", 130m),
            new("Calamansi soda", "Fresh calamansi and sparkling water.", 110m),
        ]),
        new("From the pastry case", "Baked every morning",
        [
            new("Banana loaf", "Thick slice, walnuts on top.", 95m, IsHouseFavorite: true),
            new("Ensaymada", "Butter, sugar, grated cheese.", 85m),
            new("Cinnamon roll", "Cream cheese glaze.", 110m),
        ]),
        new("Something filling", "Served until 8 PM",
        [
            new("Chicken pesto pasta", "Basil pesto, grilled chicken, parmesan.", 220m),
            new("Tuna melt", "Toasted sourdough, cheddar, side of chips.", 190m),
            new("Garlic fries", "Good for sharing at the long table.", 140m),
        ]),
    ];

    public Task<IReadOnlyList<MenuSection>> GetMenuAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(Menu);
}
