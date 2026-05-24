var builder = DistributedApplication.CreateBuilder(args);

var pg = builder.AddPostgres("postgres");

var db = pg.AddDatabase("pestmanagement");

var keycloak = builder.AddKeycloak("keycloak", 8080)
    .WithDockerfile(contextPath: ".", dockerfilePath: "Dockerfile.keycloak");

var api = builder.AddProject<Projects.Softela_PestManagement_API>("api")
    .WithEndpoint("http", e =>
    {
        if (builder.ExecutionContext.IsRunMode)
        {
            e.Port = 5250;
            e.IsProxied = false;
        }
    })
    .WithExternalHttpEndpoints()
    .WithReference(db)
    .WithReference(keycloak)
    .WaitFor(db)
    .WaitFor(keycloak);

builder.AddJavaScriptApp("react-app", @"..\..\Softela.Dashboard\react-app", "dev:aspire")
    .WithHttpEndpoint(port: 5173, isProxied: false)
    .WithExternalHttpEndpoints()
    .WithReference(api)
    .WithReference(keycloak)
    .WithEnvironment("VITE_API_URL", api.GetEndpoint("http"))
    .WithEnvironment("VITE_KEYCLOAK_URL", keycloak.GetEndpoint("http"))
    .WithEnvironment("VITE_KEYCLOAK_REALM", "pestmanagement")
    .WithEnvironment("VITE_KEYCLOAK_CLIENT_ID", "pestmanagement-webapp");

builder.Build().Run();
