using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tienda_Inventario_Applicacion.Persistence;
using Tienda_Inventario_Applicacion.Persistence.Repository;
using Tienda_Inventario_Applicacion.Features.OrdenInventario.Command;
using Tienda_Inventario_Applicacion.Features.OrdenInventario.Query;
using Tienda_Inventario_Applicacion.DTO;


namespace Tienda_Inventario_Applicacion.Features.OrdenInvetario.Handler
{
    public class GetOrdenVentaByIdHandler : IRequestHandler<GetOrdenVentaByIdQuery, OrdenVentaDTO>
    {
        private readonly IOrdenVentaRepository _ordenVentaRepository;

        public GetOrdenVentaByIdHandler(IOrdenVentaRepository ordenVentaRepository)
        {
            _ordenVentaRepository = ordenVentaRepository;
        }

        public async Task<OrdenVentaDTO> Handle(GetOrdenVentaByIdQuery request, CancellationToken cancellationToken)
        {
            Tienda_Inventario_Domain.Model.Servicio.OrdenVenta ordenVenta
                = await _ordenVentaRepository.GetOrdenVentaByIdyListProductos(request.Id);

            if(ordenVenta == null)
            {
                return null ;
            }
            
            return new OrdenVentaDTO()
            {
                Id = ordenVenta.Id,
                CodigoFactura= ordenVenta.CodigoFactura             
                
            };

        }
        
    }
}
