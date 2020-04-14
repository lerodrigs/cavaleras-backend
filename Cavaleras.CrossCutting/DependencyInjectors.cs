using Calaveras.Domain.Interfaces.Repositories;
using Calaveras.Domain.Interfaces.Services;
using Cavaleras.Data.Repository;
using Cavaleras.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.CrossCutting
{
    public static class DependencyInjectors
    {
        public static void Inject(IServiceCollection service)
        {
            InjectService(service);
            InjectRepositories(service);
        }

        private static void InjectService(IServiceCollection service)
        {
            service.AddScoped<IGenericService, GenericService>();
        }

        private static void InjectRepositories(IServiceCollection service)
        {
            service.AddScoped<IGenericRepository, GenericRepository>();
        }

    }
}
