using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HM.Data.Context;
using HM.Data.Entities.GameItems;
using AutoMapper;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WordsController : ControllerBase
    {
        private readonly HangmanDbContext _context;

        // private readonly IMapper _mapper;

        public WordsController(HangmanDbContext context)
        {
            _context = context;
        }

        /*
        public WordsController(IMapper mapper)
        {
            _mapper = mapper;
        }
        */
    
        // GET: api/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Word>>> Get()
        {
            return await _context.Words.ToListAsync();
        }

        // GET: api/Words/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Word>> Get(int id)
        {
            var word = await _context.Words.FindAsync(id);

            if (word == null)
            {
                return NotFound();
            }

            return word;
        }

        // PUT: api/Words/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Word word)
        {
            if (id != word.ID)
            {
                return BadRequest();
            }

            _context.Entry(word).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
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

        // POST: api/Words
        [HttpPost]
        public async Task<ActionResult<Word>> Post(Word word)
        {
            _context.Words.Add(word);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWord", new { id = word.ID }, word);
        }

        // DELETE: api/Words/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Word>> Delete(int id)
        {
            var word = await _context.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            _context.Words.Remove(word);
            await _context.SaveChangesAsync();

            return word;
        }

        [HttpGet]
        public async Task<ActionResult<Word>> GetRandom()
        {
            List<Word> words = await _context.Words.ToListAsync();
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, words.Count - 1);

            return words[randomIndex];
        }

        private bool WordExists(int id)
        {
            return _context.Words.Any(e => e.ID == id);
        }
    }
}
