using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_Applicacion.DTO;

namespace Tienda_Inventario_Applicacion.Features.OrdenInventario.Query
{
    public class GetAllOrdenVentaInventarioQuery : IRequest<List<OrdenVentaDTO>>
    {

    }
}
