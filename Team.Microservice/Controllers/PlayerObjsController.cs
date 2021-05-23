using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team.Microservice.Models;

namespace Team.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerObjsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PlayerObjsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PlayerObjs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerObj>>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        // GET: api/PlayerObjs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerObj>> GetPlayerObj(int id)
        {
            var playerObj = await _context.Players.Include(i=>i.Club).FirstOrDefaultAsync(i=>i.ClubId == id);

            if (playerObj == null)
            {
                return NotFound();
            }

            return playerObj;
        }

        // GET: api/PlayerObjs/5
        [Route("teamPlayers/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerObj>>> GetTeamPlayers(int id)
        {
            return await _context.Players.Where(li=>li.ClubId==id).ToListAsync();
        }

        // PUT: api/PlayerObjs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerObj(int id, PlayerObj playerObj)
        {
            if (id != playerObj.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(playerObj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerObjExists(id))
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

        // POST: api/PlayerObjs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerObj>> PostPlayerObj(PlayerObj playerObj)
        {
            _context.Players.Add(playerObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerObj", new { id = playerObj.PlayerId }, playerObj);
        }

        // DELETE: api/PlayerObjs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerObj(int id)
        {
            var playerObj = await _context.Players.FindAsync(id);
            if (playerObj == null)
            {
                return NotFound();
            }

            _context.Players.Remove(playerObj);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerObjExists(int id)
        {
            return _context.Players.Any(e => e.PlayerId == id);
        }
    }
}
