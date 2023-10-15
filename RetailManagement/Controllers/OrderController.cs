using Microsoft.AspNetCore.Mvc;
using RetailManagment.Controllers;
using RetailManagement.Services.Orders;
using RetailManagement.Models;
using ErrorOr;
using RetailManagement.Services.Customers;
using RetailManagement.DTO.Orders;

namespace RetailManagement.Controllers;

[Route("orders")]
public class OrderController : ApiController
{
    private readonly IOrderService _orderService;
    private readonly ICustomerService _customerService;
    public OrderController(ICustomerService customerService, IOrderService orderService)
    {
        _customerService = customerService;
        _orderService = orderService;
    }

    [HttpGet("customers/{id:guid}")]
    public IActionResult GetActiveOrders(Guid id)
    {
        // retrieve customer -> this validates if customer exists
        ErrorOr<Customer> customerRetrivalResult = _customerService.GetCustomer(id);

        if (customerRetrivalResult.IsError)
        {
            return Problem(customerRetrivalResult.Errors);
        }

        // retrive active orders of the customer
        List<OrderDTO> orderDTOs = _orderService.GetActiveOrders(id);

        return Ok(orderDTOs);
    }
}