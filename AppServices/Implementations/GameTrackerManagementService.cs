using Data.Entities;
using HM.AppServices.DTOs;
using HM.Data.Entities.GameItems;
using Repos.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.AppServices.Implementations
{
    public class GameTrackerManagementService
    {
        public List<GameTrackerDTO> GetAll()
        {
            List<GameTrackerDTO> gameTrackersDto = new List<GameTrackerDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.Categories.Get())
                {
                    gameTrackersDto.Add(new GameTrackerDTO
                    {
                        ID = item.ID,
                        Name = item.Name,
                    });
                }
            }
            return gameTrackersDto;
        }

        public GameTrackerDTO GetById(object id)
        {
            GameTrackerDTO gameTrackerDtos = new GameTrackerDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Category gameTracker = unitOfWork.Categories.Get(id);
                gameTrackerDtos = new GameTrackerDTO
                {
                    ID = gameTracker.ID,
                    Name = gameTracker.Name,
                };
            }
            return gameTrackerDtos;
        }
        public bool Save(GameTrackerDTO gameTrackerDTO)
        {
            Category gameTracker = new Category
            {
                ID = gameTrackerDTO.ID,
                Name = gameTrackerDTO.Name,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.Categories.Insert(gameTracker);

                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Category gameTracker = unitOfWork.Categories.Get(id);
                    unitOfWork.Categories.Delete(gameTracker);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
