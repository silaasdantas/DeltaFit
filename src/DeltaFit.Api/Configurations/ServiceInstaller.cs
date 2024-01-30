using DeltaFit.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Scrutor;

namespace DeltaFit.Api.Configurations
{
    public class ServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(AssemblyReference.Assembly);

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("DeltaFit");
            });

            services
                  .Scan(
                      selector => selector
                          .FromAssemblies(
                             AssemblyReference.Assembly)
                          .AddClasses(false)
                          .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                          .AsMatchingInterface()
                          .WithScopedLifetime());

           
           
        }
    }
}
