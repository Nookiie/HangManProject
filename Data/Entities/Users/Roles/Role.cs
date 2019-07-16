using System;
using System.Collections.Generic;
using System.Text;

namespace HM.Data.Entities.Users.Role
{
    public enum Role
    {
        User,
        Admin
    }

    public static class UserExtensions
    {
        public static string ToDisplayString(Role role)
        {
            switch (role)
            {
                case Role.User: return "user";
                case Role.Admin: return "admin";
                default: throw new ArgumentException("Unknown user role type: " + role.ToString());
            }
        }
    }
}
