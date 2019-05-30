using System;
using System.Collections.Generic;
using System.Linq;

namespace RCE.Commons
{
    public class LogicResult
    {
        public LogicResult()
        {
            IsSucceed = true;
        }

        public bool IsSucceed { get; protected set; }
        public List<string> FailureResult { get; protected set; }
        public Exception Exception { get; protected set; }
        public string ExceptionMessage { get; protected set; }

        public static LogicResult Failure(params string[] failureResult)
        {
            return new LogicResult { IsSucceed=false , FailureResult = failureResult.ToList(), ExceptionMessage = failureResult.FirstOrDefault()};
        }
        public static LogicResult Failure(Exception exception)
        {
            var result = new LogicResult() { IsSucceed = false};
            result.Exception = exception;
            result.FailureResult = new List<string>();

            while (exception.InnerException != null)
            {
                result.ExceptionMessage = exception.Message;
                result.FailureResult.Add(exception.Message);
                exception = exception.InnerException;
            }
            return result;
        }
        public static LogicResult Succeed()
        {
            return new LogicResult();
        }
    }

    public class LogicResult<T> : LogicResult
    {
        public LogicResult():base()
        { }

        public T Data { get; set; }

        public static new LogicResult<T> Failure(params string[] failureResult)
        {
            return new LogicResult<T> { IsSucceed = false, FailureResult = failureResult.ToList(), ExceptionMessage = failureResult.FirstOrDefault() };
        }
        public static new LogicResult<T> Failure(Exception exception)
        {
            var result = new LogicResult<T> { IsSucceed = false };
            result.Exception = exception;
            result.FailureResult = new List<string>();

            while (exception.InnerException != null)
            {
                result.ExceptionMessage = exception.Message;
                result.FailureResult.Add(exception.Message);
                exception = exception.InnerException;
                
            }
            return result;
        }
        public static LogicResult<T> Succeed(T data)
        {
            return new LogicResult<T> { Data = data };
        }
    }
}
