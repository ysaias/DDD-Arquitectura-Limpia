using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda_Inventario_Applicacion.Persistence;
using Tienda_Inventario_Applicacion.Persistence.Repository;
using Tienda_Inventario_Applicacion.Features.OrdenInventario.Command;

namespace Tienda_Inventario_Applicacion.Features.OrdenInventario.Handler
{
    public class InsertOrdenVentaHandler : IRequestHandler<InsertOrdenVentaCommand, VoidResult>
    {
        private readonly IOrdenVentaRepository _ordenVentaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertOrdenVentaHandler(IOrdenVentaRepository ordenVentaRepository, IUnitOfWork unitOfWork)
        {
            _ordenVentaRepository = ordenVentaRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<VoidResult> Handle(InsertOrdenVentaCommand request, CancellationToken cancellationToken)
        {

            //Tienda_Inventario_Domain.Model.Servicio.OrdenVenta ordenVenta
            //     = await _ordenVentaRepository.GetOrdenVentaByFactura(request.OrdenVentaDTO.CodigoFactura.ToString());

            //if (ordenVenta != null)
            //{
                
            //    return new VoidResult();
            //}
            //else{


                Dictionary<string, string> productosPedidosItems = new Dictionary<string, string>();

                foreach (var item in request.OrdenVentaDTO.ProductoItems)
                {
                    productosPedidosItems.Add(item.Producto_Id, item.Cantidad);
                }


                Tienda_Inventario_Domain.Model.Servicio.OrdenVenta obj = new
                    Tienda_Inventario_Domain.Model.Servicio.OrdenVenta(
                      request.OrdenVentaDTO.CodigoFactura,
                      productosPedidosItems
                    );
                await _ordenVentaRepository.Insert(obj);
                await _unitOfWork.Commit(cancellationToken);

                return new VoidResult();

            //}

           
        }
    }
}
