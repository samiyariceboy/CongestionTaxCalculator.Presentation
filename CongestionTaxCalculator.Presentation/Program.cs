using Autofac.Extensions.DependencyInjection;
using Autofac;
using CongestionTaxCalculator.Application.Registeration;
using SeatReserver.Movie.Application.Registeration;
using static VoipService.Api.Configuration.AutofacConfigurationExtensions;
using CongestionTaxCalculator.Domain.Common;
using VoipService.Api.Configuration;
using CongestionTaxCalculator.Application.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterFluentValidation();
builder.Services.RegisterMediatR(typeof(IEntity).Assembly, typeof(Program).Assembly);
builder.Services.RegisterApiVersioning();
builder.Services.RegisterCustomSwagger(builder.Configuration);


//set autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>
(builder => builder.RegisterModule(new ServiceModules()));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.SeedDatabase(builder.Environment);
app.UseCustomSwaggerUI();

app.MapControllers();

app.Run();
