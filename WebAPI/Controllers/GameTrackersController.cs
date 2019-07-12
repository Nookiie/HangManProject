using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HM.Data.Context;
using HM.Data.Entities.GameItems;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GameTrackersController : ControllerBase
    {
        private readonly HangmanDbContext _context;

        public GameTrackersController(HangmanDbContext context)
        {
            _context = context;
        }

        // GET: api/GameTrackers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameTracker>>> Get()
        {
            return await _context.GameTrackers.ToListAsync();
        }

        // GET: api/GameTrackers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameTracker>> Get(int id)
        {
            var gameTracker = await _context.GameTrackers.FindAsync(id);

            if (gameTracker == null)
            {
                return NotFound();
            }

            return gameTracker;
        }

        // PUT: api/GameTrackers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, GameTracker gameTracker)
        {
            if (id != gameTracker.ID)
            {
                return BadRequest();
            }

            _context.Entry(gameTracker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameTrackerExists(id))
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

        // POST: api/GameTrackers
        [HttpPost]
        public async Task<ActionResult<GameTracker>> Post(GameTracker gameTracker)
        {
            _context.GameTrackers.Add(gameTracker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameTracker", new { id = gameTracker.ID }, gameTracker);
        }

        // DELETE: api/GameTrackers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameTracker>> Delete(int id)
        {
            var gameTracker = await _context.GameTrackers.FindAsync(id);
            if (gameTracker == null)
            {
                return NotFound();
            }

            _context.GameTrackers.Remove(gameTracker);
            await _context.SaveChangesAsync();

            return gameTracker;
        }

        private bool GameTrackerExists(int id)
        {
            return _context.GameTrackers.Any(e => e.ID == id);
        }
    }
}
