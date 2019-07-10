using Data.Entities;
using Data.Entities.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HangmanTest
{
    [TestClass]
    public static class LogicTest
    {
        [TestMethod]
        public static void CleanupTest()
        {
            IGameTracker gameTracker = new GameTracker();
            try
            {
                gameTracker.CleanUp();
            }

            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "Cleanup Vlaues are not properly defined");
                return;
            }
            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public static void InputTest(char input)
        {
            if (char.IsWhiteSpace(input))
            {
                throw new ArgumentException("Input Symbol is whitespace, please change input again");
            }

            if (input.GetType() != typeof(char))
            {
                throw new ArgumentException("Input is not of type char");
            }

            Assert.Fail("No argument exceptions found");
        }

        [TestMethod]
        public static void GameTrackerTest(List<Word> words)
        {
            if (words.Count == 0)
            {
                throw new ArgumentException("List of words is empty");
            }

            foreach (var word in words)
            {
                if (word.Name.Contains(" "))
                {
                    throw new ArgumentException("Word contains whitespace when it shouldn't");
                }
            }

            Assert.Fail("No argument exception found!");
        }

    }
}

