using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Tienda_Inventario_Applicacion.DTO;
using Tienda_Inventario_Applicacion.Features.OrdenInventario.Query;
using Tienda_Inventario_Applicacion.Features.OrdenInventario.Command;

namespace TiendaInventario.WebApp.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ProductoInventarioController : Controller
    {
        private ILogger<OrdenVentaController> _logger;
        private readonly IMediator _mediator;

        public ProductoInventarioController(IMediator mediator, ILogger<OrdenVentaController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> InsertProducto([FromBody] ProductoDTO producto)
        {
            try
            {
                _logger.LogInformation("Insert producto...");
                await _mediator.Send(new InsertProductoInventarioCommand(producto));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al insertar el producto");
            }
            return BadRequest();
        
           
        }

        [HttpGet]
        [Route("{guid:Guid}")]
        public async Task<IActionResult> GetProductoById(Guid guid)
        {
            try
            {
                _logger.LogInformation("Obteniendo producto por Id...");
                ProductoDTO obj = await _mediator.Send(new GetProductoByIdQuery(guid));
                return Ok(obj); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al querer traer el producto por Id");
            }
            return BadRequest();
        }


        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                _logger.LogInformation("Obteniendo productos...");
                List<ProductoDTO> list = await _mediator.Send(new GetAllProductoInventarioQuery());

                return Ok(new
                {
                    productosDTO = list
                }); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al querer traer la lista de los productos");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducto([FromBody] ProductoDTO producto)
        {
            try
            {
                _logger.LogInformation("Actualizando producto...");
                await _mediator.Send(new UpdateProductoCommand(producto));

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al querer actualizar el producto");
            }
            return BadRequest();
        }


        [HttpDelete]
        [Route("{guid:Guid}")]
        public async Task<IActionResult> DeleteProducto(Guid guid)
        {
            try
            {
                _logger.LogInformation("Elimando producto...");
                await _mediator.Send(new DeleteProductoCommand(guid));

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al querer eliminar el producto");
            }
            return BadRequest();
        }

    }

}
