using barberBoss.Communication.Request.Billings;
using barberBoss.Domain.Entities;
using Mapster;

namespace barberBoss.Application.Mapster;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<RequestBillings, Billing>
            .NewConfig()
            .IgnoreNullValues(true);
    }

}
