using ErrorOr;
using RetailManagement.DTO.Orders;
using RetailManagement.Models;

namespace RetailManagement.Services.Orders;

public interface IOrderService
{
    public List<OrderDTO> GetActiveOrders(Guid UserId);

    public ErrorOr<Created> CreateOrder(Order order);
}