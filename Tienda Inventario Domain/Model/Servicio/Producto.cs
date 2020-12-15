using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_SharedKernel.ValueObjects.PersonName;
using Tienda_Inventario_SharedKernel.ValueObjects.ValorNumber;
using Tienda_Inventario_SharedKernel.Core; 

namespace Tienda_Inventario_Domain.Model.Servicio
{
    public class Producto : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public ProductoNameValue Nombre { get; private set; }
        public PrecioNumberValue Precio { get; private set; }
        public CantidadNumberValue Cantidad { get; private set; }


        public Producto(string nombre, string precio, string  cantidad)
        {
            CheckRule(new NotNullRule<ProductoNameValue>(nombre));
            CheckRule(new NotNullRule<PrecioNumberValue>(precio));
            CheckRule(new NotNullRule<CantidadNumberValue>(cantidad));

            Id = Guid.NewGuid();
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        public Producto(Guid id, string nombre, string precio, string cantidad)
        {
            CheckRule(new NotNullRule<ProductoNameValue>(nombre));
            CheckRule(new NotNullRule<PrecioNumberValue>(precio));
            CheckRule(new NotNullRule<CantidadNumberValue>(cantidad));

            Id = id;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        protected Producto() { }


        public void ActualizarCantidad(string cantidadPedidad)
        {

            Cantidad = cantidadPedidad;  
        }

    }
}
