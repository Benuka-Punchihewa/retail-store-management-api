using Microsoft.AspNetCore.Mvc;
using RetailManagment.Controllers;
using RetailManagement.Services.Orders;
using RetailManagement.Models;
using ErrorOr;
using RetailManagement.Services.Customers;

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
        ErrorOr<Customer> customerRetrivalResult = _customerService.GetCustomer(id);

        if (customerRetrivalResult.IsError)
        {
            return Problem(customerRetrivalResult.Errors);
        }

        _orderService.GetActiveOrders(id);

        return Ok();
    }
}