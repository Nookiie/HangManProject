using HM.Data.Entities.GameItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HM.Data.Entities.Difficulty;
using HM.Data.Abstraction;
using HangmanLogic.Logic;
using HM.Data.Entities.GameCondition;

namespace HangmanTest
{
    [TestClass]
    public static class LogicTest
    {
        [TestMethod]
        [TestCategory("Argument")]
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

        [TestMethod]
        [TestCategory("Argument")]
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

        [TestMethod]
        [TestCategory("Cleanup")]
        public static void CleanupTest()
        {
            IGameData gameTracker = new GameData();
            gameTracker.CleanUp();

            int expectedValue = 0;

            Assert.AreEqual(expectedValue, gameTracker.GetTries());
            Assert.AreEqual(expectedValue, gameTracker.GetScore());
            Assert.AreEqual(expectedValue, gameTracker.GetAttemptCount());
        }

        [TestMethod]
        [TestCategory("Argument")]
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

        [TestMethod]
        public static void DifficultyScoreTest(GameDifficulty difficulty)
        {
            Assert.IsNotNull(difficulty);

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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public static void GameOverWinEffectOnTriesTest(Word word)
        {
            IGameData gameTracker = new GameData();
            var expectedTriesOnWin = 9;

            gameTracker.Win(word);

            Assert.AreEqual(expectedTriesOnWin, gameTracker.GetTries());
        }

        [TestMethod]
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

        [TestMethod]
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

