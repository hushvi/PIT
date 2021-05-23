using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Games.Microservice.Models;

namespace Games.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameEventsObjsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public GameEventsObjsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/GameEventsObjs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameEventsObj>>> GetGameEvents()
        {
            return await _context.GameEvents.ToListAsync();
        }


        // GET: api/gameEvents/5
        [HttpGet]
        [Route("gameEvents/{id}")]
        public async Task<ActionResult<IEnumerable<GameEventsObj>>> GetGameEvents(int id)
        {
            return await _context.GameEvents.Where(li => li.GameId == id).ToListAsync();
        }


        // PUT: api/GameEventsObjs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameEventsObj(int id, GameEventsObj gameEventsObj)
        {
            if (id != gameEventsObj.EventId)
            {
                return BadRequest();
            }

            _context.Entry(gameEventsObj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameEventsObjExists(id))
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

        // POST: api/GameEventsObjs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameEventsObj>> PostGameEventsObj(GameEventsObj gameEventsObj)
        {
            _context.GameEvents.Add(gameEventsObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameEventsObj", new { id = gameEventsObj.EventId }, gameEventsObj);
        }

        // DELETE: api/GameEventsObjs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameEventsObj(int id)
        {
            var gameEventsObj = await _context.GameEvents.FindAsync(id);
            if (gameEventsObj == null)
            {
                return NotFound();
            }

            _context.GameEvents.Remove(gameEventsObj);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameEventsObjExists(int id)
        {
            return _context.GameEvents.Any(e => e.EventId == id);
        }
    }
}
