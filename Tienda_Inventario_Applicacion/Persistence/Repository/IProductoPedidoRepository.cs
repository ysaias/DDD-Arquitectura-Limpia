using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda_Inventario_Domain.Model.Servicio;

namespace Tienda_Inventario_Applicacion.Persistence.Repository

{
    public interface IProductoPedidoRepository
    {
        Task Insert(ProductoPedido productoPedido);
        Task<ProductoPedido> GetProductoPedidoBiId(Guid productoPedidoId);

        Task<List<ProductoPedido>> GetAllByOrdenVentaId(Guid ordenVentaId);

        Task ProductoPedidoDelete(Guid productopPedidoId);

        Task UpdateProductoPedido(ProductoPedido productoPedido);

    }
}
