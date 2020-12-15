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
    public class GetAllOrdenVentaHandler : IRequestHandler<GetAllOrdenVentaInventarioQuery, List<OrdenVentaDTO>>
    {
        private readonly IOrdenVentaRepository _ordenVentaRepository;

        public GetAllOrdenVentaHandler(IOrdenVentaRepository ordenVentaRepository)
        {
            _ordenVentaRepository = ordenVentaRepository;
        }

        public async Task<List<OrdenVentaDTO>> Handle(GetAllOrdenVentaInventarioQuery request, CancellationToken cancellationToken)
        {
            List<Tienda_Inventario_Domain.Model.Servicio.OrdenVenta> listOfOrdenVentas= 
                await _ordenVentaRepository.GetAllOrdenVenta();

            List<OrdenVentaDTO> resultingList = new List<OrdenVentaDTO>();

            foreach (var item in listOfOrdenVentas)
            {   
                List<ProductoPedidoDTO> resultingListProductoPedido = new List<ProductoPedidoDTO>();

                foreach (var productoPedido in item.ProductoPedidos)
                {
                    resultingListProductoPedido.Add(new ProductoPedidoDTO()
                    {
                        Id = productoPedido.Id,
                        Cantidad = productoPedido.Cantidad,
                        Producto_Id = productoPedido.Producto_Id
                    });
                }



                resultingList.Add(new OrdenVentaDTO()
                {
                    Id = item.Id,
                    CodigoFactura  = item.CodigoFactura,
                    Estado = item.Estado.ToString(),
                    ProductoItems = resultingListProductoPedido
                }) ;
            }

            return resultingList;
        }
    }
}
