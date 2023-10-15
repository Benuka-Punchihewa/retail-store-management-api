using ErrorOr;

namespace RetailManagement.ServiceErrors;

public static class Errors
{
    public static class Customer
    {
        public static Error InvalidUsernameLength => Error.Validation(
            code: "Username",
            description: $"Username must be atleast {Models.Customer.MIN_USERNAME_LENGTH} long and at most {Models.Customer.MAX_USERNAME_LENGTH} long."
        );

        public static Error InvalidEmailLength => Error.Validation(
            code: "Email",
            description: $"Email must be atleast {Models.Customer.MIN_EMAIL_LENGTH} long and at most {Models.Customer.MAX_EMAIL_LENGTH} long."
        );

        public static Error InvalidEmailFormat => Error.Validation(
           code: "Email",
           description: "Email is not valid."
       );

        public static Error InvalidFirstNameLength => Error.Validation(
           code: "FirstName",
           description: $"Email must be atleast {Models.Customer.MIN_FIRSTNAME_LENGTH} long and at most {Models.Customer.MAX_FIRSTNAME_LENGTH} long."
       );

        public static Error InvalidLastNameLength => Error.Validation(
            code: "LastName",
            description: $"Email must be atleast {Models.Customer.MIN_LASTNAME_LENGTH} long and at most {Models.Customer.MAX_LASTNAME_LENGTH} long."
        );
    }
}