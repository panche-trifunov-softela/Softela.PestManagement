var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql");

var db = sql.AddDatabase("pestmanagement");

var keycloak = builder.AddKeycloak("keycloak", 8080)
    .WithRealmImport("./KeycloakConfiguration");

var api = builder.AddProject<Projects.Softela_PestManagement_API>("api")
    .WithEndpoint("http", e =>
    {
        e.Port = 5250;
        e.IsProxied = false;
    })
    .WithExternalHttpEndpoints()
    .WithReference(db)
    .WithReference(keycloak)
    .WaitFor(db)
    .WaitFor(keycloak);

builder.AddNpmApp("react-app", @"C:\Users\trajk\source\repos\Bugworx\react-app", "dev:aspire")
    .WithHttpEndpoint(port: 5173, isProxied: false)
    .WithExternalHttpEndpoints()
    .WithReference(api)
    .WithReference(keycloak);

builder.Build().Run();
