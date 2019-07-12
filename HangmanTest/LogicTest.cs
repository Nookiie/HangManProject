using HM.Data.Entities.GameItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HM.Data.Entities.Difficulty;
using HM.Data.Abstraction;

namespace HangmanTest
{
    [TestClass]
    public static class LogicTest
    {
        [TestMethod]
        public static void InputTest(char input)
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
        [TestCategory("Cleanup")]
        public static void CleanupTest()
        {
            IGameData gameTracker = new GameTracker();
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
        public static void GameTrackerTest(List<Word> words, GameDifficulty difficulty)
        {
            Assert.IsNotNull(words);
            Assert.IsNotNull(difficulty);

            IGameData gameTracker = new GameTracker("GameTrackerTest", words, difficulty);
            Word chosenWord = gameTracker.GetRandomWord();

            var expectedAttempts = 1;
            var expectedTriesOnFail = 8;
            var expectedScoreOnFail = 0;
            var expectedTriesOnWin = 9;
            var expectedScoreOnWinEasy = 10;
            var expectedScoreOnWinNormal = 15;
            var expectedScoreOnWinHard = 20;
            var expectedScoreOnWinInsane = 25;

            gameTracker.Fail();

            Assert.AreEqual(expectedAttempts, gameTracker.GetAttemptCount());
            Assert.AreEqual(expectedTriesOnFail, gameTracker.GetTries());
            Assert.AreEqual(expectedScoreOnFail, gameTracker.GetScore());

            gameTracker.CleanUp();

            gameTracker.Win(chosenWord);

            Assert.AreEqual(expectedTriesOnWin, gameTracker.GetTries());
            Assert.AreEqual(expectedAttempts, gameTracker.GetAttemptCount());

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
        public static void GameTrackerTest()
        {

        }
    }
}

