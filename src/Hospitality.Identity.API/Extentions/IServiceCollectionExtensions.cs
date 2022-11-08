namespace Hospitality.Identity.API.Extentions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCustomAzureKeyVault(this ConfigurationManager configuration)
            => configuration.AddAzureKeyVault(new SecretClient(new Uri(configuration["KeyVaultConfig:KVUrl"]),
                new ClientSecretCredential(configuration["KeyVaultConfig:TenantId"], configuration["KeyVaultConfig:ClientId"],
                    configuration["KeyVaultConfig:ClientSecretId"])), new AzureKeyVaultConfigurationOptions());
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(configuration["connectionstringIdentity"]));
        }
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ILogInService, LogInServicert>();
            services.AddTransient<IDoctorService, DoctorService>();
            var mapConfig = new MapperConfiguration(c =>
            {
                c.AddProfile(new UserModelProfile());
            });

            services.AddSingleton(mapConfig.CreateMapper());
        }
        public static void AddCustomMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlerMiddleware>();
        }
        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }
        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidIssuer = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
        }

        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<IdentityContext>();
        }
    }
}
