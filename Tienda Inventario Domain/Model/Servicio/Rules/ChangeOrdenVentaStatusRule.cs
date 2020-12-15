using System;
using System.Collections.Generic;
using System.Text;
using Tienda_Inventario_SharedKernel.Core;

namespace Tienda_Inventario_Domain.Model.Servicio.Rules
{
    public class ChangeOrdenVentaStatusRule : IBusinessRule
    {
        private readonly EstadoOrdenVenta oldStatus;
        private readonly EstadoOrdenVenta newStatus;

        public ChangeOrdenVentaStatusRule(EstadoOrdenVenta oldStatus, EstadoOrdenVenta newStatus)
        {
            this.oldStatus = oldStatus;
            this.newStatus = newStatus;
        }

        public string Message => "No se puede cambiar del estado " + oldStatus.ToString() +
            " al estado " + newStatus.ToString();

        public bool IsBroken()
        {
            if (newStatus == EstadoOrdenVenta.ListoParaDespacho && oldStatus != EstadoOrdenVenta.Pendiente)
                return true;

            if (newStatus == EstadoOrdenVenta.Anulado &&
                (oldStatus == EstadoOrdenVenta.Despachado))
                return true;

            if (newStatus == EstadoOrdenVenta.Pendiente && oldStatus != EstadoOrdenVenta.ListoParaDespacho)
                return true;

            if (newStatus == EstadoOrdenVenta.Despachado && oldStatus != EstadoOrdenVenta.ListoParaDespacho)
                return true;

            return false;
        }
    }
}
