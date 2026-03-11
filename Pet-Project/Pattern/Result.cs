using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Pattern
{
    internal class Result<T> // T - обобщение, generic
    {
        public bool Success { get; }
        public string Message { get; }
        public T Data { get; }

        private Result(bool success, string message, T data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static Result<T> Ok(T data, string message = "")
        {
            return new Result<T>(true, message, data);
        }

        public static Result<T> Fail(string message)
        {
            return new Result<T>(false, message);
        }

        // TODO Разобраться, как это работает
        public Result<Tnew> Map<Tnew>(Func<T, Tnew> mapper)
        {
            if(this.Success)
            {
                T oldData = this.Data;
                Tnew newData = mapper(oldData);
                return Result<Tnew>.Ok(newData, this.Message);
            }
            else
            {
                return Result<Tnew>.Fail(this.Message);
            }
        }
    }
}
