var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddCustomAzureKeyVault();
builder.Services.AddControllers();
builder.Configuration.AddEnvironmentVariables(prefix: "EMAIL_");

builder.Services.AddCustomServices(builder.Configuration);
builder.Services.AddCustomMiddleWares();
builder.Services.AddCustomCors();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseCors();
app.Run();