using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.ModelsDto
{
    public class HistoryDto 
    {
        public int Id { get; set; }
        public int TextId { get; set; }
        public int ReaderId { get; set; }
        public DateTime LastAction { get; set; }

        public UserDto User { get; set; }
        public TextMaterialDto Material { get; set; }
    }
}
