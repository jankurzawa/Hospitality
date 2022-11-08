var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables(prefix: "PATIENT_");
builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetValue<string>("connectionStringPatient"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Configuration.AddCustomAzureKeyVault();
builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddCustomServices();
builder.Services.AddControllers();
builder.Services.AddCustomCors();
builder.Services.AddCustomMiddlewares();

var app = builder.Build();

app.UseCustomMiddlewares();
app.UseCustomHealthChecks();

if (app.Environment.EnvironmentName != "Local")
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<PatientContext>();
        context.Database.Migrate();
    }
}

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseCors();

app.Run();