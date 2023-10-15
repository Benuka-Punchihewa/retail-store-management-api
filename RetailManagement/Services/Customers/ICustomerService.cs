
using RetailManagement.Models;
using ErrorOr;

namespace RetailManagement.Services.Customers;

public interface ICustomerService
{
    public List<Customer> GetCustomers();

    public ErrorOr<Created> CreateCustomer(Customer customer);
}