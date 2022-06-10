namespace CardFile.DAL.Entities
{
    public class UserProfile : BaseEntity
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public User User { get; set; }

    }
}
