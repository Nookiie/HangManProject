﻿using Data.Entities;
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
                foreach (var item in unitOfWork.GameTrackers.Get())
                {
                    gameTrackersDto.Add(new GameTrackerDTO
                    {
                        ID = item.ID,
                        Category = item.Category,
                        Words = item.Words
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
                GameTracker gameTracker = unitOfWork.GameTrackers.Get(id);
                gameTrackerDtos = new GameTrackerDTO
                {
                    ID = gameTracker.ID,
                    Category = gameTracker.Category,
                    Words = gameTracker.Words,
                };
            }
            return gameTrackerDtos;
        }

        public WordDTO GetRandomWordFromGameTrackerByID(object id)
        {
            GameTrackerDTO gameTrackerDtos = new GameTrackerDTO();
            WordDTO wordDTO = new WordDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                GameTracker gameTracker = unitOfWork.GameTrackers.Get(id);
                Word word = GetRandomWord(gameTracker);

                wordDTO.ID = word.ID;
                wordDTO.Name = word.Name;
            }
            return wordDTO;
        }

        public bool Save(GameTrackerDTO gameTrackerDTO)
        {
            GameTracker gameTracker = new GameTracker
            {
                ID = gameTrackerDTO.ID,
                Category = gameTrackerDTO.Category,
                Words = gameTrackerDTO.Words,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GameTrackers.Insert(gameTracker);

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
                    GameTracker gameTracker = unitOfWork.GameTrackers.Get(id);
                    unitOfWork.GameTrackers.Delete(gameTracker);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Word GetRandomWord(GameTracker gameTracker)
        {
            Random rnd = new Random();
            var randomIndex = rnd.Next(0, gameTracker.Words.Count - 1);

            return gameTracker.Words[randomIndex];
        }
    }
}