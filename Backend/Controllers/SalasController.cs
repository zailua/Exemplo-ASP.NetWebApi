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
    public class SalasController : ControllerBase
    {
        private readonly DataContext _context;

        public SalasController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sala>>> GetSala()
        {
            return await _context.Salas.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> GetSala(int id)
        {
            
            var sala = await _context.Salas.FindAsync(id);
            


            if (sala == null)
            {
                return NotFound();
            }
          

            return Ok(sala);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSala(int id, Sala sala)
        {
            var updateSala = await _context.Salas.FindAsync(id);
            var jogo = await _context.Jogos.FindAsync(sala.Jogo.Id);
           
           if (jogo == null)
           {
                return BadRequest();
            }
            
            if (id != sala.Id)
            {
                return BadRequest();
            }

            if (updateSala == null)
            {
                return NotFound();
            }
         
            updateSala.Nome = sala.Nome;
            updateSala.Jogo = jogo;
            
           

            _context.Entry(updateSala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(id))
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
        public async Task<ActionResult<Sala>> PostSala(Sala sala)
        {
            var jogo = await _context.Jogos.FindAsync(sala.Jogo.Id);
            if (jogo == null) 
            { 
                return BadRequest(); 
            }
            sala.Jogo = jogo;
            _context.Salas.Add(sala);
            await _context.SaveChangesAsync();

            return Ok(sala);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSala(int id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }

            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaExists(int id)
        {
            return _context.Salas.Any(e => e.Id == id);
        }
    }
}
