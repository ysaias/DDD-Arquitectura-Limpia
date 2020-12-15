using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda_Inventario_Infraestructura;
using Tienda_Inventario_Domain.Model.Servicio;
using Tienda_Inventario_Applicacion.Persistence.Repository;
using Tienda_Inventario_Infraestructura.Persistence.Repository;

namespace Tienda_Inventario_Infraestructura.Persistence.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAll()
        {
            List<Producto> productos = await _context.Productos.ToListAsync();
            return productos;
        }

        public async Task<Producto> GetProductoBiId(Guid productoId)
        {
            Producto obj = await _context.Productos.Where(o => o.Id == productoId).FirstOrDefaultAsync();
            return obj;
        }


        public async Task Insert(Producto producto)
        {
            await _context.Productos.AddAsync(producto);

        }




        public async Task ProductoDelete(Guid productoId)
        {
            Producto obj = await GetProductoBiId(productoId);
            _context.Productos.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProducto(Producto producto)
        {
           _context.Productos.Update(producto);
           
        }
    }
}
