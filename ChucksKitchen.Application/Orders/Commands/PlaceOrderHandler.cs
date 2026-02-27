using MediatR;
using ChuksKitchen.Application.Common;
using ChuksKitchen.Application.Common.Interfaces;
using ChuksKitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChuksKitchen.Application.Orders.Commands;

public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _context;

    public PlaceOrderHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid>> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        // 1. Edge Case: Check if User exists and is verified
        var user = await _context.Users.FindAsync(new object[] { request.UserId }, cancellationToken);
        if (user == null || !user.IsVerified)
            return Result<Guid>.Failure("User must be verified to place an order.");

        // 2. Fetch selected food items
        var foodItems = await _context.FoodItems
            .Where(f => request.FoodItemIds.Contains(f.Id))
            .ToListAsync(cancellationToken);

        if (!foodItems.Any())
            return Result<Guid>.Failure("No valid food items selected.");

        // 3. Create Order
        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.Pending,
            TotalAmount = foodItems.Sum(f => f.Price),
            Items = foodItems.Select(f => new OrderItem
            {
                Id = Guid.NewGuid(),
                FoodItemId = f.Id,
                Quantity = 1, // Simplified for this deliverable
                UnitPrice = f.Price
            }).ToList()
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(order.Id, "Order placed successfully! Status: Pending.");
    }
}