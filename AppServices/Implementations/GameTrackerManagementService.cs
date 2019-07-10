using Data.Entities;
using HM.AppServices.DTOs;
using Repos.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.AppServices.Implementations
{
    public class GameTrackerManagementService
    {
        public List<GameTrackerDTO> Get()
        {
            List<GameTrackerDTO> gameTrackersDto = new List<GameTrackerDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.GameTrackerRepository.Get())
                {
                    gameTrackersDto.Add(new GameTrackerDTO
                    {
                        ID = item.ID,
                        Category = item.Category,
                        Words = item.Words,
                        ChosenWord = item.ChosenWord

                    });
                }
            }
            return gameTrackersDto;
        }

        public GameTrackerDTO GetById(int id)
        {
            GameTrackerDTO gameTrackerDtos = new GameTrackerDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                GameTracker gameTracker = unitOfWork.GameTrackerRepository.GetByID(id);
                gameTrackerDtos = new GameTrackerDTO
                {
                    ID = gameTracker.ID,
                    Category = gameTracker.Category,
                    Words = gameTracker.Words,
                    ChosenWord = gameTracker.ChosenWord
                };
            }
            return gameTrackerDtos;
        }

        public bool Save(GameTrackerDTO gameTrackerDTO)
        {
            GameTracker gameTracker = new GameTracker
            {
                ID = gameTrackerDTO.ID,
                Category = gameTrackerDTO.Category,
                Words = gameTrackerDTO.Words,
                ChosenWord = gameTrackerDTO.ChosenWord
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (gameTrackerDTO.ID == 0)
                        unitOfWork.GameTrackerRepository.Insert(gameTracker);
                    else
                        unitOfWork.GameTrackerRepository.Update(gameTracker);

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
                    GameTracker gameTracker = unitOfWork.GameTrackerRepository.GetByID(id);
                    unitOfWork.GameTrackerRepository.Delete(gameTracker);
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
