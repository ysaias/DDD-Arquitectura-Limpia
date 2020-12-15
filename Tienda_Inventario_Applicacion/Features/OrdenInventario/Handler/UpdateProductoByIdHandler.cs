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
    public class UpdateProductoByIdHandler : IRequestHandler<UpdateProductoCommand, VoidResult>
    {
       
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductoByIdHandler(IProductoRepository ordenEntregaRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = ordenEntregaRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<VoidResult> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            Tienda_Inventario_Domain.Model.Servicio.Producto obj = new
                Tienda_Inventario_Domain.Model.Servicio.Producto(
                request.Producto.Id,
                request.Producto.Nombre,
                request.Producto.Precio,
                request.Producto.Cantidad
                );
            await _productoRepository.UpdateProducto(obj);

            await _unitOfWork.Commit(cancellationToken);

            return new VoidResult();
        }
    }
}
