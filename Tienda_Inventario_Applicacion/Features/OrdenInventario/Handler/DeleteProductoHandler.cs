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
    public class DeleteProductoHandler : IRequestHandler<DeleteProductoCommand, VoidResult>
    {
        private readonly IProductoRepository _prodcutoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductoHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            _prodcutoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
        {
            //Tienda_Inventario_Domain.Model.Servicio.Producto Producto
            //    = await _prodcutoRepository.GetProductoBiId(request.Id);

            await _prodcutoRepository.ProductoDelete(request.Id);

            await _unitOfWork.Commit(cancellationToken);

            return new VoidResult();


        }


    }
}
