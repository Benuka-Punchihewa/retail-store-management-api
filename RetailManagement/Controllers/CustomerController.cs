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
    public IActionResult CreateCustomer(CustomerMutationRequest request)
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
            value: customer
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
    public IActionResult UpdateCustomer(Guid id, CustomerMutationRequest request)
    {
        ErrorOr<Customer> customerRetrivalResult = _customerService.GetCustomer(id);

        if (customerRetrivalResult.IsError)
        {
            return Problem(customerRetrivalResult.Errors);
        }

        ErrorOr<Customer> customerInstantiationResult = Customer.CreateInstanceForUpdation(
            customerRetrivalResult.Value,
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

        Customer updatedCustomer = customerInstantiationResult.Value;

        ErrorOr<Updated> customersUpdationResult = _customerService.UpdateCustomer(updatedCustomer);

        if (customersUpdationResult.IsError)
        {
            return Problem(customersUpdationResult.Errors);
        }

        return Ok(updatedCustomer);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetCustomer(Guid id)
    {
        ErrorOr<Customer> customerRetrivalResult = _customerService.GetCustomer(id);

        if (customerRetrivalResult.IsError)
        {
            return Problem(customerRetrivalResult.Errors);
        }

        Customer customer = customerRetrivalResult.Value;

        return Ok(customer);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCustomer(Guid id)
    {

        return Ok();
    }
}