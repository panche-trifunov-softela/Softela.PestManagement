namespace Softela.PestManagement.Application.Dtos;

public sealed record BillingAddressDto
{
    public string Street { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Zip { get; init; }
}
