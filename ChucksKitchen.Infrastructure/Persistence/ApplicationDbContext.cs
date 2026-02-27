using ChuksKitchen.Application.Common.Interfaces;
using ChuksKitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChuksKitchen.Infrastructure.Persistence;

public class AppDbContext : DbContext, IApplicationDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<FoodItem> FoodItems => Set<FoodItem>();
    public DbSet<Order> Orders => Set<Order>();

    // No changes needed to SaveChangesAsync as DbContext already implements it
}