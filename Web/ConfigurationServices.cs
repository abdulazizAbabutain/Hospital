using Application;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json.Serialization;

namespace Web
{
    public static class ConfigurationServices
    {
        public static WebApplication BuildServices(this WebApplicationBuilder builder)
        {
            builder.Services.RegisterServices();
            builder.Logging.AddConsole();
            
            return builder.Build();
        }


        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddWebServices();
            services.AddApplicationServices();
            services.AddInfrastructureServices();         
            return services;
        }

        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddControllers(configure =>
            {
                configure.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson(setupAction =>
            {
                setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("HospitalAPI", new()
                {
                    Title = "Hospital API",
                    Version = "1",
                });

                var filePathWeb = Path.Combine(AppContext.BaseDirectory, "Hospital.Api.xml");
                var filePathApp = ApplicationServices.GetXmlCommintfile();
                setupAction.IncludeXmlComments(filePathWeb);
                setupAction.IncludeXmlComments(filePathApp);

            });

            services.Configure<MvcOptions>(configureOptions =>
            {
                var jsonOutPutFormatter = configureOptions.OutputFormatters
                .OfType<NewtonsoftJsonOutputFormatter>().FirstOrDefault();

                if (jsonOutPutFormatter != null)
                {
                    if (jsonOutPutFormatter.SupportedMediaTypes.Contains("text/json"))
                    {
                        jsonOutPutFormatter.SupportedMediaTypes.Remove("text/json");
                    }
                }
            });
            return services; 
        }
    }
}
