namespace Hospitality.Examination.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomAzureKeyVault(this ConfigurationManager configuration)
            => configuration.AddAzureKeyVault(new SecretClient(new Uri(configuration["KeyVaultConfig:KVUrl"]),
                new ClientSecretCredential(configuration["KeyVaultConfig:TenantId"], configuration["KeyVaultConfig:ClientId"],
                    configuration["KeyVaultConfig:ClientSecretId"])), new AzureKeyVaultConfigurationOptions());
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExaminationContext>(options => options.UseSqlServer(configuration["connectionstringExamination"]), ServiceLifetime.Transient, ServiceLifetime.Transient);
        }
        public static void AddCustomMiddleWares(this IServiceCollection services)
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

        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IExaminationRepository, ExaminationRepository>();
            services.AddTransient<IExaminationTypesRepository, ExaminationTypesRepository>();
            services.AddTransient<IUpdateExamination, UpdateExamination>();
            services.AddTransient<IRabbitMqService, AzureQueuePublisher>();
            //services.AddHostedService<AzureQueueConsumer>();
            
        }
        public static void AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetValue<string>("EXAMINATION_SQL_CONNECTONSTRING"))
                .AddRabbitMQ(
                 "amqp://guest:guest@rabbitmq-hospitality",
                 name: "RabbitMQ",
                 failureStatus: HealthStatus.Degraded,
                 timeout: TimeSpan.FromSeconds(1),
                 tags: new string[] { "services" }
                );
        }
    }
}