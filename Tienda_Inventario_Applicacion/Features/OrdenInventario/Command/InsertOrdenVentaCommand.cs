using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_Applicacion.DTO;

namespace Tienda_Inventario_Applicacion.Features.OrdenInventario.Command
{
    public class InsertOrdenVentaCommand : IRequest<VoidResult>
    {

        public OrdenVentaDTO OrdenVentaDTO { get; set; }

        public InsertOrdenVentaCommand(OrdenVentaDTO ordenVentaDto)
        {
            OrdenVentaDTO = ordenVentaDto;
        }
    }
}
