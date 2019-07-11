using Data.Entities;
using HM.Data.Abstraction;
using HM.Data.Entities.Difficulty;
using HM.Data.Entities.GameCondition;
using HM.Data.Entities.GameItems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HangmanLogic.Logic
{
    public static class GameLogic
    {
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Hangman Game!");
            Console.WriteLine("n = New Game");
            // Console.WriteLine("D = New Dictionary");
            // Console.WriteLine("c = Choose GameDifficulty");
            // Console.WriteLine("F = New Category");
            Console.WriteLine("Esc = Exit");
        }

        public static void Initialize()
        {
            Console.Clear();
            while (true)
            {
                PrintMenu();
                char input = Console.ReadKey().KeyChar;

                if (input == 'n')
                {
                    Console.Clear();
                    Console.WriteLine("Please input a category (name for GameTracker)");
                    string category = Console.ReadLine();

                    Console.WriteLine("Please select a GameDifficulty");
                    Console.WriteLine("1 - Easy");
                    Console.WriteLine("2 - Normal");
                    Console.WriteLine("3 - Hard");
                    Console.WriteLine("4 - Insane");
                    char GameDifficultyIndex = Console.ReadKey().KeyChar;

                    switch (GameDifficultyIndex)
                    {
                        case '1': StartGame(category, GameDifficulty.Easy); break;
                        case '2': StartGame(category, GameDifficulty.Normal); break;
                        case '3': StartGame(category, GameDifficulty.Hard); break;
                        case '4': StartGame(category, GameDifficulty.Insane); break;
                        default: Console.WriteLine("No such value"); break;
                    }
                }

                if ((ConsoleKey)input == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        public static void StartGame(string category, GameDifficulty GameDifficulty)
        {
            List<Word> words = new List<Word>
            {
                new Word("apple"),
                new Word("stuff"),
                new Word("elephant"),
                new Word("archipelago"),
                new Word("imagination")
            };

            IGameTracker gameTracker = new GameTracker(category, words, GameDifficulty);
            gameTracker.CheckWordsForErrors();

            Word chosenWord = gameTracker.GetRandomWord();
            Word printWord = new Word();
            printWord.Name = chosenWord.Name;

            printWord.Name = new Regex("\\S").Replace(chosenWord.Name, "_ ");
            while (true)
            {
                Console.Clear();
                PrintGameData(printWord, gameTracker);

                char input = Console.ReadKey().KeyChar;

                if (input == '!')
                {
                    if (gameTracker.GetJokerCount() > 0)
                        input = Joker(gameTracker, chosenWord, printWord);
                    else
                        continue;
                }

                if (gameTracker.GuessCharacterInWord(input, chosenWord) && !printWord.Name.Contains(input))
                {
                    if (gameTracker.Win(chosenWord))
                    {
                        GameOver(chosenWord, gameTracker, GameCondition.Won);
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < chosenWord.Name.Length; i++)
                        {
                            if (chosenWord.Name[i] == input)
                            {
                                StringBuilder sb = new StringBuilder(printWord.Name);
                                sb[i] = input;
                                printWord.Name = sb.ToString();
                            }
                        }
                        continue;
                    }
                }
                else if (!gameTracker.GuessCharacterInWord(input, chosenWord))
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
            Console.WriteLine("Number of attempts:" + gameTracker.GetTries());
            Console.WriteLine("Number of jokers:" + gameTracker.GetJokerCount());
            Console.WriteLine("Input ! to use a Joker");
        }

        public static void PrintStatistics(Word chosenWord, IGameTracker gameTracker)
        {
            Console.WriteLine("Attempts made:" + gameTracker.GetAttemptCount());
            Console.WriteLine("Jokers available:" + gameTracker.GetJokerCount());
            Console.WriteLine("Word:" + chosenWord.Name);
            Console.WriteLine("Score:" + gameTracker.GetScore());
        }

        public static char Joker(IGameTracker gameTracker, Word chosenWord, Word printWord)
        {
            while (true)
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next(0, chosenWord.Name.Length - 1);
                char input = chosenWord.Name[randomIndex];

                if (printWord.Name.Contains(input)) // Find me another letter if it's already on the guessed list
                {
                    continue;
                }
                else
                {
                    gameTracker.UseJoker();
                    return input;
                }
            }
        }

        public static void CleanUp(IGameTracker gameTracker)
        {
            gameTracker.CleanUp();
        }
    }
}
