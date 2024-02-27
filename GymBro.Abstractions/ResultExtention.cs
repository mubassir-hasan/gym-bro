using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Abstractions
{
    public static class ResultExtention
    {
        /// <summary>
        /// Railway functional programing
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="predicate">expected result</param>
        /// <param name="error">What error will show if failed</param>
        /// <returns></returns>
        public static Result<T> Ensure<T>(this Result<T> result,
            Func<T, bool> predicate,
            Error error)
        {
            if (result.IsFailure)
                return result;

            return predicate(result.Value) ?
                result :
                Result.Failure<T>(error);

        }

        public static Result<TOut> Map<TIn, TOut>(this Result<TIn> result,
            Func<TIn,TOut> mapingFunc)
        {
            return result.IsSuccess ?
                Result.Success(mapingFunc(result.Value)) :
                Result.Failure<TOut>(result.Error);
        }
    }
}
