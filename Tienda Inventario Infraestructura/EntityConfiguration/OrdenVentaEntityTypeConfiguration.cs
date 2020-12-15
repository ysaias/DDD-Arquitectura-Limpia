using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_Domain.Model.Servicio;

namespace Tienda_Inventario_Infraestructura.EntityConfiguration
{
     public class OrdenVentaEntityTypeConfiguration : IEntityTypeConfiguration<OrdenVenta>
    {
        public void Configure(EntityTypeBuilder<OrdenVenta> builder)
        {
            builder
                .HasKey(x => x.Id)
                .HasName("ordenVentaId");

            builder.Property(x => x.FechaRegistro)
                .IsRequired();
          
            builder.OwnsOne(x => x.CodigoFactura)
                .Property(x => x.Value)
                .HasColumnName("codigoFactura")
                .IsRequired();

            builder.Property(x => x.Estado)
              .HasColumnName("estado")
              .IsRequired();

            builder.Ignore(x => x.ProductoPedidos);
            
        }
    }
}

