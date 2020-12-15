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
    public class DespachadoByIdHandler : IRequestHandler<DespachadoCommand, VoidResult>
    {
       
        private readonly IOrdenVentaRepository _ordenVentaRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DespachadoByIdHandler(IOrdenVentaRepository ordenVentaRepository, IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            _ordenVentaRepository = ordenVentaRepository;
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(DespachadoCommand request, CancellationToken cancellationToken)
        {

            Tienda_Inventario_Domain.Model.Servicio.OrdenVenta obj = await _ordenVentaRepository.GetOrdenVentaByIdyListProductos(request.OrdenVentaDto);

            List<Tienda_Inventario_Domain.Model.Servicio.ProductoPedido> productosPedidos = new List<Tienda_Inventario_Domain.Model.Servicio.ProductoPedido>(obj.ProductoPedidos);
            
            foreach (var item in productosPedidos)
            {
                
                Guid guid = new Guid(item.Producto_Id.ToString());
                Tienda_Inventario_Domain.Model.Servicio.Producto objProducto =  await _productoRepository.GetProductoBiId(guid);

                var cantidad =  int.Parse(objProducto.Cantidad.Value.ToString());
                var cantidadPedida = int.Parse( item.Cantidad);
                var cantActualizada = cantidad - cantidadPedida;
                string cantidadActualizada = cantActualizada.ToString();

                objProducto.ActualizarCantidad(cantidadActualizada);

                 await _ordenVentaRepository.UpdateProducto(objProducto);
              
            }

            Tienda_Inventario_Domain.Model.Servicio.OrdenVenta objOrden = await _ordenVentaRepository.GetOrdenVentaByIdy(obj.Id);

            objOrden.Despachado();

            await _ordenVentaRepository.UpdateOrdenVenta(objOrden);

            await _unitOfWork.Commit(cancellationToken);

            return new VoidResult();
        }
    }
}
