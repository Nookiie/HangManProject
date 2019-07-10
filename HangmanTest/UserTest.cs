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
            Assert.IsNotNull(users);
            if (users.Count == 0)
            {
                Assert.Fail("No users found!");
            }

            foreach (var user in users)
            {
                if (string.IsNullOrWhiteSpace(user.Username))
                {
                    Assert.Fail("Some users have whitespace characteers");
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
