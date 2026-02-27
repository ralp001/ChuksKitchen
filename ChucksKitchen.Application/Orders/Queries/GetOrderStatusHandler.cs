using ChuksKitchen.Application.Common;
using ChuksKitchen.Application.Common.Interfaces;
using ChuksKitchen.Application.Orders.Queries;
using MediatR;

public class GetOrderStatusHandler : IRequestHandler<GetOrderStatusQuery, Result<string>>
{
    private readonly IApplicationDbContext _context;
    public GetOrderStatusHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result<string>> Handle(GetOrderStatusQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FindAsync(new object[] { request.OrderId }, cancellationToken);
        return order == null
            ? Result<string>.Failure("Order not found.")
            : Result<string>.Success(order.Status.ToString());
    }
}