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
    public class UbicacionBoletosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UbicacionBoletosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UbicacionBoleto>>> GetUbicacionBoletos()
        {
            return await _context.UbicacionBoletos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UbicacionBoleto>> GetUbicacionBoleto(int id)
        {
            var ubicacion = await _context.UbicacionBoletos.FindAsync(id);

            if (ubicacion == null)
                return NotFound();

            return ubicacion;
        }

        [HttpPost]
        public async Task<ActionResult<UbicacionBoleto>> CreateUbicacionBoleto(UbicacionBoleto ubicacion)
        {
            _context.UbicacionBoletos.Add(ubicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUbicacionBoleto), new { id = ubicacion.Id }, ubicacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUbicacionBoleto(int id, UbicacionBoleto ubicacion)
        {
            if (id != ubicacion.Id)
                return BadRequest();

            _context.Entry(ubicacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacionBoleto(int id)
        {
            var ubicacion = await _context.UbicacionBoletos.FindAsync(id);
            if (ubicacion == null)
                return NotFound();

            _context.UbicacionBoletos.Remove(ubicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
