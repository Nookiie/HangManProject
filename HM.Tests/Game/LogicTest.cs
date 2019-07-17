using HM.Data.Entities.GameItems;
using System;
using System.Collections.Generic;
using HM.Data.Entities.Difficulty;
using HM.Data.Abstraction;
using HangmanLogic.Logic;
using HM.Data.Entities.GameCondition;
using HM.Logic.Logic;
using Xunit;
using NUnit.Framework;

namespace HangmanTest
{
    [TestFixture]
    public static class LogicTest
    {
        [Fact]
        public static void GameConditionArgumentTest()
        {
            GameCondition gameCondition = new GameCondition();
            switch (gameCondition)
            {
                case GameCondition.Lost: return;
                case GameCondition.Won:  return;
                default: throw new ArgumentException("Unknown game condition");
            }
        }

        [Fact]
        public static void GameDifficultyArgumentTest()
        {
            GameDifficulty gameDifficulty = new GameDifficulty();
            switch (gameDifficulty)
            {
                case GameDifficulty.Easy: return; 
                case GameDifficulty.Normal: return; 
                case GameDifficulty.Hard: return; 
                case GameDifficulty.Insane: return; 
                default: throw new ArgumentException("Unknown game difficulty: " + gameDifficulty.ToString());
            }
        }

        [Fact]
        public static void CleanupTest()
        {
            IGameData gameTracker = new GameData();
            gameTracker.CleanUp();

            int expectedValue = 0;

            Assert.AreEqual(expectedValue, gameTracker.GetTries());
            Assert.AreEqual(expectedValue, gameTracker.GetScore());
            Assert.AreEqual(expectedValue, gameTracker.GetAttemptCount());
        }

        [Fact]
        public static void GameDataArgumentTest()
        {
            GameData gameData = new GameData();
            Assert.IsNotNull(gameData);
            
            if (gameData.Words.Count == 0)
            {
                throw new ArgumentException("List of words is empty:" + gameData.ToString());
            }
            
            foreach (var word in gameData.Words)
            {
                if (string.IsNullOrWhiteSpace(word.Name))
                {
                    throw new ArgumentException("Word name contains whitespace or has none: " + word.ToString());
                }
                foreach (var letter in word.Name)
                {
                    if (char.IsUpper(letter))
                    {
                        throw new ArgumentException("Word name has upper-case letters: " + word.ToString());
                    }
                }
            }
        }

        [Fact]
        public static void DifficultyScoreTest()
        {
            GameDifficulty difficulty = new GameDifficulty();

            IGameData gameTracker = new GameData();

            var expectedScoreOnWinEasy = 10;
            var expectedScoreOnWinNormal = 15;
            var expectedScoreOnWinHard = 20;
            var expectedScoreOnWinInsane = 25;

            switch (difficulty)
            {
                case GameDifficulty.Easy: Assert.AreEqual(expectedScoreOnWinEasy, gameTracker.GetScore()); break;
                case GameDifficulty.Normal: Assert.AreEqual(expectedScoreOnWinNormal, gameTracker.GetScore()); break;
                case GameDifficulty.Hard: Assert.AreEqual(expectedScoreOnWinHard, gameTracker.GetScore()); break;
                case GameDifficulty.Insane: Assert.AreEqual(expectedScoreOnWinInsane, gameTracker.GetScore()); break;
                default: throw new ArgumentException("Unknown game difficulty: " + difficulty.ToString());
            }
        }

        [Fact]
        public static void GameTrackerFailTest()
        {
            IGameData gameTracker = new GameData();

            var expectedAttempts = 1;
            var expectedTriesOnFail = 8;
            var expectedScoreOnFail = 0;

            gameTracker.Fail();

            Assert.AreEqual(expectedAttempts, gameTracker.GetAttemptCount());
            Assert.AreEqual(expectedTriesOnFail, gameTracker.GetTries());
            Assert.AreEqual(expectedScoreOnFail, gameTracker.GetScore());
        }

        [Fact]
        public static void GameTrackerWinTest()
        {
            IGameData gameTracker = new GameData();
            Word chosenWord = new Word();

            var expectedAttempts = 1;
            var expectedTriesOnWin = 9;

            gameTracker.Win(chosenWord);

            Assert.AreEqual(expectedAttempts, gameTracker.GetAttemptCount());
            Assert.AreEqual(expectedTriesOnWin, gameTracker.GetTries());
        }

        [Fact]
        public static void GameOverWinEffectOnTriesTest()
        {
            Word word = new Word("score");

            IGameData gameTracker = new GameData();
            var expectedTriesOnWin = 9;

            gameTracker.Win(word);

            Assert.AreEqual(expectedTriesOnWin, gameTracker.GetTries());
        }

        [Fact]
        public static void GetRandomLetterTest()
        {
            List<Word> words = new List<Word>
            {
                new Word("elephant"),
            };
            GameData gameData = new GameData();

            gameData.Words = words;

            Word chosenWord = gameData.GetRandomWord();
            Word printWord = chosenWord;
            char input = GameLogicConsole.GetJoker(gameData, chosenWord, printWord);

            if (!chosenWord.Name.Contains(input))
            {
                throw new ApplicationException("Letter is not part of the chosen word: " + input.ToString());
            }
        }

        [Fact]
        public static void GameLogicBlazorStartFlagTest()
        {
            GameLogicBlazor gameLogicBlazor = new GameLogicBlazor();
            gameLogicBlazor.StartGame();

            Assert.IsTrue(gameLogicBlazor.gameInProgress);
        }

        [Fact]
        public static void GameLogicBlazorFlagEndGameTest()
        {
            GameLogicBlazor gameLogicBlazor = new GameLogicBlazor();
            gameLogicBlazor.EndGame(GameCondition.Won);

            Assert.IsTrue(gameLogicBlazor.gameFinished);
            Assert.IsTrue(gameLogicBlazor.gameWon);

            gameLogicBlazor.EndGame(GameCondition.Lost);

            Assert.IsTrue(gameLogicBlazor.gameFinished);
            Assert.IsTrue(gameLogicBlazor.gameLost);
        }

        [Fact]
        public static void GameLogicBlazorFlagTest()
        {
            GameLogicBlazor gameLogicBlazor = new GameLogicBlazor();

            var expectedJokers = gameLogicBlazor.jokers;
            gameLogicBlazor.Joker();

            Assert.AreEqual(expectedJokers, gameLogicBlazor.jokers - 1);
        }

        [Fact]
        public static void GetRandomLetterMinPriorityTest()
        {
            List<Word> words = new List<Word>
            {
                new Word("elephant"),
            };

            var unexpectedLetter = 'e';

            GameData gameData = new GameData();

            gameData.Words = words;

            Word chosenWord = gameData.GetRandomWord();
            Word printWord = chosenWord;
            char input = GameLogicConsole.GetJoker(gameData, chosenWord, printWord);

            Assert.AreNotEqual(unexpectedLetter, input);
        }
    }
}

