using Calaveras.Domain.Entities;
using Cavaleras.Data.Interfaces;
using Cavaleras.Data.Repository;
using Cavaleras.Service.Interfaces;
using Cavaleras.Service.Services;
using Microsoft.Extensions.DependencyInjection;

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
            service.AddScoped<IGenericService<GenericEntity>, GenericService<GenericEntity>>();
            service.AddScoped<IGenericService<DeliveryMan>, GenericService<DeliveryMan>>();
            service.AddScoped<IGenericService<Order>, GenericService<Order>>();
            service.AddScoped<IGenericService<OrderProduct>, GenericService<OrderProduct>>();
            service.AddScoped<IGenericService<Product>, GenericService<Product>>();
            service.AddScoped<IGenericService<Store>, GenericService<Store>>();
            service.AddScoped<IGenericService<ZipCode>, GenericService<ZipCode>>();
            service.AddScoped<IGenericService<ZipCodeDeliveryPrice>, GenericService<ZipCodeDeliveryPrice>>();
            service.AddScoped<IIdentityService<User>, IdentityService<User>>();
        }

        private static void InjectRepositories(IServiceCollection service)
        {
            service.AddScoped<IGenericRepository<GenericEntity>, GenericRepository<GenericEntity>>();
            service.AddScoped<IGenericRepository<DeliveryMan>, GenericRepository<DeliveryMan>>();
            service.AddScoped<IGenericRepository<Order>, GenericRepository<Order>>();
            service.AddScoped<IGenericRepository<OrderProduct>, GenericRepository<OrderProduct>>();
            service.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            service.AddScoped<IGenericRepository<Store>, GenericRepository<Store>>();
            service.AddScoped<IGenericRepository<ZipCode>, GenericRepository<ZipCode>>();
            service.AddScoped<IGenericRepository<ZipCodeDeliveryPrice>, GenericRepository<ZipCodeDeliveryPrice>>();

            service.AddScoped<IIdentityRepository<User>, IdentityRepository<User>>(); 
        }

    }
}
