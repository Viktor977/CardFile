using CardFile.DAL.Enums;

namespace CardFile.DAL.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Roles Role { get; set; }
      
        public UserProfile Profile { get; set; }

    }
}
