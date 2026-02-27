namespace ChuksKitchen.Domain.Entities;

public enum OrderStatus
{
    Pending,
    Confirmed,
    Preparing,
    OutForDelivery,
    Completed,
    Cancelled
}

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItem> Items { get; set; } = new();
}

public class OrderItem
{
    public Guid Id { get; set; }
    public Guid FoodItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}