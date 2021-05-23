using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Subscriptions.Microservice.Models;

namespace Subscriptions.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionObjsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SubscriptionObjsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SubscriptionObjs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionObj>>> GetSubscriptions()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        // POST: api/SubscriptionObjs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubscriptionObj>> PostSubscriptionObj(SubscriptionObj subscriptionObj)
        {
            _context.Subscriptions.Add(subscriptionObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriptionObj", new { id = subscriptionObj.SubId }, subscriptionObj);
        }

        // DELETE: api/SubscriptionObjs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionObj(int id)
        {
            var subscriptionObj = await _context.Subscriptions.FindAsync(id);
            if (subscriptionObj == null)
            {
                return NotFound();
            }

            _context.Subscriptions.Remove(subscriptionObj);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
