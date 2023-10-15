using Microsoft.AspNetCore.Mvc;
using RetailManagement.Contracts.Customer;
using RetailManagement.Models;
using RetailManagment.Controllers;
using ErrorOr;
using RetailManagement.Services.Customers;

namespace RetailManagement.Controllers;

[Route("customers")]
public class CustomerController : ApiController
{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public IActionResult CreateCustomer(CreateCustomerRequest request)
    {
        ErrorOr<Customer> customerInstantiationResult = Customer.CreateInstanceForSaving(
            request.Username,
            request.Email,
            request.FirstName,
            request.LastName,
            request.IsActive
            );
        if (customerInstantiationResult.IsError)
        {
            return Problem(customerInstantiationResult.Errors);
        }

        Customer customer = customerInstantiationResult.Value;

        ErrorOr<Created> customersCreatorResult = _customerService.CreateCustomer(customer);

        if (customersCreatorResult.IsError)
        {
            return Problem(customersCreatorResult.Errors);
        }

        // TODO: Configure ActionResult
        return CreatedAtAction(
            null,
            value: MapGetCustomerResponse(customer)
        );
    }

    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        List<Customer> customers = _customerService.GetCustomers();

        return Ok(customers);
    }

    // NOTE: in the assignment, the HTTP request type for this request was given as POST, but suitable HTTP request type is PUT
    [HttpPut("{id:guid}")]
    public IActionResult UpdateCustomer(Guid id, UpdateCustomerRequest request)
    {

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCustomer(Guid id)
    {

        return Ok();
    }

    private static GetCustomerResponse MapGetCustomerResponse(Customer customer)
    {
        return new GetCustomerResponse(
                    customer.UserId,
                    customer.Username,
                    customer.Email,
                    customer.FirstName,
                    customer.LastName,
                    customer.CreatedOn,
                    customer.IsActive
                 );

    }
}