using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;



namespace HangmanLogic.Logic
{
    public enum GameCondition
    {
        Lost,
        Won
    }

    public static class GameLogic
    {
        public static void PrintMenu()
        {
            Console.WriteLine("Welcome to the Hangman Game!");
            Console.WriteLine("N = New Game");
            Console.WriteLine("D = New Dictionary");
            Console.WriteLine("C = Choose Difficulty");
            Console.WriteLine("F = New Category");
            Console.WriteLine("Esc = Exit");
        }

        public static void Initialize()
        {
            while (true)
            {
                PrintMenu();
                string key = Console.Read().ToString();

                if (key == "N")
                {
                    Console.WriteLine("Please input a category");
                    string category = Console.ReadLine();

                    Console.WriteLine("Please select a difficulty");
                    Console.WriteLine("1 - Easy");
                    Console.WriteLine("2 - Normal");
                    Console.WriteLine("3 - Hard");
                    Console.WriteLine("4 - Insane");
                    int difficultyIndex = Console.Read();

                    switch (difficultyIndex)
                    {
                        case 1: StartGame(category, Difficulty.Easy); break;
                        case 2: StartGame(category, Difficulty.Normal); break;
                        case 3: StartGame(category, Difficulty.Hard); break;
                        case 4: StartGame(category, Difficulty.Insane); break;
                    }
                }

                if (key == "Esc")
                    break;

            }
        }

        public static void StartGame(string category, Difficulty difficulty)
        {
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
            gameTracker.CheckWordsForErrors();

            Word chosenWord = gameTracker.GetRandomWord();

            while (true)
            {
                Console.Clear();
                PrintGameData(chosenWord, gameTracker);

                char input = (char)Console.Read();

                if (gameTracker.GuessCharacterInWord(input))
                {
                    if (gameTracker.Win())
                    {
                        GameOver(GameCondition.Won);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if (gameTracker.Fail())
                    {
                        GameOver(GameCondition.Lost);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        public static void GameOver(GameCondition gameCondition)
        {
            if(gameCondition == GameCondition.Won)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("You lose!");
            }

        }

        public static void CleanUp(GameTracker gameTracker)
        {
            gameTracker.CleanUp();
        }

        public static void PrintGameData(Word chosenWord, IGameTracker gameTracker)
        {
            for (int i = 0; i < chosenWord.Name.Length - 1; i++)
                Console.Write("_");

            Console.WriteLine("Please input a character:");
            Console.WriteLine("Number of attempts:" + gameTracker.GetAttemptCount());
            Console.WriteLine("Number of jokers:" + gameTracker.GetJokerCount());
        }

        public static void PrintStatistics(Word chosenWord, IGameTracker gameTracker)
        {
            Console.WriteLine("Number of attempts:" + gameTracker.GetAttemptCount());
            Console.WriteLine("Jokers used:" + gameTracker.GetJokerCount());
            Console.WriteLine("Word:" + chosenWord.Name);
            Console.WriteLine("Score:" + gameTracker.GetScore());
        }
    }
}
