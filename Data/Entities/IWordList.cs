using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public interface IWordList
    {
        bool GuessWord();

        bool CheckDictionary();

        Word GetWordByName(string name);

        void PopulateDictionary(List<Word> words);

        void ChangeWordName(Word word, string name);
    }
}
