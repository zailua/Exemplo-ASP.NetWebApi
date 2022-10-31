using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fliperama.Data;
using Fliperama.Model;

namespace Fliperama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly DataContext _context;

        public JogosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogo>>> GetJogos()
        {
            return await _context.Jogos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jogo>> GetJogo(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);

            if (jogo == null)
            {
                return NotFound();
            }

            return jogo;
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJogo(int id, Jogo jogo)
        {
            var updateJogo = await _context.Jogos.FindAsync(id);
            
            if (id != jogo.Id)
            {
                return BadRequest();
            }

            if (updateJogo == null)
            {
                return NotFound();
            }

            updateJogo.Nome = jogo.Nome;
            updateJogo.Valor = jogo.Valor;
            updateJogo.GameGen = jogo.GameGen;
            updateJogo.Img = jogo.Img;



            _context.Entry(updateJogo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogoExists(id))
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
        public async Task<ActionResult<Jogo>> PostJogo(Jogo jogo)
        {
            _context.Jogos.Add(jogo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJogo", new { id = jogo.Id }, jogo);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogo(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null)
            {
                return NotFound();
            }

            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JogoExists(int id)
        {
            return _context.Jogos.Any(e => e.Id == id);
        }
    }
}
