namespace RetailManagement.Models;

public class Supplier
{
    public Guid SupplierId { get; }
    public string SupplierName { get; }
    public DateTime CreatedOn { get; }
    public bool IsActive { get; }

    public Supplier(Guid supplierId, string supplierName, DateTime createdOn, bool isActive)
    {
        SupplierId = supplierId;
        SupplierName = supplierName;
        CreatedOn = createdOn;
        IsActive = isActive;
    }
}