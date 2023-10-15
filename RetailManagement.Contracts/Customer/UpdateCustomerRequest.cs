namespace RetailManagement.Contracts.Customer;

public record UpdateCustomerRequest(
    string Username,
    string Email,
    string FirstName,
    string LastName,
    bool IsActive
);