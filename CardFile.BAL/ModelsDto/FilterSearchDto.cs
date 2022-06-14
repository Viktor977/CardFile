using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.BAL.ModelsDto
{
   public class FilterSearchDto
    {
        public string  TitleText { get; set; }
        public string  Author { get; set; }
        public DateTime? DataPublication { get; set; }
    }
}
