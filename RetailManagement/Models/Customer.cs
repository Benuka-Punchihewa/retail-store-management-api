using ErrorOr;
using RetailManagement.ServiceErrors;
using System.Text.RegularExpressions;

namespace RetailManagement.Models;

public class Customer
{
    public const int MIN_USERNAME_LENGTH = 5;
    public const int MAX_USERNAME_LENGTH = 30;
    public const int MIN_EMAIL_LENGTH = 5;
    public const int MAX_EMAIL_LENGTH = 20;
    public const int MIN_FIRSTNAME_LENGTH = 2;
    public const int MAX_FIRSTNAME_LENGTH = 20;
    public const int MIN_LASTNAME_LENGTH = 2;
    public const int MAX_LASTNAME_LENGTH = 20;

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

        List<Error> errors = Validate(customer);

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

        List<Error> errors = Validate(customer);

        if (errors.Count > 0)
        {
            return errors;
        }

        return customer;
    }

    private static List<Error> Validate(Customer customer)
    {
        List<Error> errors = new();

        if (customer.Username.Length is < MIN_USERNAME_LENGTH or > MAX_USERNAME_LENGTH)
        {
            errors.Add(Errors.Customer.InvalidUsernameLength);
        }

        if (customer.Email.Length is < MIN_EMAIL_LENGTH or > MAX_EMAIL_LENGTH)
        {
            errors.Add(Errors.Customer.InvalidEmailLength);
        }

        if (!Regex.IsMatch(customer.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            errors.Add(Errors.Customer.InvalidEmailFormat);
        }

        if (customer.FirstName.Length is < MIN_FIRSTNAME_LENGTH or > MAX_FIRSTNAME_LENGTH)
        {
            errors.Add(Errors.Customer.InvalidFirstNameLength);
        }

        if (customer.LastName.Length is < MIN_LASTNAME_LENGTH or > MAX_LASTNAME_LENGTH)
        {
            errors.Add(Errors.Customer.InvalidEmailLength);
        }


        return errors;
    }
}