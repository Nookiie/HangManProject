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

        public GameDifficulty gameDifficulty;

        public Category gameCategory;

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
            /*
            List<Category> categories = new List<Category>()
            {
                new Category("Animals"),
                new Category("Stuff")
            };
            */

            /*
            List<Word> words = new List<Word> // Example words to be used in case of DB failure
            {
                new Word("flamingo", categories[0]),
                new Word("apple", categories[1]),
                new Word("stuff", categories[1]),
                new Word("elephant", categories[0]),
                new Word("archipelago", categories[1]),
                new Word("imagination", categories[1]),
                new Word("somerandomhardword", categories[1])
            };
            */

            List<Word> words = GetWordsFromDB();

            words = GetDifficultySliderWords(words, gameDifficulty);
            words = GetCategoryWords(words, gameCategory);

            if (words.Count == 0)
            {
                throw new ArgumentException("The current wordList does not have any words matching the criteria");
            }

            Word chosenWord = GetRandomWord(words);
            Word printWord = new Word();
            printWord.Name = chosenWord.Name;

            printWord.Name = new Regex("\\S").Replace(chosenWord.Name, "_");
            printWordDisplay = printWord;
            chosenWordDisplay = chosenWord;
            StartGameFlag(); // Sets up the game flag 
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

            if (printWordDisplay.Name == chosenWordDisplay.Name)
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
            attempts = 0;
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
                    var sameLetterCounter = chosenWordDisplay.Name.Count(x => x == letter);
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

        private List<Word> GetDifficultySliderWords(List<Word> words, GameDifficulty gameDifficulty)
        {
            switch (gameDifficulty)
            {
                case GameDifficulty.Easy: words.RemoveAll(x => x.Name.Length > 5); break;
                case GameDifficulty.Normal: words.RemoveAll(x => x.Name.Length < 5 || x.Name.Length > 10); break;
                case GameDifficulty.Hard: words.RemoveAll(x => x.Name.Length < 10 || x.Name.Length > 15); break;
                case GameDifficulty.Insane: words.RemoveAll(x => x.Name.Length < 15 || x.Name.Length > 20); break;
                default: break;
            }
            return words;
        }

        private List<Word> GetCategoryWords(List<Word> words, Category category)
        {
            return words.Where(x => x.CategoryID == category.ID).ToList();
        }

        private Word GetRandomWord(List<Word> words)
        {

            Random rnd = new Random();
            var randomIndex = rnd.Next(0, words.Count - 1);

            return words[randomIndex];
        }

        private List<Word> GetWordsFromDB()
        {
            Uri url = new Uri("https://localhost:44340/api/words/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("get").Result;

                string jsonString = response.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert.DeserializeObject<List<Word>>(jsonString);
                List<Word> words = responseData;

                if (words == null)
                {
                    return null;
                }

                return words;
            }
        }

        public List<Category> GetCategoriesFromDB()
        {
            Uri url = new Uri("https://localhost:44340/api/categories/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("get").Result;

                string jsonString = response.Content.ReadAsStringAsync().Result;
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
