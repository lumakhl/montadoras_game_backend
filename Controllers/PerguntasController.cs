using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MontadorasGameApi.Models;

namespace MontadorasGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntasController : ControllerBase
    {
        private readonly MontadorasGameContext _context;

        public PerguntasController(MontadorasGameContext context)
        {
            _context = context;
        }

        // GET: api/Perguntas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pergunta>>> GetPergunta()
        {
            return await _context.Pergunta.Include(m => m.Respostas).ToListAsync();
        }

        // GET: api/Perguntas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pergunta>> GetPergunta(long id)
        {
            var perguntas = await _context.Pergunta.FindAsync(id);

            if (perguntas == null)
            {
                return NotFound();
            }

            return perguntas;
        }

        // PUT: api/Perguntas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPergunta(long id, Pergunta pergunta)
        {
            if (id != pergunta.Id)
            {
                return BadRequest();
            }

            _context.Entry(pergunta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerguntaExists(id))
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

        // POST: api/Perguntas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pergunta>> PostPergunta(Pergunta pergunta)
        {
            _context.Pergunta.Add(pergunta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPergunta), new { id = pergunta.Id }, pergunta);
        }

        // DELETE: api/Perguntas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pergunta>> DeletePergunta(long id)
        {
            var perguntas = await _context.Pergunta.FindAsync(id);
            if (perguntas == null)
            {
                return NotFound();
            }

            _context.Pergunta.Remove(perguntas);
            await _context.SaveChangesAsync();

            return perguntas;
        }

        private bool PerguntaExists(long id)
        {
            return _context.Pergunta.Any(e => e.Id == id);
        }
    }
}
