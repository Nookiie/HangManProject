using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HM.Data.Abstraction;
using HM.Data.Entities.Difficulty;

namespace HM.Data.Entities.GameItems
{
    /// <summary>
    /// The Main Game Manager that coordinates and manages the wordlist
    /// </summary>
    public class GameData : IGameData // Used for Console only
    {
        #region Constructor

        public GameData()
        {

        }

        public GameData(string name, List<Word> words, GameDifficulty difficulty)
        {
            switch (difficulty)
            {
                case GameDifficulty.Easy: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE_EASY); SetMultiplier(difficulty); break;
                case GameDifficulty.Normal: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE_NORMAL); SetMultiplier(difficulty); break;
                case GameDifficulty.Hard: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE_HARD); SetMultiplier(difficulty); break;
                case GameDifficulty.Insane: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE); SetMultiplier(difficulty); break;
                default: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE); SetMultiplier(difficulty); break;
            }

            this.Words = words;
            this.Category = name;
        }

        public GameData(List<Word> words, GameDifficulty difficulty)
        {

            switch (difficulty)
            {
                case GameDifficulty.Easy: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE_EASY); SetMultiplier(difficulty); break;
                case GameDifficulty.Normal: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE_NORMAL); SetMultiplier(difficulty); break;
                case GameDifficulty.Hard: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE_HARD); SetMultiplier(difficulty); break;
                case GameDifficulty.Insane: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE); SetMultiplier(difficulty); break;
                default: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE); SetMultiplier(difficulty); break;
            }
            this.Words = words;
        }

        #endregion

        #region Properties

        public List<Word> Words { get; set; }

        public string Category { get; set; }

        #region DifficultyValues

        private const int MAX_WORD_SIZE_EASY = 5;

        private const int MAX_WORD_SIZE_NORMAL = 10;

        private const int MAX_WORD_SIZE_HARD = 15;

        private const int MAX_WORD_SIZE = 20; // Also goes for Insane (max word size value)

        private const int MAX_FAILS = 9;

        private const int DEFAULT_SCORE_MULTIPLIER = 5;

        #endregion

        public int currentFails = 0;

        public int currentWins = 0;

        public int jokers = 1;

        public int streak = 0;

        public int scoreMultiplier = 1;

        public int score = 0;

        #endregion

        #region Methods

        public void ChangeWordName(Word word, string name)
        {
            word.Name = name;
        }

        public Word GetRandomWord()
        {
            if (Words.Count == 0)
                return null;

            Random rnd = new Random();
            int randomIndex = rnd.Next(0, Words.Count - 1);

            return Words[randomIndex];
        }

        public bool GuessCharacterInWord(char input, Word word)
        {
            return word.Name.Contains(input);
        }

        public bool Win(Word chosenWord)
        {
            currentWins++;
            streak++;
            score += DEFAULT_SCORE_MULTIPLIER * (scoreMultiplier + streak);

            if (currentWins == chosenWord.Name.Length - 1)
                return true;
            else
                return false;
        }

        public bool Fail()
        {
            currentFails++;
            streak = 0;

            if (currentFails >= MAX_FAILS)
                return true;
            else
                return false;
        }

        public void SetMultiplier(GameDifficulty difficulty)
        {
            switch (difficulty)
            {
                case GameDifficulty.Easy: scoreMultiplier = 1; break;
                case GameDifficulty.Normal: scoreMultiplier = 2; break;
                case GameDifficulty.Hard: scoreMultiplier = 3; break;
                case GameDifficulty.Insane: scoreMultiplier = 4; break;
            }

        }

        public bool CheckWordsForErrors()
        {
            foreach (var word in Words)
            {
                if (word.Name.Length > MAX_WORD_SIZE)
                    return false;
            }
            return true;
        }

        public void PopulateDictionary(List<Word> words)
        {
            foreach (var word in words)
            {
                Words.Add(word);
            }
        }

        public int GetJokerCount() => jokers;

        public int GetTries() => (MAX_FAILS - currentFails);

        public int GetScore() => score;

        public int GetStreak() => streak;

        public void CleanUp()
        {
            jokers = 1;
            currentFails = 0;
            currentWins = 0;
            score = 0;
            streak = 0;
            scoreMultiplier = 0;
        }

        public int GetAttemptCount() => (currentFails + currentWins);

        public void UseJoker()
        {
            jokers--;
        }

        #endregion
    }
}
