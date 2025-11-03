using barberBoss.Infrastructure.Extension;

using barberBoss.Infrastructure.ConfigurationMigrations;
using barberBoss.Application.Extension;
using barberBoss.Api.Filter;
using barberBoss.Application.Mapster;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationExtensions();
builder.Services.AddInfrastructureExtensions(builder.Configuration);
builder.Services.AddMvc(filter => filter.Filters.Add(typeof(ExceptionsFilter)));
MapsterConfig.RegisterMappings();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await Migrations();
app.Run();

async Task Migrations()
{
    await using var scope = app.Services.CreateAsyncScope();
    await BarberBossMigrations.MigrateDataBase(scope.ServiceProvider);
}
