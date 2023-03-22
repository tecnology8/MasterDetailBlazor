using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MasterDetailBlazor.Server.Models;
using Microsoft.EntityFrameworkCore;
using MasterDetailBlazor.Shared;

namespace MasterDetailBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly DbpruebaContext _context;
        public ProductoController(DbpruebaContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var lista = new List<ProductoDTO>();

            foreach (var item in await _context.Productos.ToListAsync())
            {
                lista.Add(new ProductoDTO
                {
                    IdProducto = item.IdProducto,
                    Nombre = item.Nombre,
                    Precio = item.Precio,
                });
            }

            return Ok(lista);
        }
    }
}
