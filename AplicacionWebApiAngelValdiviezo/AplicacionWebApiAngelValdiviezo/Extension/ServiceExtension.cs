using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebApiAngelValdiviezo.Extension
{
    public static class ServiceExtension
    {
        public static void AddServiceExtensions(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;

            });
            //services.AddSingleton<ErrorHandlerMiddleware>();
        }
    }
}
