using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_Applicacion.DTO;

namespace Tienda_Inventario_Applicacion.Features.OrdenInventario.Command
{
    public class UpdateOrdenVentaCommand : IRequest<VoidResult>
    {

        public OrdenVentaDTO OrdenVentaDTO { get; set; }

        public UpdateOrdenVentaCommand(OrdenVentaDTO ordenVentaDto)
        {
            OrdenVentaDTO = ordenVentaDto;
        }
    }
}

