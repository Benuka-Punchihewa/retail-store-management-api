using RetailManagement.DTO.Orders;

namespace RetailManagement.Services.Orders;

public interface IOrderService
{
    public List<OrderDTO> GetActiveOrders(Guid UserId);
}