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
    public class ProductoPedidoRepository : IProductoPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoPedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoPedido>> GetAllByOrdenVentaId(Guid ordenVentaId)
        {
            List<ProductoPedido> productos = await _context.ProductoPedidos.Where(o => o.OrdenVenta.Id == ordenVentaId ).ToListAsync();
            return productos;
        }

        public async Task<ProductoPedido> GetProductoPedidoBiId(Guid productoPedidoId)
        {
            ProductoPedido obj = await _context.ProductoPedidos.Where(o => o.Id == productoPedidoId).FirstOrDefaultAsync();
            return obj;
        }

        public async Task Insert(ProductoPedido productoPedido)
        {
            await _context.ProductoPedidos.AddAsync(productoPedido);
        }

        public async Task ProductoPedidoDelete(Guid productoPedidoId)
        {
            ProductoPedido obj = await GetProductoPedidoBiId(productoPedidoId);
            _context.ProductoPedidos.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductoPedido(ProductoPedido productoPedido)
        {
            _context.ProductoPedidos.Update(productoPedido);
            
        }
    }
}
