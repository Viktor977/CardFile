using CardFile.DAL.Enums;
using System;
using System.Collections.Generic;

namespace CardFile.BAL.ModelsDto
{
    public class TextMaterialDto 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string Author { get; set; }
        public DateTime DatePublish { get; set; }
        public Allows Allows { get; set; }
        public virtual ICollection<HistoryDto> Users { get; set; }
        public ICollection<ReactionDto> Reactions { get; set; }
    }
}
