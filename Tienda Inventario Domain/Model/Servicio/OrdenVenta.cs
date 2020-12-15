using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Tienda_Inventario_SharedKernel.Core;
using Tienda_Inventario_SharedKernel.ValueObjects;
using Tienda_Inventario_SharedKernel.ValueObjects.PersonName;
using Tienda_Inventario_SharedKernel.ValueObjects.ValorNumber;
using Tienda_Inventario_Domain.Model.Servicio.Rules;

namespace Tienda_Inventario_Domain.Model.Servicio
{
    public class OrdenVenta : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public DateTime FechaRegistro { get; private set; }
        public DateTime? FechaConsolidacion { get; private set; }
        public DateTime? FechaAnulacion { get; private set; }
        public DateTime? FechaDespachado { get; private set; }
        public EstadoOrdenVenta Estado { get; private set; }
        public FacturaNameValue CodigoFactura { get; private set; }


        private List<ProductoPedido> _prodcutoPedidos;
        public ImmutableList<ProductoPedido> ProductoPedidos
        {
            get
            {
                return _prodcutoPedidos.ToImmutableList<ProductoPedido>();
            }
        }

        public OrdenVenta(string codigoFactura, Dictionary<string, string> items)
        {

            Id = Guid.NewGuid();
            FechaRegistro = DateTime.Now;
            CodigoFactura = codigoFactura;
            Estado = EstadoOrdenVenta.Pendiente;

            _prodcutoPedidos = new List<ProductoPedido>();

            foreach (var producto_id in items.Keys)
            {
                string cantidad = items[producto_id];
                ProductoPedido item = new ProductoPedido(cantidad, producto_id, this);
                _prodcutoPedidos.Add(item);
            }

        }


        public OrdenVenta(Guid id, string codigoFactura)
        {
            Id = id;
            CodigoFactura = codigoFactura;

        }

        public OrdenVenta(Guid id, string codigoFactura, EstadoOrdenVenta estado)
        {
            Id = id;
            CodigoFactura = codigoFactura;
            int cambioEstado = (int) estado;
            CambioEstado(cambioEstado);
        }

        public OrdenVenta(Guid id, string codigoFactura, List<ProductoPedido> items)
        {

            Id = id;
            FechaRegistro = DateTime.Now;
            CodigoFactura = codigoFactura;
            Estado = EstadoOrdenVenta.Pendiente;
            _prodcutoPedidos = items;

        }


        public OrdenVenta(Guid id, string codigoFactura, EstadoOrdenVenta estado, List<ProductoPedido> items)
        {

            Id = id;
            FechaRegistro = DateTime.Now;
            CodigoFactura = codigoFactura;
            Estado = estado;
            _prodcutoPedidos = items;

        }




        protected OrdenVenta() { }

        public void ConsolidarOrdenVenta()
        {
            CheckRule(new ChangeOrdenVentaStatusRule(Estado, EstadoOrdenVenta.ListoParaDespacho));
            FechaConsolidacion = DateTime.Now;
            Estado = EstadoOrdenVenta.ListoParaDespacho;
        }

        public void Despachado()
        {
            CheckRule(new ChangeOrdenVentaStatusRule(Estado, EstadoOrdenVenta.Despachado));
            FechaDespachado = DateTime.Now;
            Estado = EstadoOrdenVenta.Despachado;
        }

        public void AnularVenta()
        {
            CheckRule(new ChangeOrdenVentaStatusRule(Estado, EstadoOrdenVenta.Anulado));
            FechaAnulacion = DateTime.Now;
            Estado = EstadoOrdenVenta.Anulado;
        } 

        private void CambioEstado(int estadoOrdenVenta)
        {
            switch (estadoOrdenVenta)
            {
                
                case 2:
                    ConsolidarOrdenVenta();
                    break;
                case 3:
                    Despachado();
                    break;
                case 4:
                    AnularVenta();
                    break;
                    default:
                    break;
            }
        }

        

    }
}
