using locadoraAPI.Context;
using locadoraAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locadoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocadorController : ControllerBase
    {
        private readonly AppDbContextLocador _appDbContext;

        public LocadorController(AppDbContextLocador appDbContext)
        {
            _appDbContext = appDbContext;
        }
         

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locador>>> getLocadores()
        {
            return await _appDbContext.Locador.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Locador>> getLocador(int id)
        {
            var locador = await _appDbContext.Locador.FindAsync(id);

            if (locador == null)
            {
                return NotFound();
            }

            return locador;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> putLocador(int id, Locador locador)
        {
            if (id != locador.idLocador)
            {
                return BadRequest();
            }

            _appDbContext.Entry(locador).State = EntityState.Modified;

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Locador>> postLocador(Locador locador)
        {
            _appDbContext.Locador.Add(locador);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction("getLocador", new { id = locador.idLocador}, locador);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteLocador (int id)
        {
            var locador = await _appDbContext.Locador.FindAsync(id);

            if (locador == null)
            {
                return NotFound();
            }

            _appDbContext.Locador.Remove(locador);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }


        private bool LocadorExists(int id)
        {
            return _appDbContext.Locador.Any(e => e.idLocador== id);
        }
    }
}
