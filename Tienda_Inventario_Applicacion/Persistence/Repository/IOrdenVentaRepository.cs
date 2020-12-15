using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda_Inventario_Domain.Model.Servicio;

namespace Tienda_Inventario_Applicacion.Persistence.Repository

{
    public interface IOrdenVentaRepository
    {
        Task Insert(OrdenVenta ordenVenta);

        Task<OrdenVenta> GetOrdenVentaByIdyListProductos(Guid ordenVentaId);

        Task<List<OrdenVenta>> GetAllOrdenVenta();

        Task UpdateOrdenVenta(OrdenVenta ordenVenta);

        Task OrdenVentaDelete(Guid ordenId);

        Task UpdateEstado(Guid ordenVentaId);

        Task<OrdenVenta> GetOrdenVentaByIdy(Guid ordenVentaId);
        Task<OrdenVenta> GetOrdenVentaByFactura(string factura);
        Task UpdateProducto(Producto producto);
    }
}
