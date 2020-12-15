using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda_Inventario_Applicacion.DTO
{
    public class ProductoPedidoDTO
    {
        public Guid Id { get; set; }
        public string Producto_Id { get; set; }
        public string Cantidad { get; set; }


    }
}
