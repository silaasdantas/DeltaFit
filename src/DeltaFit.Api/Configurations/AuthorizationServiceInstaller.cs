namespace DeltaFit.Api.Configurations;

public class AuthorizationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("Trainer", policy => policy.RequireRole("Trainer"));
            options.AddPolicy("Student", policy => policy.RequireRole("Student"));
        });
        
        // services.AddAuthorization();
        // services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        // services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>()
    }
}