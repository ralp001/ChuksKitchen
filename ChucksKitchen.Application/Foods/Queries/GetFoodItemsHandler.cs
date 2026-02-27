using MediatR;
using ChuksKitchen.Application.Common;
using ChuksKitchen.Application.Common.Interfaces;
using ChuksKitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChuksKitchen.Application.Foods.Queries;

public class GetFoodItemsHandler : IRequestHandler<GetFoodItemsQuery, Result<List<FoodItem>>>
{
    private readonly IApplicationDbContext _context;

    public GetFoodItemsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<FoodItem>>> Handle(GetFoodItemsQuery request, CancellationToken cancellationToken)
    {
        // Fetch items from the seeded In-Memory database
        var foods = await _context.FoodItems
            .Where(f => f.IsAvailable)
            .ToListAsync(cancellationToken);

        return Result<List<FoodItem>>.Success(foods, "Menu retrieved successfully.");
    }
}