
using AngelValdiviezoWebApi.Application.Common.Interfaces;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Interfaces;
using AngelValdiviezoWebApi.Application.Features.Eventos.Interfaces;
using AngelValdiviezoWebApi.Persistence.Contexts;
using AngelValdiviezoWebApi.Persistence.Repository;
using AngelValdiviezoWebApi.Persistence.Repository.Acontecimientos;
using AngelValdiviezoWebApi.Persistence.Repository.Eventos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AngelValdiviezoWebApi.Persistence;
public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        /*
        services.AddDbContext<ApplicationsDbPanaceaContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("Bd_Rrhh_Panacea")));

        services.AddDbContext<ApplicationsDbMarcacionesContext>(options => 
                    options.UseSqlServer(configuration.GetConnectionString("Bd_Marcaciones_GRIAMSE")));
        */

        #region Repositories

        services.AddTransient(typeof(IRepositoryAsync<>), typeof(CustomRepositoryAsync<>));

        //services.AddTransient(typeof(IRepositoryAsync<>), typeof(CustomRepositoryAsync<>));

        //services.AddTransient<IEventos, EventosService>();
        /*
        services.AddTransient<IOtpService, OtpService>();
        services.AddTransient<ILdapUserService, LdapUserService>();
        services.AddTransient<IApisConsumoAsync, ApisConsumoAsync>();
        */

        services.AddTransient<IAcontecimientos, AcontecimientoService>();
        //services.AddTransient<IAcontecimientos, AcontecimientoService>();
        #endregion

        return services;
    }

}