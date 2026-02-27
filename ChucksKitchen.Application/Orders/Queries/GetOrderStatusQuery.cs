using MediatR;
using ChuksKitchen.Application.Common;
using ChuksKitchen.Domain.Entities;

namespace ChuksKitchen.Application.Orders.Queries;

public record GetOrderStatusQuery(Guid OrderId) : IRequest<Result<string>>;