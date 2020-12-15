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
using Tienda_Inventario_Applicacion.Features.OrdenInventario.Command;
using Tienda_Inventario_Applicacion.Features.OrdenInventario.Query;

namespace TiendaInventario.WebApp.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class OrdenVentaController : ControllerBase
    {
        private ILogger<OrdenVentaController> _logger;
        private readonly IMediator _mediator;

        public OrdenVentaController(IMediator mediator, ILogger<OrdenVentaController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrdenVenta([FromBody] OrdenVentaDTO ordenVentaDTO)
        {
            try
            {
                _logger.LogInformation("Insert Orden de Venta...");
                OrdenVentaDTO obj = await _mediator.Send(new GetOrdenVentaByIdyFacturaQuery(ordenVentaDTO.CodigoFactura.ToString()));
                if (obj != null)
                {
                    return Ok(obj);
                }
                else
                {
                    await _mediator.Send(new InsertOrdenVentaCommand(ordenVentaDTO));

                    return Ok();
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al insert la orden de venta");
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdenVenta()
        {
            try
            {
                _logger.LogInformation("Obteniendo ordenes de Venta...");
                List<OrdenVentaDTO> list = await _mediator.Send(new GetAllOrdenVentaInventarioQuery());

                return Ok(new
                {
                    orders = list
                }); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las Ordende de Venta");
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("{guid:Guid}")]
        public async Task<IActionResult> GetOrdenVentaById(Guid guid)
        {
            try
            {
                _logger.LogInformation("Obteniendo ordene de Venta por Id...");
                OrdenVentaDTO objOrden = await _mediator.Send(new GetOrdenVentaByIdyListaProductosQuery(guid));

                return Ok(objOrden);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al traer las orden de venta por ID");
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("factura/{factura}")]
        public async Task<IActionResult> GetOrdenVentaByIdFactura(string factura)
        {
            try
            {
                _logger.LogInformation("Obteniendo ordenes de Venta por el Codigo Factura...");
                OrdenVentaDTO obj = await _mediator.Send(new GetOrdenVentaByIdyFacturaQuery(factura));

                return Ok(obj); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al traer la orden de venta por el codigo Factura ");
            }
            return BadRequest();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateOrdenVenta([FromBody] OrdenVentaDTO ordenVentaDTO)
        {
            try
            {
                _logger.LogInformation("Acualizando ordene de Venta...");
                await _mediator.Send(new UpdateOrdenVentaCommand(ordenVentaDTO));

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al querer actualizar la orden de venta");
            }
            return BadRequest();
        }


        [HttpDelete]
        [Route("{guid:Guid}")]
        public async Task<IActionResult> DeleteOrdenVenta(Guid guid)
        {
            try
            {
                _logger.LogInformation("Elimnado ordene de Venta por Id...");
                await _mediator.Send(new DeleteOrdenVentaCommand(guid));

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al querer elimminar la orden de venta");
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("listoparadespacho/{guid:Guid}")]
        public async Task<IActionResult> ListoParaDespacho( Guid guid)
        {

            try
            {
                _logger.LogInformation("Cambiando de estado a Liso Para Despacho de orden de Venta...");
                await _mediator.Send(new ListoParaDespachoCommand(guid));
                return Ok();
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "Error al querer cambiar el estado Listo para Despachar o Consolidar de la orden de venta");
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("despachado/{guid:Guid}")]
        public async Task<IActionResult> Despachado(Guid guid)
        {
            try
            {
                _logger.LogInformation("Cambiando de estado a Despachado de orden de Venta...");
                await _mediator.Send(new DespachadoCommand(guid));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al querer cambiar el estado Listo para Despachado de la orden de venta");
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("anullado/{guid:Guid}")]
        public async Task<IActionResult> Anullado(Guid guid)
        {
            try
            {
                _logger.LogInformation("Camabiando estado Anulado de orden de Venta...");
                await _mediator.Send(new AnulladoCommand(guid));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al querer cambiar el estado Eliminar de la orden de venta");
            }
      
            return BadRequest();
        }


        [HttpGet]
        [Route("hello")]
        public string Hello()
        {
            return "Hello";
        }


    }
}
