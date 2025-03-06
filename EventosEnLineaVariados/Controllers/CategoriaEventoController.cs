using EventosEnLineaVariados.Data;
using EventosEnLineaVariados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosEnLineaVariados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaEventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaEventosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaEvento>>> GetCategoriaEventos()
        {
            return await _context.CategoriaEventos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaEvento>> GetCategoriaEvento(int id)
        {
            var categoria = await _context.CategoriaEventos.FindAsync(id);

            if (categoria == null)
                return NotFound();

            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaEvento>> CreateCategoriaEvento(CategoriaEvento categoria)
        {
            _context.CategoriaEventos.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoriaEvento), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoriaEvento(int id, CategoriaEvento categoria)
        {
            if (id != categoria.Id)
                return BadRequest();

            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaEvento(int id)
        {
            var categoria = await _context.CategoriaEventos.FindAsync(id);
            if (categoria == null)
                return NotFound();

            _context.CategoriaEventos.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
