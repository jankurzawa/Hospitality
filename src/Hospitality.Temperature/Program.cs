var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddEnvironmentVariables(prefix: "MONGO_");
builder.Services.Configure<PatientTemperaturesDatabaseSettings>(builder.Configuration.GetSection("TemperatureDatabase"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITemperaturesService, TemperaturesService>();
//builder.Configuration.AddAzureKeyVault(new SecretClient(new Uri(builder.Configuration["KeyVaultConfig:KVUrl"]), 
//    new ClientSecretCredential(builder.Configuration["KeyVaultConfig:TenantId"], builder.Configuration["KeyVaultConfig:ClientId"],
//    builder.Configuration["KeyVaultConfig:ClientSecretId"])), new AzureKeyVaultConfigurationOptions());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();