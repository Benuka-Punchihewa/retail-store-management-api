using ErrorOr;
using RetailManagement.Utils.Customers;

namespace RetailManagement.Models;

public class Customer
{
    public Guid UserId { get; }
    public string Username { get; }
    public string Email { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime CreatedOn { get; }
    public bool IsActive { get; }

    public Customer(Guid userId, string userName, string email, string firstName, string lastName, DateTime createdOn, bool isActive)
    {
        UserId = userId;
        Username = userName;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        CreatedOn = createdOn;
        IsActive = isActive;
    }

    public static ErrorOr<Customer> CreateInstanceForSaving(string userName, string email, string firstName, string lastName, bool isActive)
    {

        Customer customer = new(
            Guid.NewGuid(),
            userName,
            email,
            firstName,
            lastName,
            DateTime.UtcNow,
            isActive
        );

        // validate customer        
        List<Error> errors = CustomerUtil.Validate(customer);

        if (errors.Count > 0)
        {
            return errors;
        }

        return customer;
    }

    public static ErrorOr<Customer> CreateInstanceForUpdation(Customer curCustomer, string userName, string email, string firstName, string lastName, bool isActive)
    {

        Customer customer = new(
            curCustomer.UserId,
            userName,
            email,
            firstName,
            lastName,
            curCustomer.CreatedOn,
            isActive
        );

        // validate customer
        List<Error> errors = CustomerUtil.Validate(customer);

        if (errors.Count > 0)
        {
            return errors;
        }

        return customer;
    }
}