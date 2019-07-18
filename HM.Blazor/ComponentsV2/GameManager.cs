using HangmanLogic.Logic;
using HM.Data.Entities.Difficulty;
using HM.Data.Entities.GameItems;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentsV2
{
    public class GameManager : ComponentBase
    {

        public GameManager()
        {
            WordsManager wordsManager = new WordsManager();

            Categories = wordsManager.GetAllCategories();
            Words = wordsManager.GetAllWords();
        }

        public List<string> Difficulties = new List<string>
        {
                GameDifficulty.Easy.ToString(),
                GameDifficulty.Normal.ToString(),
                GameDifficulty.Hard.ToString(),
                GameDifficulty.Insane.ToString()
        };

        public List<Category> Categories { get; set; } = new List<Category>();

        public List<Word> Words { get; set; } = new List<Word>();
    }
}
