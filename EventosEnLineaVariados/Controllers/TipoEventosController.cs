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
    public class TipoEventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoEventosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEvento>>> GetTipoEventos()
        {
            return await _context.TipoEventos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEvento>> GetTipoEvento(int id)
        {
            var tipoEvento = await _context.TipoEventos.FindAsync(id);

            if (tipoEvento == null)
                return NotFound();

            return tipoEvento;
        }

        [HttpPost]
        public async Task<ActionResult<TipoEvento>> CreateTipoEvento(TipoEvento tipoEvento)
        {
            _context.TipoEventos.Add(tipoEvento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoEvento), new { id = tipoEvento.Id }, tipoEvento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoEvento(int id, TipoEvento tipoEvento)
        {
            if (id != tipoEvento.Id)
                return BadRequest();

            _context.Entry(tipoEvento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoEvento(int id)
        {
            var tipoEvento = await _context.TipoEventos.FindAsync(id);
            if (tipoEvento == null)
                return NotFound();

            _context.TipoEventos.Remove(tipoEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
