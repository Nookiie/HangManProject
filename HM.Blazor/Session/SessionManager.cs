using Data.Entities.Users;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HM.Blazor.Session
{
    public class SessionManager : ComponentBase
    {
        public User CurrentSession { get; set; } = new User();

        public void MapToSession(User user)
        {
            CurrentSession.ID = user.ID;
            CurrentSession.Username = user.Username;
            CurrentSession.Password = user.Password;
            CurrentSession.Email = user.Email;
            CurrentSession.Role = user.Role;
            CurrentSession.Token = user.Token;
        }
    }
}
