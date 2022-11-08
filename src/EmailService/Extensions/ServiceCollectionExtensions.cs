namespace EmailService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomAzureKeyVault(this ConfigurationManager configuration)
            => configuration.AddAzureKeyVault(new SecretClient(new Uri(configuration["KeyVaultConfig:KVUrl"]),
                new ClientSecretCredential(configuration["KeyVaultConfig:TenantId"], configuration["KeyVaultConfig:ClientId"],
                    configuration["KeyVaultConfig:ClientSecretId"])), new AzureKeyVaultConfigurationOptions());
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddHostedService<AzureEmailHostedServiceConsumer>();
            services.AddTransient<IEmailSender, EmailSender>();
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
    }
    }
