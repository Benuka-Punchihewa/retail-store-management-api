
namespace RetailManagement.Services.Orders;

public interface IOrderService
{
    public void GetActiveOrders(Guid UserId);
}