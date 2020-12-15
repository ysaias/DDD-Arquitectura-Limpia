using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_Domain.Model.Servicio;

namespace Tienda_Inventario_Infraestructura.EntityConfiguration
{
    class ProductoEntityTypeConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(x => x.Id).HasName("productoId");


            builder.OwnsOne(x => x.Nombre)
                    .Property(x => x.Value)
                    .HasColumnName("nombre")
                    .IsRequired();  

            builder.OwnsOne(x => x.Precio)
                   .Property(x => x.Value)
                   .HasColumnName("precio")
                   .IsRequired();

            builder.OwnsOne(x => x.Cantidad)
                   .Property(x => x.Value)
                   .HasColumnName("cantidad")
                   .IsRequired();
        }
    }
}
