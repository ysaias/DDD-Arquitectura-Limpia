using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_SharedKernel.Core;

namespace Tienda_Inventario_Domain.Model.Servicio.Id
{
    public class OrdenVentaId : TypedIdValueBase
    {
        public OrdenVentaId(Guid value) : base(value)
        {
        }
    }
}
