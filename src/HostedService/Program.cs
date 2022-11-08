var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables(prefix: "HOSTED_");
builder.Services.AddControllers();

builder.Configuration.AddCustomAzureKeyVault();
builder.Services.AddCustomServices();
builder.Services.AddCustomMiddlewares();

var app = builder.Build();
app.UseCustomMiddlewares();
app.Run();