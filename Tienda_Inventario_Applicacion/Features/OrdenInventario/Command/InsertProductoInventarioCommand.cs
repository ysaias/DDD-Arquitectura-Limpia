﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_Applicacion.DTO;

namespace Tienda_Inventario_Applicacion.Features.OrdenInventario.Command
{
    public class InsertProductoInventarioCommand : IRequest<VoidResult>
    {

        public ProductoDTO Producto { get; set; }

        public InsertProductoInventarioCommand(ProductoDTO productoDto)
        {
            Producto = productoDto;
        }
    }
}
