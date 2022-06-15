using System;

namespace CardFile.BAL.ModelsDto
{
    /// <summary>
    /// This class is used to search for a given parameter
    /// </summary>
    public class FilterSearchDto
    {
        public string  TitleText { get; set; }
        public string  Author { get; set; }
        public DateTime DataPublication { get; set; }
    }
}
