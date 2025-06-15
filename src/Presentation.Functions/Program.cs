using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) =>
    {
        var connectionString = context.Configuration.GetConnectionString("Default") ?? "Data Source=app.db";
        var infra = Assembly.Load("Infrastructure");
        var extType = infra.GetType("Infrastructure.ServiceCollectionExtensions");
        var method = extType?.GetMethod("AddInfrastructure");
        method?.Invoke(null, new object[] { services, connectionString });
    })
    .Build();

var initializer = Assembly.Load("Infrastructure").GetType("Infrastructure.DbInitializer");
var initMethod = initializer?.GetMethod("InitializeAsync");
((Task?)initMethod?.Invoke(null, new object[] { host.Services }))?.GetAwaiter().GetResult();

host.Run();
