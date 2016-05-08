using System;
using System.Web.Http;
using Autofac;
using Microsoft.Owin.Hosting;
using Owin;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DiModule());
            ILifetimeScope container = null;

            using (WebApp.Start("http://localhost:8009", builder =>
            {
                container = containerBuilder.Build();

                builder.Use(async (context, next) =>
                {
                    Console.WriteLine($">> [HTTP {context.Request.Method}] {context.Request.Uri}");

                    try
                    {
                        await next();
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                        throw;
                    }
                    Console.WriteLine(
                        $"<< [HTTP {context.Response.StatusCode}] {context.Request.Uri} ({context.Response.ContentLength} bytes)");
                });

                var configuration = new HttpConfiguration();
                configuration.MapHttpAttributeRoutes();
                configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);

                builder.UseAutofacMiddleware(container);
                builder.UseAutofacWebApi(configuration);
                builder.UseWebApi(configuration);

            }))
            {

                Console.WriteLine("Started");
                Console.ReadKey();
                container?.Dispose();
            }

        }
    }
}
