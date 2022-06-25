using CardFile.DAL.Enums;

namespace CardFile.DAL.Entities
{
    public class Reaction : BaseEntity
    {
        public int TextId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public Assessments Assessment { get; set; }
        public TextMaterial Text { get; set; }
    }
}
