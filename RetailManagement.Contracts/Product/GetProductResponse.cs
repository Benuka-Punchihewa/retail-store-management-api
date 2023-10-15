using RetailManagement.Contracts.Supplier;

namespace RetailManagement.Contracts.Product;

public record GetProductResponse(
    Guid ProductId,
    string ProductName,
    decimal UnitPrice,
    GetSupplierResponse Supplier,
    DateTime CreatedOn,
    bool IsActive
);