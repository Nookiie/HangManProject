using HM.Data.Abstraction;
using HM.Repositories.Abstractions;
using HM.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HM.GenericAPI.Managers
{
    public class GenericAPI<T> where T : BaseEntity<int>
    {
        private readonly Uri url = new Uri("https://localhost:44340/api/" + typeof(T).ToString() + "/get");
        private readonly GenericUnit<T> _unitOfWork;
        // private readonly WordManagementService _service;

        // private readonly IMapper _mapper;

        public GenericAPI(GenericUnit<T> unitOfWork)
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
        public IQueryable<T> Get()
        {
            return _unitOfWork.Entity.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<T> Get(int id)
        {
            return _unitOfWork.Entity.Get(id);
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
        public void Create(T entity)
        {
            _unitOfWork.Entity.Insert(entity);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Entity.Delete(id);
        }

        [HttpGet]
        public T GetRandom()
        {
            List<T> words = _unitOfWork.Entity.Get().ToList();
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, words.Count);

            return words[randomIndex];
        }

    }
}
