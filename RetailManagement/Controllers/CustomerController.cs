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
        // instantiate customer
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

        // save customer
        ErrorOr<Created> customersCreatorResult = _customerService.CreateCustomer(customer);

        if (customersCreatorResult.IsError)
        {
            return Problem(customersCreatorResult.Errors);
        }

        return CreatedAtAction(
            actionName: nameof(GetCustomer),
            routeValues: new { id = customer.UserId },
            value: customer
        );
    }

    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        // retrieve customers
        List<Customer> customers = _customerService.GetCustomers();

        return Ok(customers);
    }

    // NOTE: in the assignment, the HTTP request type for this request was given as POST, but suitable HTTP request type is PUT
    [HttpPut("{id:guid}")]
    public IActionResult UpdateCustomer(Guid id, CustomerMutationRequest request)
    {
        // retrieve customer -> this validates if customer exists
        ErrorOr<Customer> customerRetrivalResult = _customerService.GetCustomer(id);

        if (customerRetrivalResult.IsError)
        {
            return Problem(customerRetrivalResult.Errors);
        }

        // instantiate customer
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

        // update customer
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
        // retrieve customer
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
        // retrieve customer -> this validates if customer exists
        ErrorOr<Customer> customerRetrivalResult = _customerService.GetCustomer(id);

        if (customerRetrivalResult.IsError)
        {
            return Problem(customerRetrivalResult.Errors);
        }

        // delete customer
        ErrorOr<Deleted> customersDeletionResult = _customerService.DeleteCustomer(id);

        if (customersDeletionResult.IsError)
        {
            return Problem(customersDeletionResult.Errors);
        }

        return NoContent();
    }
}