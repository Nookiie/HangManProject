using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard,
        Insane
    }

    /// <summary>
    /// The Main Game Manager that coordinates and manages the wordlist
    /// </summary>
    public class GameTracker : BaseEntity, IGameTracker // github.com/NikolayIT
    {
        #region Constructor

        public GameTracker()
        {

        }

        public GameTracker(string name, List<Word> words, Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE_EASY); break;
                case Difficulty.Normal: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE_NORMAL); break;
                case Difficulty.Hard: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE_HARD); break;
                case Difficulty.Insane: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE); break;
                default: words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE); break;
            }

            this.Words = words;
            this.Category = name;
        }

        public GameTracker(List<Word> words, Difficulty difficulty)
        {

            if (difficulty == Difficulty.Easy)
            {
                words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE_EASY);
            }

            else if (difficulty == Difficulty.Normal)
            {
                words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE_NORMAL);
            }

            else if (difficulty == Difficulty.Hard)
            {
                words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE_HARD);
            }

            else if (difficulty == Difficulty.Insane)
            {
                words.RemoveAll(x => x.Name.Length > MAX_WORD_SIZE);
            }

            this.Words = words;
        }

        #endregion

        #region Properties

        public List<Word> Words { get; set; }

        public Word ChosenWord { get; set; }

        public string Category { get; set; }

        #region DifficultyValues

        private const int MAX_WORD_SIZE_EASY = 5;

        private const int MAX_WORD_SIZE_NORMAL = 10;

        private const int MAX_WORD_SIZE_HARD = 15;

        private const int MAX_WORD_SIZE = 20; // Also goes for Insane (max word size value)

        private const int MAX_FAILS = 9;

        private const int SCORE_MULTIPLIER = 5;

        #endregion

        public int CurrentFails { get; set; } = 0;

        public int CurrentWins { get; set; } = 0;

        public int Jokers { get; set; } = 1;

        public int Score { get; set; } = 0;

        #endregion

        #region Methods

        public void ChangeWordName(Word word, string name)
        {
            word.Name = name;
        }

        public Word GetWordByID(int id)
        {
            return Words.Find(x => x.ID == id);
        }

        public Word GetWordByName(string name)
        {
            return Words.Find(x => x.Name == name);
        } // Move the methods somewhere else

        public Word GetRandomWord()
        {
            if (Words.Count == 0)
                return null;

            Random rnd = new Random();
            int randomIndex = rnd.Next(0, Words.Count - 1);

            return Words[randomIndex];
        }

        public void AssignWord(Word word)
        {
            ChosenWord = word;
        }

        public bool GuessCharacterInWord(char input)
        {
            return ChosenWord.Name.Contains(input);
        }

        public bool Fail()
        {
            CurrentFails++;

            if (CurrentFails >= MAX_FAILS)
                return true;
            else
                return false;
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

        public int GetJokerCount() => Jokers;

        public int GetTries() => (MAX_FAILS - CurrentFails);

        public bool Win()
        {
            CurrentWins++;
            Score += SCORE_MULTIPLIER;

            if (CurrentWins == ChosenWord.Name.Length - 1)
                return true;
            else
                return false;
        }

        public int GetScore() => Score;
        #endregion

        public void CleanUp()
        {
            Jokers = 1;
            CurrentFails = 0;
            CurrentWins = 0;
            Score = 0;
        }

        public int GetAttemptCount() => (CurrentFails + CurrentWins);
    }
}
