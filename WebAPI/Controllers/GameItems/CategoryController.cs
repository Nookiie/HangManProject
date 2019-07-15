using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HM.Data.Context;
using HM.Data.Entities.GameItems;
using HM.Repositories.Abstractions;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryContollers : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork; 

        public CategoryContollers(IUnitOfWork repo)
        {
            unitOfWork = repo;
        }

        [HttpGet]
        public IQueryable<Category> Get()
        {
            return unitOfWork.Categories.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(object id)
        {
            return unitOfWork.Categories.Get(id);
        }

        /*
        [HttpPut("{id}")]
        public void Update(object id, GameTracker gameTrackerNew)
        {
            GameTracker gameTracker = _gameTrackerRepo.Get(id);
            _gameTrackerRepo.Update(id, gameTracker);
        }
        */

        [HttpPost]
        public void Create(Category gameTracker)
        {
             unitOfWork.Categories.Insert(gameTracker);
        }

        [HttpDelete("{id}")]
        public void Delete(object id)
        {
            unitOfWork.Categories.Delete(id);
        }
    }
}
