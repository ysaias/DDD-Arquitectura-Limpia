using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda_Inventario_Domain.Model.Servicio
{
    public enum EstadoOrdenVenta
    {
        Pendiente = 1,
        ListoParaDespacho = 2,
        Despachado = 3,
        Anulado = 4
    }
}
