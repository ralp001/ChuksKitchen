using MediatR;
using ChuksKitchen.Application.Common;
using ChuksKitchen.Domain.Entities;

namespace ChuksKitchen.Application.Foods.Queries;

public record GetFoodItemsQuery() : IRequest<Result<List<FoodItem>>>;