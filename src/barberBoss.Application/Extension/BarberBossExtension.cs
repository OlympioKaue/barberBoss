using barberBoss.Application.ScanAssembly;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace barberBoss.Application.Extension;

//Adicione os métodos de extensão no program
public static class BarberBossExtension
{
    public static void AddApplicationExtensions(this IServiceCollection service)
    {
        AddScope(service);
    }
    
    //Implementa as interfaces que herdam de IScanGeneric
    //Simplifica a extensão (addscoped<interface, classe>)
    private static void AddScope(this IServiceCollection service)
    {
        service.Scan(scan => scan.FromAssemblyOf<IScanGeneric>()
           .AddClasses(filter => filter.AssignableTo<IScanGeneric>())
           .AsImplementedInterfaces()
           .WithScopedLifetime());
    }
}
