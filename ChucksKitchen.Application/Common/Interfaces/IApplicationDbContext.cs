using ChuksKitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChuksKitchen.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<FoodItem> FoodItems { get; }
    DbSet<Order> Orders { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}