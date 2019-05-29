using RCE.Commons.Abstracts;
using System;

namespace RCE.Infrastructure.DAOs
{
    public class UserDAO : BaseEntityDAO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
