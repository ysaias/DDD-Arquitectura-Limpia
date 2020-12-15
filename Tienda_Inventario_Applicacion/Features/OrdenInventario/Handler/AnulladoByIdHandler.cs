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
    public class AnulladoByIdHandler : IRequestHandler<AnulladoCommand, VoidResult>
    {
       
        private readonly IOrdenVentaRepository _ordenVentaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AnulladoByIdHandler(IOrdenVentaRepository ordenVentaRepository, IUnitOfWork unitOfWork)
        {
            _ordenVentaRepository = ordenVentaRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<VoidResult> Handle(AnulladoCommand request, CancellationToken cancellationToken)
        {

            Tienda_Inventario_Domain.Model.Servicio.OrdenVenta obj = await _ordenVentaRepository.GetOrdenVentaByIdy(request.OrdenVentaDto);

            obj.AnularVenta();

            await _ordenVentaRepository.UpdateOrdenVenta(obj);

            await _unitOfWork.Commit(cancellationToken);

            return new VoidResult();
        }
    }
}
