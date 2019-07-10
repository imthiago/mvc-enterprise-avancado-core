using AutoMapper;
using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.Services;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Interfaces.Services;
using EP.CursoMvc.Domain.Services;
using EP.CursoMvc.Infra.Data.Context;
using EP.CursoMvc.Infra.Data.Interfaces;
using EP.CursoMvc.Infra.Data.Repository;
using EP.CursoMvc.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace EP.CursoMvc.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(Mapper.Configuration);
            services.AddSingleton<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // APP
            services.AddScoped<IClienteAppService, ClienteAppService>();

            // Domain
            services.AddScoped<IClienteService, ClienteService>();

            // Infra - Data
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CursoMvcContext>();
        }
    }
}