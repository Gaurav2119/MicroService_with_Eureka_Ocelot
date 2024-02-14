using CartAPI.MessageConsume;
using CartAPI.Repository;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// discovery
builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.AddMemoryCache();
builder.Services.AddHealthChecks();
builder.Services.AddSingleton<IHealthCheckHandler, ScopedEurekaHealthCheckHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICartRepo, CartRepo>();
builder.Services.AddSingleton<IConsumer, Consumer>();
builder.Services.Configure<KafkaConsumerConfig>(builder.Configuration.GetSection("KafkaConsumer"));

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

app.UseDiscoveryClient();
app.UseHealthChecks("/info");

var kafkaConsumers = app.Services.GetRequiredService<IConsumer>();
kafkaConsumers.RunInBackground();

app.Run();
