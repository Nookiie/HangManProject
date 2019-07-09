using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLogic.Logic
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard,
        Insane
    }

    public class GameLogic
    {
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

        public void StartGame(string category, Difficulty difficulty)
        {
            PrintMenu();

            IGameTracker gameTracker;
            List<Word> words = new List<Word>
            {
                new Word("Apple"),
                new Word("Stuff"),
                new Word("Elephant"),
                new Word("Archipelago"),
                new Word("Imagination")
            };

            gameTracker = new GameTracker(category, words, difficulty);
        }

        public void GameOver()
        {

        }

        public void Fail()
        {

        }
    }
}
