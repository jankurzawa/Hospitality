namespace Hospitality.Patient.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomAzureKeyVault(this ConfigurationManager configuration)
            => configuration.AddAzureKeyVault(new SecretClient(new Uri(configuration["KeyVaultConfig:KVUrl"]),
                new ClientSecretCredential(configuration["KeyVaultConfig:TenantId"], configuration["KeyVaultConfig:ClientId"],
                    configuration["KeyVaultConfig:ClientSecretId"])), new AzureKeyVaultConfigurationOptions());
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PatientContext>(options => options
                .UseSqlServer(configuration["connectionStringPatient"]), ServiceLifetime.Transient, ServiceLifetime.Transient);
        }
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IPatientHostedServicePublisher, AzurePatientHostedServicePublisher>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IPatientService, PatientService>();
            //services.AddHostedService<AzurePatientHostedServiceConsumer>();
           
            var mapConfig = new MapperConfiguration(c =>
            {
                c.AddProfile(new PatientProfile());
            });
            services.AddSingleton(mapConfig.CreateMapper());
        }
        public static void AddCustomMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlerMiddleware>();
        }
        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:7236/",
                            "https://localhost:7236/swagger/index.html")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
        }
    }
}
