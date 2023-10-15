
namespace RetailManagement.Models;

public class Order
{
    public Guid OrderId { get; }
    public Guid ProductId { get; }
    public int OrderStatus { get; }
    public int OrderType { get; }
    public Guid OrderBy { get; }
    public DateTime OrderedOn { get; }
    public DateTime ShippedOn { get; }
    public bool IsActive { get; }

    public Order(Guid orderId, Guid productId, int orderStatus, int orderType, Guid orderBy,
        DateTime orderedOn, DateTime shippedOn, bool isActive)
    {
        OrderId = orderId;
        ProductId = productId;
        OrderStatus = orderStatus;
        OrderType = orderType;
        OrderBy = orderBy;
        OrderedOn = orderedOn;
        ShippedOn = shippedOn;
        IsActive = isActive;
    }
}