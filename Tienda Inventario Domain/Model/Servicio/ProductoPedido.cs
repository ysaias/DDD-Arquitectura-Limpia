using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_SharedKernel.Core;
using Tienda_Inventario_SharedKernel.ValueObjects.ValorNumber;


namespace Tienda_Inventario_Domain.Model.Servicio
{
     public class ProductoPedido : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Cantidad { get; private set; }
        public string Producto_Id { get; private set; }
        public OrdenVenta OrdenVenta { get; set; }


        public ProductoPedido(string cantidad, string producto_id, OrdenVenta ordenVenta)
        {
            CheckRule(new NotNullRule<string>(cantidad));
            CheckRule(new NotNullRule<string>(producto_id));
            CheckRule(new NotNullRule<OrdenVenta>(ordenVenta)); 

            Id = Guid.NewGuid();
            Cantidad = cantidad;
            Producto_Id = producto_id;
            OrdenVenta = ordenVenta;
        }

        public ProductoPedido(Guid id, string cantidad, string producto_id, OrdenVenta ordenVenta)
        {
            CheckRule(new NotNullRule<string>(cantidad));
            CheckRule(new NotNullRule<string>(producto_id));
            CheckRule(new NotNullRule<OrdenVenta>(ordenVenta));

            Id = id;
            Cantidad = cantidad;
            Producto_Id = producto_id;
            OrdenVenta = ordenVenta;
        }

        protected ProductoPedido() { }
    }
}
