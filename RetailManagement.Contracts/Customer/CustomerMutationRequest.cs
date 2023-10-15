namespace RetailManagement.Contracts.Customer;

public record CustomerMutationRequest(
    string Username,
    string Email,
    string FirstName,
    string LastName,
    bool IsActive
);