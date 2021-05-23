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
    public class TeamObjsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TeamObjsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TeamObjs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamObj>>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        // GET: api/TeamObjs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamObj>> GetTeamObj(int id)
        {
            var teamObj = await _context.Teams.FindAsync(id);

            if (teamObj == null)
            {
                return NotFound();
            }

            return Ok(teamObj);
        }

        // GET: api/PlayerObjs/5
        [Route("teamPlayers/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerObj>>> GetTeamPlayers(int id)
        {
            return await _context.Players.Where(li => li.ClubId == id).ToListAsync();
        }

        // PUT: api/TeamObjs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamObj(int id, TeamObj teamObj)
        {
            if (id != teamObj.TeamId)
            {
                return BadRequest();
            }

            _context.Entry(teamObj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamObjExists(id))
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

        // POST: api/TeamObjs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamObj>> PostTeamObj(TeamObj teamObj)
        {
            _context.Teams.Add(teamObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamObj", new { id = teamObj.TeamId }, teamObj);
        }

        // DELETE: api/TeamObjs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamObj(int id)
        {
            var teamObj = await _context.Teams.FindAsync(id);
            if (teamObj == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(teamObj);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamObjExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }
    }
}
