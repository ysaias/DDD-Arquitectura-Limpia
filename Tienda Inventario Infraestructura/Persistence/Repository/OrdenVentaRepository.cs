using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda_Inventario_Infraestructura.Persistence;
using Tienda_Inventario_Domain.Model.Servicio;
using Tienda_Inventario_Applicacion.Persistence.Repository;
using Tienda_Inventario_Infraestructura.Persistence.Repository;

namespace Tienda_Inventario_Infraestructura
{
    public class OrdenVentaRepository : IOrdenVentaRepository
    {
        private readonly ApplicationDbContext _context;

        public OrdenVentaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrdenVenta>> GetAllOrdenVenta()
        {
            List<ProductoPedido> obj = new List<ProductoPedido>();
            List<OrdenVenta> result1 = await _context.OrdenVentas.ToListAsync();

            List<OrdenVenta> result = new List<OrdenVenta>();

            foreach (var ordenVenta in result1)
            {
                obj = await _context.ProductoPedidos.Where(x => x.OrdenVenta.Id == ordenVenta.Id).ToListAsync();

                OrdenVenta ordenVenta1 = new OrdenVenta(
                    ordenVenta.Id,
                    ordenVenta.CodigoFactura,
                    obj
                );

                result.Add(ordenVenta1);
            }
                         
            return result;
        }

        public async Task<OrdenVenta> GetOrdenVentaByIdyListProductos(Guid ordenVentaId)
        {
            OrdenVenta obj =
                await _context.OrdenVentas.Where(o => o.Id == ordenVentaId).FirstOrDefaultAsync();

            List<ProductoPedido> productoPedidos = new List<ProductoPedido>();

            productoPedidos = await _context.ProductoPedidos.Where(x => x.OrdenVenta.Id == ordenVentaId).ToListAsync();

            OrdenVenta ordenVentaById = new OrdenVenta(
                  obj.Id,
                  obj.CodigoFactura,
                  obj.Estado,
                  productoPedidos
              );

            return ordenVentaById;
        }

        public async Task<OrdenVenta> GetOrdenVentaByIdy(Guid ordenVentaId)
        {
            OrdenVenta obj =
                await _context.OrdenVentas.Where(o => o.Id == ordenVentaId).FirstOrDefaultAsync();

            return obj;
        }

        public async Task<OrdenVenta> GetOrdenVentaByFactura(string factura)
        {
            OrdenVenta obj = null;
            var ordenventas = await _context.OrdenVentas.ToListAsync(); 
            foreach(var ordenventa in ordenventas)
            {
                string p = ordenventa.CodigoFactura;
                if (p.Equals(factura))
                {
                    obj = ordenventa;
                }
            }


            return obj;

        }

        public async Task Insert(OrdenVenta ordenVenta)
        {
            await _context.OrdenVentas.AddAsync(ordenVenta);

            foreach (var productoItem in ordenVenta.ProductoPedidos)
            {
                await _context.ProductoPedidos.AddAsync(productoItem);
            }

        }

        public async Task OrdenVentaDelete(Guid ordenId)
        {
            OrdenVenta obj = await GetOrdenVentaByIdyListProductos(ordenId);
            _context.OrdenVentas.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrdenVenta(OrdenVenta ordenVenta)
        {
            _context.OrdenVentas.Update(ordenVenta);
            
        }

        public async Task UpdateEstado(Guid ordenVentaId)
        {
            //no serve a nada este medotodo
        }

        public async Task UpdateProducto(Producto producto)
        {
            _context.Productos.Update(producto);

        }

    }
}

