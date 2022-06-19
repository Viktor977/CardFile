using CardFile.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.ModelsDto
{
   public class UserDto 
    {
         public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Roles Role { get; set; }
        public UserProfileDto UserProfileDto { get; set; }

    }
}
