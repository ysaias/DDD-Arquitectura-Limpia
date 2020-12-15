using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda_Inventario_Applicacion.DTO
{
    public class OrdenVentaDTO
    {
        public Guid Id { get; set; }
        public string CodigoFactura { get; set; }

        public string Estado { get; set; }
        public List<ProductoPedidoDTO> ProductoItems { get; set; }

        public OrdenVentaDTO()
        {
            ProductoItems = new List<ProductoPedidoDTO>();
        }
    }
}
