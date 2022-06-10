using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CardFile.BAL.Validation
{
    [Serializable]
   public  class CardFileException : ApplicationException
    {
        public CardFileException() { }
        public CardFileException(string message) : base(message) { }
        public CardFileException(string message, Exception inner) : base(message, inner) { }
        protected CardFileException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
