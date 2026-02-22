namespace Softela.PestManagement.Application.Dtos;

public sealed record PhoneDto
{
    public string Type { get; init; }
    public string Number { get; init; }
}
