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
        public static void InputGuessTest(char input)
        {
            if (char.IsWhiteSpace(input))
            {
                throw new ArgumentException("Input Symbol has whitespaces!");
            }

            if (char.IsUpper(input))
            {
                throw new ArgumentException("Input Symbol has upper-case letters");
            }
        }

        [TestMethod]
        public static void InputGameConditionTest(GameCondition gameCondition)
        {
            if (gameCondition != GameCondition.Won || gameCondition != GameCondition.Lost)
            {
                throw new ArgumentException("GameCondition must have only values Won or Lost");
            }
        }

        [TestMethod]
        public static void InputGameDifficultyTest(GameDifficulty gameDifficulty)
        {
            if (gameDifficulty != GameDifficulty.Easy || gameDifficulty != GameDifficulty.Normal
               || gameDifficulty != GameDifficulty.Hard || gameDifficulty != GameDifficulty.Insane)
            {
                throw new ArgumentException("Game Difficulty must have only values: Easy, Normal, Hard, Insane");
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
        public static void GameTrackerListTest(List<Word> words)
        {
            if (words.Count == 0)
            {
                throw new ArgumentException("List of words is empty");
            }

            foreach (var word in words)
            {
                if (word.Name.Contains(" "))
                {
                    throw new ArgumentException("One or more words contain whitespaces");
                }
                foreach (var letter in word.Name)
                {
                    if (char.IsUpper(letter))
                    {
                        throw new ArgumentException("No word should have upper-case letters");
                    }
                }
            }
        }

        [TestMethod]
        public static void DifficultyScoreTest(GameDifficulty difficulty)
        {
            IGameData gameTracker = new GameData();

            var expectedScoreOnWinEasy = 10;
            var expectedScoreOnWinNormal = 15;
            var expectedScoreOnWinHard = 20;
            var expectedScoreOnWinInsane = 25;

            Assert.IsNotNull(difficulty);

            switch (difficulty)
            {
                case GameDifficulty.Easy: Assert.AreEqual(expectedScoreOnWinEasy, gameTracker.GetScore()); break;
                case GameDifficulty.Normal: Assert.AreEqual(expectedScoreOnWinNormal, gameTracker.GetScore()); break;
                case GameDifficulty.Hard: Assert.AreEqual(expectedScoreOnWinHard, gameTracker.GetScore()); break;
                case GameDifficulty.Insane: Assert.AreEqual(expectedScoreOnWinInsane, gameTracker.GetScore()); break;
                default: throw new ArgumentException("Different type of difficulty assigned");
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
        public static void GameOverWinEffectOnTriesTest(Word word, GameDifficulty difficulty)
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
            char input = GameLogic.GetJoker(gameData, chosenWord, printWord);

            if (!chosenWord.Name.Contains(input))
            {
                Assert.Fail("Letter is not part of the chosen word");
            }
        }

        [TestMethod]
        public static void GetRandomLetterMinPriorityTest()
        {
            List<Word> words = new List<Word>
            {
                new Word("elephant"),
            };

            var notExpectedLetter = 'e';

            GameData gameData = new GameData();

            gameData.Words = words;

            Word chosenWord = gameData.GetRandomWord();
            Word printWord = chosenWord;
            char input = GameLogic.GetJoker(gameData, chosenWord, printWord);

            Assert.AreNotEqual(notExpectedLetter, input);
        }

        [TestMethod]
        public static void GameOverConditionTest(GameCondition gameCondition)
        {

        }
    }
}

