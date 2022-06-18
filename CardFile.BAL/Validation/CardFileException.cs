using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CardFile.BAL.Validation
{
    [Serializable]
   public  class CardFileException : ApplicationException
    {
       
        public DateTime TimeException { get; private set; }
        public CardFileException():this("value is null") 
        {
            TimeException = DateTime.Now;
        }
        public CardFileException(string message) : base(message) { }
        public CardFileException(string message, Exception inner) : base(message, inner) { }
        protected CardFileException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
