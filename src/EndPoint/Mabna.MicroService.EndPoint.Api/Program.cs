using Mabna.MicroService.ApplicationService.Query.Instruments;
using Mabna.MicroService.Contract.Query.Instruments;
using Mabna.MicroService.Query.Entities;
using Mabna.MicroService.Query.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("QueryConnectionString")!;
builder.Services.AddDbContext<MersaairCrowdfindingTestContext>(x =>
{
    x.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<IInstrumentQueryRepository, InstrumentQueryRepository>();
builder.Services.AddMediatR(typeof(GetInstrumentsWithLastDateRequest).GetTypeInfo().Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
