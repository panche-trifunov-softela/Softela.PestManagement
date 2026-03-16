namespace Softela.PestManagement.Application.Dtos;

public sealed record ServiceAddressDto
{
    public int Id { get; init; }
    public int CustomerId { get; init; }
    public string ServiceAddressName { get; init; }
    public string ServiceAddressType { get; init; }
    public string Address { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Zip { get; init; }
    public string ContactName { get; init; }
    public string ContactPhone { get; init; }
    public string ContactEmail { get; init; }
    public bool IsActive { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime ModifiedAt { get; init; }
}
