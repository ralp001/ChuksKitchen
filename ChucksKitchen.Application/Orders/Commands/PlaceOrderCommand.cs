using MediatR;
using ChuksKitchen.Application.Common;

namespace ChuksKitchen.Application.Orders.Commands;

public record PlaceOrderCommand(Guid UserId, List<Guid> FoodItemIds) : IRequest<Result<Guid>>;