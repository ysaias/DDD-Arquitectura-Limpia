using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_Applicacion.DTO;

namespace Tienda_Inventario_Applicacion.Features.OrdenInventario.Command
{
    public class AnulladoCommand : IRequest<VoidResult>
    {

        public Guid OrdenVentaDto { get; set; }

        public AnulladoCommand(Guid ordenVentaDto)
        {
            OrdenVentaDto = ordenVentaDto;
        }
    }
}

