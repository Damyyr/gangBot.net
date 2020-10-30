using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GangBot.net.Models;

namespace GangBot.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeNamesController : ControllerBase
    {
        private readonly GangContext _context;

        public CodeNamesController(GangContext context)
        {
            _context = context;
        }

        // GET: api/CodeNames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeName>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/CodeNames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CodeName>> GetCodeName(long id)
        {
            var codeName = await _context.TodoItems.FindAsync(id);

            if (codeName == null)
            {
                return NotFound();
            }

            return codeName;
        }

        // PUT: api/CodeNames/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodeName(long id, CodeName codeName)
        {
            if (id != codeName.Id)
            {
                return BadRequest();
            }

            _context.Entry(codeName).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodeNameExists(id))
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

        // POST: api/CodeNames
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CodeName>> PostCodeName(CodeName codeName)
        {
            _context.TodoItems.Add(codeName);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodeName", new { id = codeName.Id }, codeName);
        }

        // DELETE: api/CodeNames/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CodeName>> DeleteCodeName(long id)
        {
            var codeName = await _context.TodoItems.FindAsync(id);
            if (codeName == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(codeName);
            await _context.SaveChangesAsync();

            return codeName;
        }

        private bool CodeNameExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
