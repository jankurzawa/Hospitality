namespace HostedService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomAzureKeyVault(this ConfigurationManager configuration)
            => configuration.AddAzureKeyVault(new SecretClient(new Uri(configuration["KeyVaultConfig:KVUrl"]),
                new ClientSecretCredential(configuration["KeyVaultConfig:TenantId"], configuration["KeyVaultConfig:ClientId"],
                    configuration["KeyVaultConfig:ClientSecretId"])), new AzureKeyVaultConfigurationOptions());
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddHostedService<AzureExaminationConsumer>();
            services.AddTransient<IExaminationPublisher, AzureExaminationPublisher>();
            services.AddTransient<IExaminationExecution, ExaminationExecution>();
        }
        public static void AddCustomMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlerMiddleware>();
        }
    }
}
