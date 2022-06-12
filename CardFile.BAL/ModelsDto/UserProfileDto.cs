using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.ModelsDto
{
    public class UserProfileDto 
    {
        public int Id { get; set; }
         public int UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
    
    }
}
