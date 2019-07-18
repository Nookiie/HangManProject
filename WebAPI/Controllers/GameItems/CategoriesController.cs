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
    [Route("api/categories/[action]")]
    public class CategoriesContoller : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork; 

        public CategoriesContoller(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IQueryable<Category> Get()
        {
            return unitOfWork.Categories.Get();
        }
            
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
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
        public void Create(Category category)
        {
             unitOfWork.Categories.Insert(category);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.Categories.Delete(id);
        }
    }
}
