using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorMessage<T> : DataResult<T>
    {
        public ErrorMessage() : base(default, false)
        {

        }
        public ErrorMessage(string message) : base(default, false, message)
        {

        }
        public ErrorMessage(T data) : base(data, false)
        {

        }
        public ErrorMessage(T data, string message) : base(data, false, message)
        {

        }
    }
}
