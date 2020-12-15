using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda_Inventario_Applicacion.DTO;

namespace Tienda_Inventario_Applicacion.Features.OrdenInventario.Query
{
    public class GetProductoByIdQuery : IRequest<ProductoDTO>
    {
        public Guid Id { get; set; }

        public GetProductoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
