using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;


namespace Common.Web
{
    public class Webhost
    {
        public static IWebHostBuilder CreateDefaultBuilder(string[] args)
        {
            var builder = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    if (env.IsDevelopment())
                    {
                        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                        if (appAssembly != null)
                        {
                            config.AddUserSecrets(appAssembly, optional: true);
                        }
                    }

                    config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                })
                //.UseIISIntegration()
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                });

            if (args != null)
            {
                builder.UseConfiguration(new ConfigurationBuilder().AddCommandLine(args).Build());
            }

            return builder;
        }

        //internal static void ConfigureWebDefaults(IWebHostBuilder builder)
        //{
        //    builder.UseKestrel((builderContext, options) =>
        //    {
        //        options.Configure(builderContext.Configuration.GetSection("Kestrel"));
        //    })
        //    .ConfigureServices((hostingContext, services) =>
        //    {
        //        // Fallback
        //        services.PostConfigure<HostFilteringOptions>(options =>
        //        {
        //            if (options.AllowedHosts == null || options.AllowedHosts.Count == 0)
        //            {
        //                // "AllowedHosts": "localhost;127.0.0.1;[::1]"
        //                var hosts = hostingContext.Configuration["AllowedHosts"]?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        //                // Fall back to "*" to disable.
        //                options.AllowedHosts = (hosts?.Length > 0 ? hosts : new[] { "*" });
        //            }
        //        });
        //        // Change notification
        //        services.AddSingleton<IOptionsChangeTokenSource<HostFilteringOptions>>(
        //                    new ConfigurationChangeTokenSource<HostFilteringOptions>(hostingContext.Configuration));

        //        services.AddTransient<IStartupFilter, HostFilteringStartupFilter>();

        //        if (string.Equals("true", hostingContext.Configuration["ForwardedHeaders_Enabled"], StringComparison.OrdinalIgnoreCase))
        //        {
        //            services.Configure<ForwardedHeadersOptions>(options =>
        //            {
        //                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        //                // Only loopback proxies are allowed by default. Clear that restriction because forwarders are
        //                // being enabled by explicit configuration.
        //                options.KnownNetworks.Clear();
        //                options.KnownProxies.Clear();
        //            });

        //            services.AddTransient<IStartupFilter, ForwardedHeadersStartupFilter>();
        //        }

        //        services.AddRouting();
        //    })
        //    .UseIIS()
        //    .UseIISIntegration();
        //}

    }
}
