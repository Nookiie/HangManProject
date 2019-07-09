using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLogic.Logic
{
    public class GameLogic
    {
        // List<Word> words = new List<Word>();

        // WordList word = new WordList("WordList #1", words);

        public void PrintMenu()
        {
            Console.WriteLine("Welcome to the Hangman Game!");
            Console.WriteLine("N = New Game");
            Console.WriteLine("D = New Dictionary");
            Console.WriteLine("Esc = Exit");
        }

        public void CleanUp()
        {

        }

        public void StartGame()
        {
            IGameTracker wordList;
            PrintMenu();
        }

        public void GameOver()
        {

        }

        public void Fail()
        {

        }
    }
}
