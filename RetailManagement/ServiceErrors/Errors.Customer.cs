using ErrorOr;
using RetailManagement.Utils.Customers;

namespace RetailManagement.ServiceErrors;

public static class Errors
{
    public static class Customer
    {
        public static Error InvalidUsernameLength => Error.Validation(
            code: "Customer.Username",
            description: $"Username must be atleast {CustomerUtil.MIN_USERNAME_LENGTH} long and at most {CustomerUtil.MAX_USERNAME_LENGTH} long."
        );

        public static Error InvalidEmailLength => Error.Validation(
            code: "Customer.Email",
            description: $"Email must be atleast {CustomerUtil.MIN_EMAIL_LENGTH} long and at most {CustomerUtil.MAX_EMAIL_LENGTH} long."
        );

        public static Error InvalidEmailFormat => Error.Validation(
           code: "Customer.Email",
           description: "Email is not valid."
       );

        public static Error InvalidFirstNameLength => Error.Validation(
           code: "Customer.FirstName",
           description: $"Email must be atleast {CustomerUtil.MIN_FIRSTNAME_LENGTH} long and at most {CustomerUtil.MAX_FIRSTNAME_LENGTH} long."
       );

        public static Error InvalidLastNameLength => Error.Validation(
            code: "Customer.LastName",
            description: $"Email must be atleast {CustomerUtil.MIN_LASTNAME_LENGTH} long and at most {CustomerUtil.MAX_LASTNAME_LENGTH} long."
        );

        public static Error FailedToCreateCustomer => Error.Unexpected(
           code: "Customer.DatabaseErr",
           description: "Failed to create the customer."
       );

        public static Error CustomerNotFound => Error.NotFound(
            code: "Customer.DatabaseErr",
            description: "Customer not found."
        );

        public static Error FailedToUpdateCustomer => Error.Unexpected(
           code: "Customer.DatabaseErr",
           description: "Failed to update the customer."
       );

        public static Error FailedToDeleteCustomer => Error.Unexpected(
            code: "Customer.DatabaseErr",
            description: "Failed to delete the customer."
        );
    }
}