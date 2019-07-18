using HM.Data.Entities.GameItems;
using System;
using System.Collections.Generic;
using HM.Data.Entities.Difficulty;
using HM.Data.Abstraction;
using HangmanLogic.Logic;
using HM.Data.Entities.GameCondition;
using HM.Logic.Logic;
using NUnit.Framework;

namespace HangmanTest
{
    public static class LogicTest
    {
        #region Console
        [Theory]
        public static void GameConditionArgumentTest()
        {
            GameCondition gameCondition = new GameCondition();
            switch (gameCondition)
            {
                case GameCondition.Lost: return;
                case GameCondition.Won: return;
                default: throw new ArgumentException("Unknown game condition");
            }
        }

        [Theory]
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

        [Theory]
        public static void CleanupTest()
        {
            GameData gameTracker = new GameData();
            gameTracker.CleanUp();

            var expectedValue = 0;

            Assert.AreEqual(expectedValue, gameTracker.GetScore());
            Assert.AreEqual(expectedValue, gameTracker.GetAttemptCount());
        }

        [Theory]
        public static void DifficultyScoreTest()
        {
            GameDifficulty difficulty = new GameDifficulty();
            GameData gameData = new GameData();

            var expectedScoreOnWinEasy = 10;
            var expectedScoreOnWinNormal = 15;
            var expectedScoreOnWinHard = 20;
            var expectedScoreOnWinInsane = 25;

            gameData.Win(new Word("example"));
            switch (difficulty)
            {
                case GameDifficulty.Easy: Assert.AreEqual(expectedScoreOnWinEasy, gameData.GetScore()); break;
                case GameDifficulty.Normal: Assert.AreEqual(expectedScoreOnWinNormal, gameData.GetScore()); break;
                case GameDifficulty.Hard: Assert.AreEqual(expectedScoreOnWinHard, gameData.GetScore()); break;
                case GameDifficulty.Insane: Assert.AreEqual(expectedScoreOnWinInsane, gameData.GetScore()); break;
                default: throw new ArgumentException("Unknown game difficulty: " + difficulty.ToString());
            }
        }

        [Theory]
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

        [Theory]
        public static void GameTrackerWinTest()
        {
            GameData gameTracker = new GameData();
            Word chosenWord = new Word("Example");

            var expectedAttempts = 1;
            var expectedTriesOnWin = 9;

            gameTracker.Win(chosenWord);

            Assert.AreEqual(expectedAttempts, gameTracker.GetAttemptCount());
            Assert.AreEqual(expectedTriesOnWin, gameTracker.GetTries());
        }

        [Theory]
        public static void GameOverWinEffectOnTriesTest()
        {
            Word word = new Word("score");

            IGameData gameTracker = new GameData();
            var expectedTriesOnWin = 9;

            gameTracker.Win(word);

            Assert.AreEqual(expectedTriesOnWin, gameTracker.GetTries());
        }

        [Theory]
        public static void GetRandomLetterTest()
        {
            GameLogicBlazor gameLogic = new GameLogicBlazor();

            gameLogic.chosenWordDisplay = new Word("elephant");
            gameLogic.printWordDisplay = new Word("_ _ _ _ _ _ _ _");

            var unexpectedPrintWord = new Word("e _ e _ _ _ _ _");

            foreach (var letter in gameLogic.chosenWordDisplay.Name)
            {
                gameLogic.Joker();
                Assert.AreNotEqual(unexpectedPrintWord.Name, gameLogic.printWordDisplay.Name);
            }
        }
        #endregion

        #region Blazor

        [Theory]
        public static void GameLogicBlazorCleanupTest()
        {
            GameLogicBlazor gameLogic = new GameLogicBlazor();
            gameLogic.attempts = 12;
            gameLogic.chosenWordDisplay = new Word("example");
            gameLogic.printWordDisplay = new Word("example");
            gameLogic.tries = 4;
            gameLogic.score = 45;
            gameLogic.wordCount = 12;

            gameLogic.CleanUp();

            Assert.AreEqual(0, gameLogic.attempts);
            Assert.AreEqual(0, gameLogic.tries);
            Assert.AreEqual(0, gameLogic.score);
            Assert.AreEqual(1, gameLogic.jokers);
        }

        [Theory]
        public static void GameLogicBlazorStartFlagTest()
        {
            GameLogicBlazor gameLogicBlazor = new GameLogicBlazor();
            gameLogicBlazor.StartGame();

            Assert.IsTrue(gameLogicBlazor.gameInProgress);
        }

        [Theory]
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

        [Theory]
        public static void GameLogicBlazorJokerTest()
        {
            GameLogicBlazor gameLogicBlazor = new GameLogicBlazor();
            gameLogicBlazor.chosenWordDisplay = new Word("Example");
            gameLogicBlazor.StartGame();

            var expectedJokers = gameLogicBlazor.jokers;
            gameLogicBlazor.Joker();

            Assert.AreEqual(expectedJokers - 1, gameLogicBlazor.jokers);
        }

        [Theory]
        public static void GameLogicBlazorEndGameTest()
        {
            GameLogicBlazor gameLogic = new GameLogicBlazor();
            var expectedTries = 0;

            gameLogic.EndGame(GameCondition.Lost);
            Assert.AreEqual(expectedTries, gameLogic.tries);
        }

        [Theory]
        public static void GameLogicBlazorWordGuessTest()
        {
            GameLogicBlazor gameLogic = new GameLogicBlazor();
            gameLogic.chosenWordDisplay = new Word("pineapple");
            gameLogic.printWordDisplay = new Word("_________");
            gameLogic.GetInput();
            gameLogic.guessLetter = 'i';
            gameLogic.GuessLetter();

            var printWordExpected = "_i_______";

            if (gameLogic.chosenWordDisplay.Name.Contains(gameLogic.guessLetter))
            {
                Assert.AreEqual(gameLogic.printWordDisplay.Name, printWordExpected);
            }
        }

        [Theory]
        public static void GameLogicBlazorWordGuessMinPriorityTest()
        {
            GameLogicBlazor gameLogic = new GameLogicBlazor();

            gameLogic.chosenWordDisplay = new Word("coffee");
            gameLogic.printWordDisplay = new Word("______");

            gameLogic.Joker();

            var printWordUnexpected = "__ff__";
            var printWordUnexpectedAlt = "____ee";

            Assert.AreNotEqual(gameLogic.printWordDisplay.Name, printWordUnexpected);
            Assert.AreNotEqual(gameLogic.printWordDisplay.Name, printWordUnexpectedAlt);
        }

        #endregion
    }
}

