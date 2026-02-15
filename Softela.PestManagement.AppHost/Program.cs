var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql");

var db = sql.AddDatabase("pestmanagement");

var keycloak = builder.AddKeycloak("keycloak", 8080)
    .WithRealmImport("./KeycloakConfiguration");

builder.AddProject<Projects.Softela_PestManagement_API>("api")
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

builder.Build().Run();
