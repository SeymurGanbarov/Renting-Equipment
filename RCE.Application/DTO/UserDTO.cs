using RCE.Commons.Abstracts;
using System;

namespace RCE.Application.DTOs
{
    public class UserDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
