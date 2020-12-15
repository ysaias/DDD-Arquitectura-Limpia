using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda_Inventario_Applicacion.DTO;

namespace Tienda_Inventario_Applicacion.Features.OrdenInventario.Query
{
    public class GetOrdenVentaByIdyFacturaQuery : IRequest<OrdenVentaDTO>
    {
        public string Factura { get; set; }

        public GetOrdenVentaByIdyFacturaQuery(string factura)
        {
            Factura = factura;
        }
    }
}
