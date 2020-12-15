using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_SharedKernel.Core;

namespace Tienda_Inventario_Domain.Model.Servicio.Id
{
    class ProductoId : TypedIdValueBase
    {
        public ProductoId(Guid value) : base(value)
        {
        }
    }
}
