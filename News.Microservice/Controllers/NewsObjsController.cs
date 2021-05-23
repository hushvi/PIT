using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Microservice.Models;

namespace News.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsObjsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public NewsObjsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/NewsObjs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsObj>>> GetNews()
        {
            return await _context.News.ToListAsync();
        }

        // GET: api/NewsObjs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsObj>> GetNewsObj(int id)
        {
            var newsObj = await _context.News.FindAsync(id);

            if (newsObj == null)
            {
                return NotFound();
            }

            return newsObj;
        }

        // POST: api/NewsObjs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NewsObj>> PostNewsObj(NewsObj newsObj)
        {
            _context.News.Add(newsObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsObj", new { id = newsObj.NewsId }, newsObj);
        }
    }
}
