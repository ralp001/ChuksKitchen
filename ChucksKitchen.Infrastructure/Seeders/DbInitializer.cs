using ChuksKitchen.Domain.Entities;
using ChuksKitchen.Infrastructure.Persistence;

namespace ChuksKitchen.Infrastructure.Seeders;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.FoodItems.Any()) return; // If there's already food, don't seed

        var foods = new List<FoodItem>
        {
            new() { Id = Guid.NewGuid(), Name = "Jollof Rice & Chicken", Description = "Classic Nigerian Jollof", Price = 3500, IsAvailable = true, Category = "Main Dish" },
            new() { Id = Guid.NewGuid(), Name = "Poundo Yam & Egusi", Description = "Smooth poundo with rich egusi soup", Price = 4500, IsAvailable = true, Category = "Swallow" },
            new() { Id = Guid.NewGuid(), Name = "Beef Burger", Description = "Juicy beef patty with special sauce", Price = 5000, IsAvailable = true, Category = "Fast Food" },
            new() { Id = Guid.NewGuid(), Name = "Fresh Fruit Juice", Description = "Chilled natural orange juice", Price = 1500, IsAvailable = true, Category = "Drinks" }
        };

        context.FoodItems.AddRange(foods);
        context.SaveChanges();
    }
}