using FluentValidation;

namespace DeltaFit.Api.Configurations;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        // services.AddMediatR(Application.AssemblyReference.Assembly);

        // services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPiepelineBehavior<,>));
        //
        // services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        // services.Decorate(typeof(INotificationHandler<>), typeof(IdempotentDomainEventHandler<>));

        services.AddValidatorsFromAssembly(
            Application.AssemblyReference.Assembly,
            includeInternalTypes: true);
    }
}