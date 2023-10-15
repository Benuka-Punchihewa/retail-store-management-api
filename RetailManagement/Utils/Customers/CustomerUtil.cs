using System.Text.RegularExpressions;
using ErrorOr;
using RetailManagement.Models;
using RetailManagement.ServiceErrors;

namespace RetailManagement.Utils.Customers;

public class CustomerUtil {
    public const int MIN_USERNAME_LENGTH = 5;
    public const int MAX_USERNAME_LENGTH = 30;
    public const int MIN_EMAIL_LENGTH = 5;
    public const int MAX_EMAIL_LENGTH = 20;
    public const int MIN_FIRSTNAME_LENGTH = 2;
    public const int MAX_FIRSTNAME_LENGTH = 20;
    public const int MIN_LASTNAME_LENGTH = 2;
    public const int MAX_LASTNAME_LENGTH = 20;


    public static List<Error> Validate(Customer customer)
    {
        List<Error> errors = new();

        // validate username length
        if (customer.Username.Length is < MIN_USERNAME_LENGTH or > MAX_USERNAME_LENGTH)
        {
            errors.Add(Errors.Customer.InvalidUsernameLength);
        }

        // validate Email length
        if (customer.Email.Length is < MIN_EMAIL_LENGTH or > MAX_EMAIL_LENGTH)
        {
            errors.Add(Errors.Customer.InvalidEmailLength);
        }

        // validate Email format
        if (!Regex.IsMatch(customer.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            errors.Add(Errors.Customer.InvalidEmailFormat);
        }

        // validate firstname length
        if (customer.FirstName.Length is < MIN_FIRSTNAME_LENGTH or > MAX_FIRSTNAME_LENGTH)
        {
            errors.Add(Errors.Customer.InvalidFirstNameLength);
        }

        // validate lastname length
        if (customer.LastName.Length is < MIN_LASTNAME_LENGTH or > MAX_LASTNAME_LENGTH)
        {
            errors.Add(Errors.Customer.InvalidEmailLength);
        }

        return errors;
    }
}