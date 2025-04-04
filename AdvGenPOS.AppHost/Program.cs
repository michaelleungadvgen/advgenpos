var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("pg")
                      .WithPgAdmin();

var advgenPOSdb = postgres.AddDatabase("AdvGenPOS", "AdvGenPOS");

var apiService = builder.AddProject<Projects.AdvGenPOS_ApiService>("apiservice").WithReference(advgenPOSdb);
;

builder.AddProject<Projects.AdvGenPOS_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
