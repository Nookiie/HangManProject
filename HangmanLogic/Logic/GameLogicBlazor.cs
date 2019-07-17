using HM.Data.Abstraction;
using HM.Data.Entities.Difficulty;
using HM.Data.Entities.GameCondition;
using HM.Data.Entities.GameItems;
using Newtonsoft.Json;
using Repos.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebAPI.Controllers;

namespace HM.Logic.Logic
{
    public class GameLogicBlazor
    {
        #region Variables

        public Word printWordDisplay;

        public Word chosenWordDisplay;

        public string inputDisplay;

        public char inputDisplayFirstLetter;

        public bool gameInProgress = false;

        public bool gameFinished = true;

        public bool gameWon = false;

        public bool gameLost = false;

        public int wordCount = 0;

        public int tries = 0;

        public int attempts = 0;

        public int jokers = MAX_JOKERS;

        public int score = 0;

        #endregion

        #region DifficultyValues

        private const int MAX_FAILS = 9;

        private const int DEFAULT_SCORE_MULTIPLIER = 5;

        private const int SCORE_MULTIPLIER_EASY = 5;

        private const int SCORE_MULTIPLIER_NORMAL = 5;

        private const int SCORE_MULTIPLIER_HARD = 5;

        private const int SCORE_MULTIPLIER_INSANE = 5;

        private const int MAX_JOKERS = 1;

        #endregion

        #region Methods

        public void StartGame()
        {
            List<Word> words = new List<Word>
            {
                new Word("apple"),
                new Word("stuff"),
                new Word("elephant"),
                new Word("archipelago"),
                new Word("imagination"),
                new Word("barrel"),
            };

            string category = "Animals";
            IGameData gameData = new GameData(category, words, GameDifficulty.Hard);
            gameData.CheckWordsForErrors();

            Word chosenWord = gameData.GetRandomWord();
            Word printWord = new Word();
            printWord.Name = chosenWord.Name;

            printWord.Name = new Regex("\\S").Replace(chosenWord.Name, "_ ");
            printWordDisplay = printWord;
            chosenWordDisplay = chosenWord;
            StartGameFlag(); // Sets up that the game has just started
        }

        public void StartGameFlag()
        {
            gameInProgress = true;
        }

        public void GetInput()
        {
            if (string.IsNullOrWhiteSpace(inputDisplay))
                return;

            inputDisplayFirstLetter = inputDisplay[0];
        }

        public void GuessLetter()
        {
            GetInput();
            bool isGuessed = false;

            if (inputDisplayFirstLetter == '!')
            {
                Joker();
            }

            for (int i = 0; i < chosenWordDisplay.Name.Length; i++)
            {
                if (inputDisplayFirstLetter == chosenWordDisplay.Name[i])
                {
                    StringBuilder sb = new StringBuilder(printWordDisplay.Name);
                    sb[i] = inputDisplayFirstLetter;
                    printWordDisplay.Name = sb.ToString();

                    isGuessed = true;
                    wordCount++;
                }
            }

            if (!isGuessed)
            {
                tries++;
            }

            if (wordCount == chosenWordDisplay.Name.Length)
            {
                EndGame(GameCondition.Won);
            }

            if (tries == MAX_FAILS)
            {
                EndGame(GameCondition.Lost);
            }
        }

        public void EndGame(GameCondition gameCondition)
        {
            gameInProgress = false;
            gameFinished = true;

            if (gameCondition == GameCondition.Won)
            {
                gameWon = true;
                gameLost = false;
            }
            else
            {
                gameLost = true;
                gameWon = false;
            }

            CleanUp();
        }

        public void CleanUp()
        {
            chosenWordDisplay = null;
            printWordDisplay = null;
            wordCount = 0;
            tries = 0;
            score = 0;
            jokers = MAX_JOKERS;
        }

        public void Joker()
        {
            if (jokers > 0)
            {
                var sameLetterList = new List<int>();

                foreach (var letter in chosenWordDisplay.Name)
                {
                    var sameLetterCounter = Regex.Matches(letter.ToString(), chosenWordDisplay.Name).Count();
                    sameLetterList.Add(sameLetterCounter);
                }

                do
                {
                    inputDisplayFirstLetter = GetRandomLetterFromWord(chosenWordDisplay);
                }
                while (Regex.Matches(inputDisplayFirstLetter.ToString(), chosenWordDisplay.Name).Count() > sameLetterList.Min());

                jokers--;

                GuessLetter();
            }

            else
            {
                return;
            }
        }

        public char GetRandomLetterFromWord(Word word)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, word.Name.Length - 1);
            return word.Name[randomIndex];
        }

        public async Task<List<Word>> GetWordsFromDB()
        {
            Uri url = new Uri("https://localhost:44340/api/words");
            using (var client = new HttpClient())
            {

                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("get");

                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<Word>>(jsonString);
                List<Word> words = responseData;

                if(words == null)
                {
                    return null; 
                }

                return words;
            }
        }

        public async Task <List<Category>> GetCategoriesFromDB()
        {
            Uri url = new Uri("https://localhost:44340/api/categories");
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("get");

                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<Category>>(jsonString);
                List<Category> categories = responseData;

                if (categories == null)
                {
                    return null;
                }

                return categories;
            }
        }
        #endregion
    }
}
