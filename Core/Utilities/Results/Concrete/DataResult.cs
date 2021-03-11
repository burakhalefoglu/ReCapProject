using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(T data)
        {
            Data = data;
        }
        public DataResult(T data, bool success):this(data)
        {
            Success = success;
        }
        public DataResult(T data, bool success,string message):this(data,success)
        {
            Message = message;
        }

        public T Data { get; }

        public bool Success { get; }
        public string Message { get; }
    }
}
