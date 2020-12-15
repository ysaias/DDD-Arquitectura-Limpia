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
    public class DeleteOrdenVentaHandler : IRequestHandler<DeleteOrdenVentaCommand, VoidResult>
    {
        private readonly IOrdenVentaRepository _ordenVentaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrdenVentaHandler(IOrdenVentaRepository ordenVentaRepository, IUnitOfWork unitOfWork)
        {
            _ordenVentaRepository = ordenVentaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(DeleteOrdenVentaCommand request, CancellationToken cancellationToken)
        {
            await _ordenVentaRepository.OrdenVentaDelete(request.Id);

            //await _ordenVentaRepository.DeProductoDelete(request.Id);

            await _unitOfWork.Commit(cancellationToken);

            return new VoidResult();

        }


    }
}
