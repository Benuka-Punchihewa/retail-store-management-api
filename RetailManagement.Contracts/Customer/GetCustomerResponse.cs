namespace RetailManagement.Contracts.Customer;

public record GetCustomerResponse(
    Guid Id,
    string Username,
    string Email,
    string FirstName,
    string LastName,
    DateTime CreatedOn,
    bool IsActive
);

