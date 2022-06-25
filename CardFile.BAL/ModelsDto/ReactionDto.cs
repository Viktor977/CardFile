using CardFile.DAL.Enums;

namespace CardFile.BAL.ModelsDto
{
    public class ReactionDto 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TextId { get; set; }
        public string Comment { get; set; }
        public Assessments Assessment { get; set; }
    }
}
