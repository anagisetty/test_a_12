using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_a_12.Models;

namespace test_a_12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignatedPersonController : ControllerBase
    {
        private readonly DesignatedPersonContext _context;

        public DesignatedPersonController(DesignatedPersonContext context)
        {
            _context = context;
        }

        // GET: api/DesignatedPerson
        [HttpGet]
        public IEnumerable<DesignatedPerson> GetDesignatedPerson()
        {
            return _context.DesignatedPerson;
        }

        // GET: api/DesignatedPerson/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDesignatedPerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var designatedPerson = await _context.DesignatedPerson.FindAsync(id);

            if (designatedPerson == null)
            {
                return NotFound();
            }

            return Ok(designatedPerson);
        }

        // PUT: api/DesignatedPerson/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignatedPerson([FromRoute] int id, [FromBody] DesignatedPerson designatedPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != designatedPerson.Id)
            {
                return BadRequest();
            }

            _context.Entry(designatedPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignatedPersonExists(id))
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

        // POST: api/DesignatedPerson
        [HttpPost]
        public async Task<IActionResult> PostDesignatedPerson([FromBody] DesignatedPerson designatedPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DesignatedPerson.Add(designatedPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesignatedPerson", new { id = designatedPerson.Id }, designatedPerson);
        }

        // DELETE: api/DesignatedPerson/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesignatedPerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var designatedPerson = await _context.DesignatedPerson.FindAsync(id);
            if (designatedPerson == null)
            {
                return NotFound();
            }

            _context.DesignatedPerson.Remove(designatedPerson);
            await _context.SaveChangesAsync();

            return Ok(designatedPerson);
        }

        private bool DesignatedPersonExists(int id)
        {
            return _context.DesignatedPerson.Any(e => e.Id == id);
        }
    }
}