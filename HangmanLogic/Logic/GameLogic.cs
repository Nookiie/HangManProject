﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
            // Console.WriteLine("D = New Dictionary");
            Console.WriteLine("C = Choose Difficulty");
            // Console.WriteLine("F = New Category");
            Console.WriteLine("Esc = Exit");
        }

        public static void Initialize()
        {
            Console.Clear();
            while (true)
            {
                PrintMenu();
                string input = Console.ReadLine();

                if (input == "N")
                {
                    Console.WriteLine("Please input a category");
                    string category = Console.ReadLine();

                    Console.WriteLine("Please select a difficulty");
                    Console.WriteLine("1 - Easy");
                    Console.WriteLine("2 - Normal");
                    Console.WriteLine("3 - Hard");
                    Console.WriteLine("4 - Insane");
                    int difficultyIndex = Int32.Parse(Console.ReadLine());

                    switch (difficultyIndex)
                    {
                        case 1: StartGame(category, Difficulty.Easy); break;
                        case 2: StartGame(category, Difficulty.Normal); break;
                        case 3: StartGame(category, Difficulty.Hard); break;
                        case 4: StartGame(category, Difficulty.Insane); break;
                        default: Console.WriteLine("No such value"); break;
                    }
                }
            }
        }

        public static void StartGame(string category, Difficulty difficulty)
        {
            List<Word> words = new List<Word>
            {
                new Word("Apple"),
                new Word("Stuff"),
                new Word("Elephant"),
                new Word("Archipelago"),
                new Word("Imagination")
            };

            IGameTracker gameTracker = new GameTracker(category, words, difficulty);
            gameTracker.CheckWordsForErrors();

            Word chosenWord = gameTracker.GetRandomWord();
            Word printWord = new Word();
            printWord.Name = chosenWord.Name;

            printWord.Name = new Regex("\\S").Replace(chosenWord.Name, "_ ");
            gameTracker.AssignWord(chosenWord);

            while (true)
            {
                Console.Clear();
                PrintGameData(printWord, gameTracker);

                char input = (char)Console.Read();

                if (gameTracker.GuessCharacterInWord(input))
                {
                    if (gameTracker.Win())
                    {
                        GameOver(chosenWord, gameTracker, GameCondition.Won);
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < printWord.Name.Length; i++)
                        {
                            if(chosenWord.Name[i] == input)
                            {
                                printWord.Name[i] = input;
                            }
                        }
                        continue;
                    }
                }
                else if (!gameTracker.GuessCharacterInWord(input))
                {
                    if (gameTracker.Fail())
                    {
                        GameOver(chosenWord, gameTracker, GameCondition.Lost);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                else if (input == '!')
                {
                    // gameTracker.RevealRandomWord();
                }
            }
        }

        public static void GameOver(Word chosenWord, IGameTracker gameTracker, GameCondition gameCondition)
        {
            if (gameCondition == GameCondition.Won)
            {
                Console.Clear();
                Console.WriteLine("You win!");
                PrintStatistics(chosenWord, gameTracker);
                CleanUp(gameTracker);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You lose!");
                PrintStatistics(chosenWord, gameTracker);
                CleanUp(gameTracker);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
        public static void PrintGameData(Word printWord, IGameTracker gameTracker)
        {
            for (int i = 0; i < printWord.Name.Length; i++)
            {
                Console.Write(printWord.Name[i]);
            }

            Console.WriteLine("Please input a character:");
            Console.WriteLine("Number of attempts:" + gameTracker.GetAttemptCount());
            Console.WriteLine("Number of jokers:" + gameTracker.GetJokerCount());
            Console.WriteLine("Input ! to use a Joker");
        }

        public static void PrintStatistics(Word chosenWord, IGameTracker gameTracker)
        {
            Console.WriteLine("Number of attempts:" + gameTracker.GetAttemptCount());
            Console.WriteLine("Jokers available:" + gameTracker.GetJokerCount());
            Console.WriteLine("Word:" + chosenWord.Name);
            Console.WriteLine("Score:" + gameTracker.GetScore());
        }

        public static void CleanUp(IGameTracker gameTracker)
        {
            gameTracker.CleanUp();
        }
    }
}
