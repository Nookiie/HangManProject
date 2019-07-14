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
using HM.AppServices.Implementations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WordsController : ControllerBase
    {
        private readonly HangmanDbContext _context;
        // private readonly WordManagementService _service;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Word>>> Get()
        {
            return await _context.Words.ToListAsync();
        }

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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Word word)
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

        [HttpPost]
        public async Task<ActionResult<Word>> Create(Word word)
        {
            _context.Words.Add(word);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = word.ID }, word);
        }

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
            int randomIndex = rnd.Next(0, words.Count);

            return words[randomIndex];
        }

        private bool WordExists(int id)
        {
            return _context.Words.Any(e => e.ID == id);
        }
    }
}
