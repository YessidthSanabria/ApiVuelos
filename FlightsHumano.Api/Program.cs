using FlightsHumano.Api.Filters;
using FlightsHumano.Api.Middleware;
using FlightsHumano.Domain.Ports;
using FlightsHumano.Domain.Services;
using FlightsHumano.Infrastructure.Adapters;
using FlightsHumano.Infrastructure.DataSource;
using FlightsHumano.Infrastructure.Extensions;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prometheus;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);

builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseNpgsql(config.GetConnectionString("db"));
});

builder.Services.AddHealthChecks()
    .AddDbContextCheck<DataContext>()
    .ForwardToPrometheus();

builder.Services.AddDomainServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.Load("FlightsHumano.Application"), typeof(Program).Assembly);
builder.Services.AddAutoMapper(Assembly.Load("FlightsHumano.Application"));

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MessageBrokerConsumerService>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("outbox-message-queue", e =>
        {
            e.ConfigureConsumer<MessageBrokerConsumerService>(context);
        });
    });
});

builder.Services.AddScoped<IOutboxRepository, OutboxRepository>();
builder.Services.AddScoped<MessageBrokerPublishService>();
builder.Services.AddHostedService<MessageBrokerPublishService>();

builder.Services.AddScoped<IEmailService, SendGridEmailService>();




builder.Host.UseSerilog((_, loggerConfiguration) =>
    loggerConfiguration
        .WriteTo.Console()
        .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(config.GetValue<string>("esUrl")!))
        {
            TypeName = null,
            ModifyConnectionSettings = cx => cx.ServerCertificateValidationCallback((_, _, _, _) => true),
            AutoRegisterTemplate = true,
            IndexFormat = "dotnet-ms-{0:yyyy-MM-dd}",
        }));

SelfLog.Enable(Console.Error);






var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();    
    app.UseSwaggerUI(appBuilder => appBuilder.SwaggerEndpoint("/swagger/v1/swagger.json", "FlightsHumano"));
}

app.UseHttpsRedirection();

app.UseHttpMetrics();

app.UseMiddleware<AppExceptionHandlerMiddleware>();

app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

app.UseRouting().UseEndpoints(endpoint =>
{
    endpoint.MapMetrics();
});

app.MapControllers();
//app.MapGroup("/api/voter").MapVoter().AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory);

app.Run();

