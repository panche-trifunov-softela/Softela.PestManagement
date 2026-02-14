var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Softela_PestManagement_API>("api")
    .WithExternalHttpEndpoints();

builder.Build().Run();
