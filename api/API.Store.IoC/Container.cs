using API.Store.Application;
using API.Store.Database.Contexts;
using API.Store.Database.Repositories;
using API.Store.Domain.Interfaces.Repositories;
using API.Store.Domain.Interfaces.Services;
using API.Store.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Store.IoC
{
    public static class Container
    {
        public static void Registrar(this IServiceCollection services)
        {
            //DbContext 
            services.AddDbContext<StoreDbContext>(opt => opt.UseInMemoryDatabase("store"));

            //Repositories 
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            //Services 
            services.AddScoped<IPedidoService, PedidoService>();

            //Application
            services.AddScoped<IPedidoApplication, PedidoApplication>();
        }
    }
}