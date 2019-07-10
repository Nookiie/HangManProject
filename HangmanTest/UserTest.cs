using Data.Entities.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    [TestClass]
    public class UserTest
    {

        [TestMethod]
        public static void UserExceptionTest(List<User> users)
        {
            if (users.Count == 0)
            {
                Assert.Fail("No users found!");
            }

            Assert.IsNotNull(users);
            foreach (var user in users)
            {
                if (string.IsNullOrWhiteSpace(user.Username))
                {
                    throw new ArgumentException("Some users have whitespace characters");
                }
            }
        }

        [TestMethod]
        public static void AddUserToListTest(List<User> users, User user)
        {
            Assert.IsNotNull(users);
            Assert.IsNotNull(user);

            users.Add(user);

        }

        [TestMethod]
        public static void AdminUserListTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public static void TokenTest()
        {
            throw new NotImplementedException();
        }
    }
}
