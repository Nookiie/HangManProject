using System;
using System.Collections.Generic;
using System.Text;
using HM.Data.Abstraction;
using HM.Data.Enums;

namespace HM.Data.Entities.GameItems
{
    /// <summary>
    /// The Main Game Manager that coordinates and manages the wordlist
    /// </summary>
    public class GameTracker : BaseEntity, IGameTracker // github.com/NikolayIT
    {
        #region Constructor

        public GameTracker()
        {

        }

        public GameTracker(string name, List<Word> words, GameDifficulty difficulty)
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

        public GameTracker(List<Word> words, GameDifficulty difficulty)
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

        private int _currentFails = 0;

        private int _currentWins = 0;

        private int _jokers = 1;

        private int _streak = 0;

        private int _scoreMultiplier = 1;

        private int _score = 0;

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
            _currentWins++;
            _streak++;
            _score += DEFAULT_SCORE_MULTIPLIER * (_scoreMultiplier + _streak);

            if (_currentWins == chosenWord.Name.Length - 1)
                return true;
            else
                return false;
        }

        public bool Fail()
        {
            _currentFails++;
            _streak = 0;

            if (_currentFails >= MAX_FAILS)
                return true;
            else
                return false;
        }

        public void SetMultiplier(GameDifficulty difficulty)
        {
            switch (difficulty)
            {
                case GameDifficulty.Easy: _scoreMultiplier = 1; break;
                case GameDifficulty.Normal: _scoreMultiplier = 2; break;
                case GameDifficulty.Hard: _scoreMultiplier = 3; break;
                case GameDifficulty.Insane: _scoreMultiplier = 4; break;
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

        public int GetJokerCount() => _jokers;

        public int GetTries() => (MAX_FAILS - _currentFails);

        public int GetScore() => _score;

        public int GetStreak() => _streak;

        public void CleanUp()
        {
            _jokers = 1;
            _currentFails = 0;
            _currentWins = 0;
            _score = 0;
            _streak = 0;
            _scoreMultiplier = 0;
        }

        public int GetAttemptCount() => (_currentFails + _currentWins);

        public void UseJoker()
        {
            _jokers--;
        }

        #endregion
    }
}
