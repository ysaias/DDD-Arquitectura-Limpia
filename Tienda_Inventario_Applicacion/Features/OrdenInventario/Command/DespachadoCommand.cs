using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_Applicacion.DTO;

namespace Tienda_Inventario_Applicacion.Features.OrdenInventario.Command
{
    public class DespachadoCommand : IRequest<VoidResult>
    {

        public Guid OrdenVentaDto { get; set; }

        public DespachadoCommand(Guid ordenVentaDto)
        {
            OrdenVentaDto = ordenVentaDto;
        }
    }
}

