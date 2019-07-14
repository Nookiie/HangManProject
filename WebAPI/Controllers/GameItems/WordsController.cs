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
using HM.Repositories.Abstractions;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WordsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        // private readonly WordManagementService _service;

        // private readonly IMapper _mapper;

        public WordsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /*
        public WordsController(IMapper mapper)
        {
            _mapper = mapper;
        }
        */

        [HttpGet]
        public IQueryable<Word> Get()
        {
             return _unitOfWork.Words.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Word> Get(int id)
        {
            return _unitOfWork.Words.Get(id);
        }

        /*
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
        */

        [HttpPost]
        public void Create(Word word)
        {
            _unitOfWork.Words.Insert(word);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Words.Delete(id);
        }

        [HttpGet]
        public Word GetRandom()
        {
            List<Word> words = _unitOfWork.Words.Get().ToList();
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, words.Count);

            return words[randomIndex];
        }
    }
}
