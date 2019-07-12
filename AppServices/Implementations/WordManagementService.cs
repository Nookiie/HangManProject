﻿using Data.Entities;
using HM.AppServices.DTOs;
using HM.Data.Entities.GameItems;
using Repos.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.AppServices.Implementations
{
    public class WordManagementService
    {
        public List<WordDTO> GetAll()
        {
            List<WordDTO> wordsDto = new List<WordDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.Words.Get())
                {
                    wordsDto.Add(new WordDTO
                    {
                        ID = item.ID,
                        Name = item.Name
                    });
                }
            }

            return wordsDto;
        }

        public WordDTO GetById(int id)
        {
            WordDTO WordDTO = new WordDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Word word = unitOfWork.Words.Get(id);
                WordDTO = new WordDTO
                {
                    ID = WordDTO.ID,
                    Name = WordDTO.Name
                };
            }
            return WordDTO;
        }

        public bool Save(WordDTO WordDTO)
        {
            Word word = new Word
            {
                ID = WordDTO.ID,
                Name = WordDTO.Name
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.Words.Insert(word);

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
                    Word word = unitOfWork.Words.Get(id);
                    unitOfWork.Words.Delete(word);
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