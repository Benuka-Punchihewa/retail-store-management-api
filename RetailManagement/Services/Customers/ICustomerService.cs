
using RetailManagement.Models;
using ErrorOr;

namespace RetailManagement.Services.Customers;

public interface ICustomerService
{
    public List<Customer> GetCustomers();
    public ErrorOr<Created> CreateCustomer(Customer customer);
    public ErrorOr<Customer> GetCustomer(Guid userId);
    public ErrorOr<Updated> UpdateCustomer(Customer customer);
    public ErrorOr<Deleted> DeleteCustomer(Guid userId);
}