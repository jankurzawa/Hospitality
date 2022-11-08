var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddCustomAzureKeyVault();
builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddCustomServices();
builder.Services.AddCustomCors();

builder.Configuration.AddEnvironmentVariables(prefix: "CHECKUP_");

builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration["connectionstringCheckUpDB"]);

var app = builder.Build();

app.UseCustomMiddlewares();
app.UseCustomHealthChecks();

if (app.Environment.EnvironmentName != "Local")
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<CheckUpContext>();
        context.Database.Migrate();
    }
}
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.UseCors();

app.Run();