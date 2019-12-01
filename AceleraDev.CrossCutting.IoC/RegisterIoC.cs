using AceleraDev.Application.ApplicationServices;
using AceleraDev.Application.Interfaces;
using AceleraDev.Data.Repositories;
using AceleraDev.Data.Repositories.Base;
using AceleraDev.Domain.Interfaces.Base;
using AceleraDev.Domain.Interfaces.Repositories;
using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AceleraDev.Domain.Services;
using AceleraDev.Domain.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace AceleraDev.CrossCutting.IoC
{
    public class RegisterIoC
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            // appServices
            serviceCollection.AddScoped<IClienteAppService, ClienteAppService>();
            serviceCollection.AddScoped<IUsuarioAppService, UsuarioAppService>();

            // services
            serviceCollection.AddScoped<IClienteService, ClienteService>();
            serviceCollection.AddScoped<IServiceBase<Usuario>, ServiceBase<Usuario>>();

            // repositories
            serviceCollection.AddScoped<IClienteRepository, ClienteRepository>();
            serviceCollection.AddScoped<IRepositoryBase<Usuario>, RepositoryBase<Usuario>>();
        }
    }
}
