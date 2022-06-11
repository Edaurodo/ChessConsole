using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    internal class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {

        }
    }
}
