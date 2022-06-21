using CardFile.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CardFile.BAL.ModelsDto
{
   public class UserDto 
    {
         public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
        public string Password { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public Roles Role { get; set; }
       

    }
}
