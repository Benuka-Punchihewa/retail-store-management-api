namespace RetailManagement.Contracts.Supplier;

public record GetSupplierResponse(
    Guid SupplierId,
    string SupplierName,
    DateTime CreatedOn,
    bool IsActive
);