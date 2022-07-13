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
    public class FilmeController : ControllerBase
    {
        private readonly AppDbContextFilme _appDbContext;

        public FilmeController(AppDbContextFilme appDbContext)
        {
            _appDbContext = appDbContext;
        } 


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> getFilmes()
        {
            return await _appDbContext.Filme.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> getFilme(int id)
        {
            var filme = await _appDbContext.Filme.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> putFilme(int id, Filme filme)
        {
            if (id != filme.IdFilme)
            {
                return BadRequest();
            }

            _appDbContext.Entry(filme).State = EntityState.Modified;

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(id))
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
        public async Task<ActionResult<Filme>> postFilme(Filme filme)
        {
            _appDbContext.Filme.Add(filme);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction("getFilme", new { id = filme.IdFilme }, filme);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteFilme(int id)
        {
            var filme = await _appDbContext.Filme.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            _appDbContext.Filme.Remove(filme);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }


        private bool FilmeExists(int id)
        {
            return _appDbContext.Filme.Any(e => e.IdFilme == id);
        }
    }
}
