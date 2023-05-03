
using AngelValdiviezoWebApi.Application.Common.Interfaces;
using AngelValdiviezoWebApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AngelValdiviezoWebApi.Persistence;
public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        //services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
        //        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddDbContext<ApplicationsDbPanaceaContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("Bd_Rrhh_Panacea")));

        services.AddDbContext<ApplicationsDbMarcacionesContext>(options => 
                    options.UseSqlServer(configuration.GetConnectionString("Bd_Marcaciones_GRIAMSE")));

        /*
        services.AddTransient(typeof(IRepositoryAsync<>),typeof(CustomRepositoryAsync<>));
        services.AddTransient(typeof(IRepositoryMarcacionesAsync<>), typeof(CustomRepositoryMarcacionesAsync<>));
        services.AddTransient<IApisConsumoAsync, ApisConsumoAsync>();
        services.AddTransient<IReportesEmpleado, ReportesEmpleadoService>();
        services.AddTransient<IHorario, HorarioService>();
        services.AddTransient<ICupoCredito, CupoCreditoService>();
        services.AddTransient<ISaldoContable, SaldoContableService>();
        services.AddTransient<IMenuSemanal, MenuSemanalService>();
        services.AddTransient<IEmpleado, EmpleadoService>();
        services.AddTransient<IFamiliares, FamiliaresService>();
        services.AddTransient<IColaborador, ColaboradorService>();
        */

        return services;
    }
}