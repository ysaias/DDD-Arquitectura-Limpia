using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_Applicacion.DTO;

namespace Tienda_Inventario_Applicacion.Features.OrdenInventario.Command
{
    public class DeleteProductoCommand : IRequest<VoidResult>
    {
        public Guid Id { get; set; }

        public DeleteProductoCommand(Guid id)
        {
            Id = id;
        }
    }
}
