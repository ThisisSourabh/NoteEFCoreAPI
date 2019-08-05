using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Exceptions
{
    public class LabelAlreadyExistException:ApplicationException
    {
        public LabelAlreadyExistException() { }
        public LabelAlreadyExistException(string message) : base(message){}
    }
}
