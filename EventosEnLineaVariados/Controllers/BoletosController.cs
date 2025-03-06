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
    public class BoletosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BoletosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boleto>>> GetBoletos()
        {
            return await _context.Boletos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Boleto>> GetBoleto(int id)
        {
            var boleto = await _context.Boletos.FindAsync(id);

            if (boleto == null)
                return NotFound();

            return boleto;
        }

        [HttpPost]
        public async Task<ActionResult<Boleto>> CreateBoleto(Boleto boleto)
        {
            _context.Boletos.Add(boleto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBoleto), new { id = boleto.Id }, boleto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoleto(int id, Boleto boleto)
        {
            if (id != boleto.Id)
                return BadRequest();

            _context.Entry(boleto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoleto(int id)
        {
            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto == null)
                return NotFound();

            _context.Boletos.Remove(boleto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarBoletos(string? descripcion, string? tipoBoleto, decimal? precio)
        {
            var boletos = await _context.Boletos
                .Where(b => (descripcion == null || b.Descripcion.Contains(descripcion)) &&
                            (tipoBoleto == null || b.TipoBoleto.Contains(tipoBoleto)) &&
                            (precio == null || b.Precio == precio))
                .ToListAsync();
            return Ok(boletos);
        }
    }
}
