using CardFile.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.ModelsDto
{
    public class ReactionDto 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public Assessments Assessment { get; set; }
    }
}
