using RetailManagement.Contracts.Product;

namespace RetailManagement.Contracts.Order;

public record GetOrderResponse(
    Guid OrderId,
    GetProductResponse product,
    int OrderStatus,
    int OrderType,
    Guid OrderBy,
    DateTime OrderedOn,
    DateTime ShippedOn,
    bool IsActive
);