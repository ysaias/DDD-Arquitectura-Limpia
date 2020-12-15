using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_Applicacion.Persistence;
using Tienda_Inventario_Applicacion.Persistence.Repository;
using Tienda_Inventario_Infraestructura.Persistence;
using Tienda_Inventario_Infraestructura.Persistence.Repository;

namespace Tienda_Inventario_Infraestructura
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
           this IServiceCollection services, IConfiguration configuration
           )
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(
                   configuration.GetConnectionString("DBConnectionString"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrdenVentaRepository, OrdenVentaRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IOrdenVentaRepository, OrdenVentaRepository>();
            services.AddScoped<IProductoPedidoRepository, ProductoPedidoRepository>();

            return services;
        }
    }
}
