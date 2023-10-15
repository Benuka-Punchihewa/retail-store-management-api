using RetailManagement.Models;

namespace RetailManagement.DTO.Orders;

public class OrderDTO
{
    public Guid OrderId { get; }
    public int OrderStatus { get; }
    public int OrderType { get; }
    public Guid OrderBy { get; }
    public DateTime OrderedOn { get; }
    public DateTime ShippedOn { get; }
    public bool IsActive { get; }
    public Supplier Supplier { get; }
    public Product Product { get; }

    public OrderDTO(Order order, Supplier supplier, Product product)
    {
        OrderId = order.OrderId;
        OrderStatus = order.OrderStatus;
        OrderType = order.OrderType;
        OrderBy = order.OrderBy;
        OrderedOn = order.OrderedOn;
        ShippedOn = order.ShippedOn;
        IsActive = order.IsActive;
        Supplier = supplier;
        Product = product;
    }
}