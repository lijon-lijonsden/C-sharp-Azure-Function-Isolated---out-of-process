using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configuration) =>
    {
        configuration.Sources.Clear();

        IHostEnvironment env = hostingContext.HostingEnvironment;

        configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

        IConfigurationRoot configurationRoot = configuration.Build();
    })
    .ConfigureServices((context, services) =>
    {
        services.AddOptions();

        var configurationRoot = context.Configuration;
        services.Configure<op_function.Models.Options.AppSettings>(
            configurationRoot.GetSection(nameof(op_function.Models.Options.AppSettings)));

    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run(); 