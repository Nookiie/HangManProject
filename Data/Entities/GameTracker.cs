using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    /// <summary>
    /// Списък от възможни думи за всяка инстанция на бесеничка
    /// </summary>
    public class GameTracker : BaseEntity, IWordList
    {
        #region Constructor

        public GameTracker(string name, List<Word> words)
        {
            foreach (var word in words)
            {
                this.Words.Add(word);
            }
            this.Name = name;
        }

        public GameTracker(List<Word> words)
        {
            foreach (var word in words)
            {
                this.Words.Add(word);
            }
        }

        #endregion

        #region Properties

        public List<Word> Words { get; set; }

        private const int WORD_SIZE_THRESHOLD = 10;

        private const int MAX_FAILS = 5;

        public int CurrentFails { get; set; } = 0;

        #endregion

        #region Methods

        public void ChangeWordName(Word word, string name)
        {
            word.Name = name;
        }

        public Word GetWordByName(string name)
        {
            return Words.Find(x => x.Name == name);
        }

        public Word GetRandomWord()
        {
            if (Words.Count == 0)
                return null;

            Random rnd = new Random();
            int randomIndex = rnd.Next(0, Words.Count - 1);

            return Words[randomIndex];
        }

        public bool GuessWord()
        {
            throw new NotImplementedException();
        }

        public bool Fail()
        {
            CurrentFails++;

            if (CurrentFails > MAX_FAILS)
                return true;
            else
                return false;
        }   

        public bool CheckDictionary()
        {
            foreach (var word in Words)
            {
                if (word.Name.Length > WORD_SIZE_THRESHOLD)
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

        public void CleanUp()
        {
            CurrentFails = 0;
        }

        #endregion
    }
}
