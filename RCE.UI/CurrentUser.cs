using RCE.Application.DTOs;
using System;
using System.Web;

namespace RCE.UI
{
    public static class CurrentUser
    {
        private static UserDTO _user => (UserDTO)HttpContext.Current.Session["user"];
        public static Guid Id => _user.Id;
        public static string Name => _user.Name;
        public static string Surname => _user.Surname;
        public static string Email => _user.Email;
    }
}