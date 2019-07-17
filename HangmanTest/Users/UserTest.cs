﻿using Data.Entities.Users;
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
        public static void UsersArgumentTest(List<User> users)
        {
            Assert.IsNotNull(users);

            if (users.Count == 0)
            {
                throw new ArgumentException("No users found!");
            }

            foreach (var user in users)
            {
                if (string.IsNullOrWhiteSpace(user.Username))
                {
                    throw new ArgumentException("User has whitespace characters or none: " + user.ToString());
                }
            }
        }

        [TestMethod]
        public static void UserArgumentTest(User user)
        {
            Assert.IsNotNull(user);

            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentException("User has whitespace characters or none: " + user.ToString());
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
        public static void UserGUIDTest(User user)
        {
            if (user.ID == Guid.Empty)
            {
                throw new ArgumentException("User has empty GUID: " + user.ToString());
            }

            if (user.ID.GetType() != typeof(Guid))
            {
                throw new ArgumentException("User does not have GUID ID: " + user.ToString());
            }
        }

        [TestMethod]
        public static void TokenTest()
        {
            throw new NotImplementedException();
        }
    }
}
