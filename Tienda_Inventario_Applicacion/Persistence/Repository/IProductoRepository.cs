using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda_Inventario_Domain.Model.Servicio;

namespace Tienda_Inventario_Applicacion.Persistence.Repository
{
    public interface IProductoRepository
    {
        Task Insert(Producto producto);
        Task<Producto> GetProductoBiId(Guid productoId);

        Task<List<Producto>> GetAll();

        Task ProductoDelete(Guid productoId);

        Task UpdateProducto(Producto producto);

    }
}
