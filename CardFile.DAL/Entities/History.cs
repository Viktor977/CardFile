using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.DAL.Entities
{
   public  class History : BaseEntity
    {
        public int TextId { get; set; }
        public int ReaderId { get; set; }
        public DateTime LastAction { get; set; }

        public User User { get; set; }
        public TextMaterial Material { get; set; }
    }
}
