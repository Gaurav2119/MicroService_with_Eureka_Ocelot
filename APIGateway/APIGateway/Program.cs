using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Eureka;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

//builder.Services.AddCustomJwtAuthentication();

builder.Services.AddOcelot(builder.Configuration)
    .AddEureka();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.MapControllers();

await app.UseOcelot();

//Add logging to troubleshoot the issue
//var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
//var logger = loggerFactory.CreateLogger("OcelotGateway");

//try
//{
//    await app.UseOcelot();
//}
//catch (Exception ex)
//{
//    logger.LogError(ex, "An error occurred while using Ocelot middleware.");
//}

app.UseAuthentication();
app.UseAuthorization();

app.Run();
