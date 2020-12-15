using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_Domain.Model.Servicio;
using Tienda_Inventario_Infraestructura.EntityConfiguration;

namespace Tienda_Inventario_Infraestructura.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Producto>  Productos { get; private set; }
        public DbSet<OrdenVenta> OrdenVentas { get; private set; }
        public DbSet<ProductoPedido> ProductoPedidos { get; private set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrdenVentaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductoPedidosEntityTypeConfiguration());


        }
    }
}
