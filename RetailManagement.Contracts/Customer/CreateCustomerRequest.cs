namespace RetailManagement.Contracts.Customer;

public record CreateCustomerRequest(
    string Username,
    string Email,
    string FirstName,
    string LastName,
    DateTime CreatedOn,
    bool IsActive
);