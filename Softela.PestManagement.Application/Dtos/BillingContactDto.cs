namespace Softela.PestManagement.Application.Dtos;

public sealed record BillingContactDto
{
    public string FirstName { get; init; }
    public string MiddleName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string[] AlternateEmails { get; init; }
    public PhoneDto[] Phones { get; init; }
}
