using System;
using Flyon.Common.Enums;

namespace Flyon.IServices.Requests
{
    public class CreateUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public string Email { get; set; }
        
        public Gender Gender { get; set; }
        
        public DateTime BirthDate { get; set; }

    }
}