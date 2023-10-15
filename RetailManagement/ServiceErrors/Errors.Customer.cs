using ErrorOr;

namespace RetailManagement.ServiceErrors;

public static class Errors
{
    public static class Customer
    {
        public static Error InvalidUsernameLength => Error.Validation(
            code: "Customer.Username",
            description: $"Username must be atleast {Models.Customer.MIN_USERNAME_LENGTH} long and at most {Models.Customer.MAX_USERNAME_LENGTH} long."
        );

        public static Error InvalidEmailLength => Error.Validation(
            code: "Customer.Email",
            description: $"Email must be atleast {Models.Customer.MIN_EMAIL_LENGTH} long and at most {Models.Customer.MAX_EMAIL_LENGTH} long."
        );

        public static Error InvalidEmailFormat => Error.Validation(
           code: "Customer.Email",
           description: "Email is not valid."
       );

        public static Error InvalidFirstNameLength => Error.Validation(
           code: "Customer.FirstName",
           description: $"Email must be atleast {Models.Customer.MIN_FIRSTNAME_LENGTH} long and at most {Models.Customer.MAX_FIRSTNAME_LENGTH} long."
       );

        public static Error InvalidLastNameLength => Error.Validation(
            code: "Customer.LastName",
            description: $"Email must be atleast {Models.Customer.MIN_LASTNAME_LENGTH} long and at most {Models.Customer.MAX_LASTNAME_LENGTH} long."
        );

        public static Error FailedToCreateCustomer => Error.Unexpected(
           code: "Customer.DatabaseErr",
           description: "Failed to create the customer!"
       );
    }
}