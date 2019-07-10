using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public interface IGameTracker
    {
        bool GuessCharacterInWord(char input, Word word);

        bool CheckWordsForErrors();

        Word GetRandomWord();

        void PopulateDictionary(List<Word> words);

        void ChangeWordName(Word word, string name);

        bool Win(Word chosenWord);

        bool Fail();

        int GetJokerCount();

        int GetTries();

        int GetAttemptCount();

        int GetScore();

        void CleanUp();

        void UseJoker();
    }
}
