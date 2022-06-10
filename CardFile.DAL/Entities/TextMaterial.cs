using CardFile.DAL.Enums;
using System;
using System.Collections.Generic;

namespace CardFile.DAL.Entities
{
    public class TextMaterial : BaseEntity
    {
        public string Title { get; set; }
        public string Article { get; set; }
        public string Author { get; set; }
        public DateTime DatePublish { get; set; }
        public Allows Allows { get; set; }
        public virtual ICollection<History> Users { get; set; }//TODO
        public ICollection<Reaction> Reactions { get; set; }
    }
}
