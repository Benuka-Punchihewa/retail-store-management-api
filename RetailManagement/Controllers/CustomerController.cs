using Microsoft.AspNetCore.Mvc;
using RetailManagement.Contracts.Customer;
using RetailManagment.Controllers;

namespace RetailManagement.Controllers;


public class CustomerController : ApiController
{
    [Route("customers")]

    [HttpPost]
    public IActionResult CreateCustomer(CreateCustomerRequest request)
    {

        return Ok();
    }

    [HttpGet]
    public IActionResult GetAllCustomers()
    {

        return Ok();
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
}