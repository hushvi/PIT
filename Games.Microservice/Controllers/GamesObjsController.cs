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
    public class GamesObjsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public GamesObjsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/GamesObjs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamesObj>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        // GET: api/GamesObjs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GamesObj>> GetGamesObj(int id)
        {
            var gamesObj = await _context.Games.FindAsync(id);

            if (gamesObj == null)
            {
                return NotFound();
            }

            return gamesObj;
        }

        // GET: api/GamesObjs/5
        [HttpGet]
        [Route("teamGames/{id}")]
        public async Task<ActionResult<IEnumerable<GamesObj>>> GetTeamGames(int id)
        {
            return await _context.Games.Where(li => li.FirstTeamId == id || li.SecondTeamId == id).ToListAsync();
        }

        // GET: api/GamesObjs/5
        [HttpGet]
        [Route("team/goals/{id}")]
        public int GetTeamGoals(int id)
        {
            var events = _context.GameEvents.FromSqlRaw("select * from dbo.GameEvents where GameEvents.EventTeamId = {0} AND GameEvents.EventType = 'Goal'", id);
            return events.Count();          
        }

        // PUT: api/GamesObjs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamesObj(int id, GamesObj gamesObj)
        {
            if (id != gamesObj.GameId)
            {
                return BadRequest();
            }

            _context.Entry(gamesObj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesObjExists(id))
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

        // POST: api/GamesObjs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GamesObj>> PostGamesObj(GamesObj gamesObj)
        {
            _context.Games.Add(gamesObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamesObj", new { id = gamesObj.GameId }, gamesObj);
        }

        // DELETE: api/GamesObjs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamesObj(int id)
        {
            var gamesObj = await _context.Games.FindAsync(id);
            if (gamesObj == null)
            {
                return NotFound();
            }

            _context.Games.Remove(gamesObj);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GamesObjExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }
    }
}
