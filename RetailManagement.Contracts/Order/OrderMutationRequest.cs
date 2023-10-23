namespace RetailManagement.Contracts.Order;

public record OrderMutationRequest(
    Guid ProductId,
    Guid OrderBy
);