namespace RetailManagement.Models;

public class Product
{
    public Guid ProductId { get; }
    public string ProductName { get; }
    public decimal UnitPrice { get; }
    public Guid SupplierId { get; }
    public DateTime CreatedOn { get; }
    public bool IsActive { get; }

    public Product(Guid productId, string productName, decimal unitPrice, Guid supplierId,
        DateTime createdOn, bool isActive)
    {
        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        SupplierId = supplierId;
        CreatedOn = createdOn;
        IsActive = isActive;
    }
}