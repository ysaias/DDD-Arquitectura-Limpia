using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda_Inventario_Applicacion.DTO
{
    public class ProductoDTO
    {
        public Guid Id { get; set; }

        public string Nombre{ get; set; }
        public string Precio { get; set; }
        public string Cantidad { get; set; }


       
    }
}
