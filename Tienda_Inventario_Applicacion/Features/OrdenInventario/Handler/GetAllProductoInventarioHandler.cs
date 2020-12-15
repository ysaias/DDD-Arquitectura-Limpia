using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda_Inventario_Applicacion.Persistence.Repository;
using Tienda_Inventario_Applicacion.DTO;
using Tienda_Inventario_Applicacion.Features.OrdenInventario.Query;

namespace Tienda_Inventario_Applicacion.Features.OrdenInventario.Handler
{
    public class GetAllProductoInventarioHandler : IRequestHandler<GetAllProductoInventarioQuery, List<ProductoDTO>>
    {
        private readonly IProductoRepository _productoRepository;

        public GetAllProductoInventarioHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<List<ProductoDTO>> Handle(GetAllProductoInventarioQuery request, CancellationToken cancellationToken)
        {
            List<Tienda_Inventario_Domain.Model.Servicio.Producto> listOfProductos= 
                await _productoRepository.GetAll();

            List<ProductoDTO> resultingList = new List<ProductoDTO>();

            foreach (var item in listOfProductos)
            {

                resultingList.Add(new ProductoDTO()
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Precio = item.Precio,
                    Cantidad = item.Cantidad
                }) ;
            }

            return resultingList;
        }
    }
}
