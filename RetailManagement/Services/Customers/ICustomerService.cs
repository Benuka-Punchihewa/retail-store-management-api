
using RetailManagement.Models;

namespace RetailManagement.Services.Customers;

public interface ICustomerService
{
    public List<Customer> GetCustomers();
}