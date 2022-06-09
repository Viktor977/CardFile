using CardFile.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.DAL.Entities
{
   public class Reaction : BaseEntity
    {
        public int? UserId { get; set; }
        public string Comment { get; set; }
        public Assessments Assessment { get; set; }
        public TextMaterial Text { get; set; }
    }
}
