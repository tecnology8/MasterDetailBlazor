using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MasterDetailBlazor.Server.Models;
using Microsoft.EntityFrameworkCore;
using MasterDetailBlazor.Shared;

namespace MasterDetailBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly DbpruebaContext _context;
        public VentaController(DbpruebaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(VentaDTO ventaDTO)
        {
            try
            {
                var model = new Venta();
                var detalleVenta = new List<DetalleVenta>();
                model.Cliente = ventaDTO.Cliente;
                model.Total = ventaDTO.Total;

                foreach (var item in ventaDTO.DetalleVenta)
                {
                    detalleVenta.Add(new DetalleVenta
                    {
                        IdProducto = item.IdProducto,
                        Cantidad = item.Cantidad,
                        SubTotal = item.SubTotal
                    });
                }

                model.DetalleVenta = detalleVenta;

                _context.Venta.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}