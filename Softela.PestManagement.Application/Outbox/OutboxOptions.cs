namespace Softela.PestManagement.Application.Outbox;

public sealed class OutboxOptions
{
    public const string SectionName = "Outbox";

    public int IntervalSeconds { get; set; } = 10;
    public int BatchSize { get; set; } = 20;
    public int StalenessWindowMinutes { get; set; } = 5;
}
