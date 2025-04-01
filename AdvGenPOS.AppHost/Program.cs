var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AdvGenPOS_ApiService>("apiservice");

builder.AddProject<Projects.AdvGenPOS_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
