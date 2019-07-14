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
    public class GameTrackersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork; 

        public GameTrackersController(IUnitOfWork repo)
        {
            unitOfWork = repo;
        }

        [HttpGet]
        public IQueryable<GameTracker> Get()
        {
            return unitOfWork.GameTrackers.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<GameTracker> Get(object id)
        {
            return unitOfWork.GameTrackers.Get(id);
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
        public void Create(GameTracker gameTracker)
        {
             unitOfWork.GameTrackers.Insert(gameTracker);
        }

        [HttpDelete("{id}")]
        public void Delete(object id)
        {
            unitOfWork.GameTrackers.Delete(id);
        }
    }
}
