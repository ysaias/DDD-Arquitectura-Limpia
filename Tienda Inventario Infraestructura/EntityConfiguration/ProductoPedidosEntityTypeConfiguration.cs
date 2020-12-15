using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_Domain.Model.Servicio;

namespace Tienda_Inventario_Infraestructura.EntityConfiguration
{
    class ProductoPedidosEntityTypeConfiguration : IEntityTypeConfiguration<ProductoPedido>
    {
        public void Configure(EntityTypeBuilder<ProductoPedido> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Producto_Id)
                .HasColumnName("producto_id")
                .IsRequired();

            builder.Property(x => x.Cantidad)
               .HasColumnName("cantidad")
               .IsRequired();
        }
    }
}
