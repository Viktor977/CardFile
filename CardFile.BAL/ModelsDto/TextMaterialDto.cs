using CardFile.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.ModelsDto
{
    public class TextMaterialDto 
    {
        public string Title { get; set; }
        public string Article { get; set; }
        public string Author { get; set; }
        public DateTime DatePublish { get; set; }
        public Allows Allows { get; set; }
        public virtual ICollection<HistoryDto> Users { get; set; }
        public ICollection<ReactionDto> Reactions { get; set; }
    }
}
