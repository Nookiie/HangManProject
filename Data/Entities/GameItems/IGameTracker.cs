using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public interface IGameTracker
    {
        bool GuessCharacterInWord(char input);

        bool CheckWordsForErrors();

        Word GetRandomWord();

        Word GetWordByName(string name);

        void PopulateDictionary(List<Word> words);

        void ChangeWordName(Word word, string name);

        bool Win();

        bool Fail();

        void AssignWord(Word word);

        int GetJokerCount();

        int GetAttemptCount();

        int GetScore();

        void CleanUp();
    }
}
