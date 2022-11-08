var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddEnvironmentVariables(prefix: "EXAMINATION_");
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Configuration.AddCustomAzureKeyVault();
builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddCustomCors();
builder.Services.AddCustomServices();
builder.Services.AddCustomMiddleWares();
builder.Services.AddCustomHealthChecks(builder.Configuration);

var app = builder.Build();

app.UseCustomMiddlewares();
app.UseCustomHealthChecks();

if (app.Environment.EnvironmentName != "Local")
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ExaminationContext>();
        context.Database.Migrate();
    }
}

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();