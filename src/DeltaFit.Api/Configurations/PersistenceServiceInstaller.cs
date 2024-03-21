using DeltaFit.Persistence;
using Microsoft.EntityFrameworkCore;
using Scrutor;

namespace DeltaFit.Api.Configurations;

public class PersistenceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        //var connectionString = configuration.GetConnectionString("DefaultConnection");

        //services
        //    .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        services.AddDbContext<ApplicationDbContext>(
               //(sp, optionsBuilder) =>
               //{
               //    var outboxInterceptor = sp.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>()!;
               //    var auditableInterceptor = sp.GetService<UpdateAuditableEntitiesInterceptor>()!;

               //    optionsBuilder.UseSqlServer(connectionString)
               //        .AddInterceptors(
               //            outboxInterceptor,
               //            auditableInterceptor);
               //});
               (sp, optionsBuilder) =>
               {
                   //TODO use options pattern
                   optionsBuilder.UseSqlServer(
                       configuration.GetConnectionString("DefaultConnection"));
               });
    }
}