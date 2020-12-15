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
    public class GetProductoByIdHandler : IRequestHandler<GetProductoByIdQuery, ProductoDTO>
    {
        private readonly IProductoRepository _prodcutoRepository;

        public GetProductoByIdHandler(IProductoRepository productoRepository)
        {
            _prodcutoRepository = productoRepository;
        }

        public async Task<ProductoDTO> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
        {
            Tienda_Inventario_Domain.Model.Servicio.Producto producto
                = await _prodcutoRepository.GetProductoBiId(request.Id);

            if(producto == null)
            {
                return null ;
            }

            return new ProductoDTO()
            {
                Id = producto.Id,
                Nombre= producto.Nombre,
                Precio = producto.Precio,
                Cantidad = producto.Cantidad
            };

                
           
        }

        
    }
}
