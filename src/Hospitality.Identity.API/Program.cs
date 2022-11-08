var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables(prefix: "IDENTITY_");
builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration["connectionstringIdentity"]);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Configuration.AddCustomAzureKeyVault();
builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddCustomServices();
builder.Services.AddCustomMiddlewares();
builder.Services.AddCustomCors();
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddCustomIdentity();

var app = builder.Build();

app.UseCustomHealthChecks();
app.UseCustomMiddlewares();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.EnvironmentName != "Local")
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<IdentityContext>();
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
}
app.Run();