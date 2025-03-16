using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Return OnSuccessTry(this Return result, Action action, Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? result
                : Return.Try(action, errorHandler);
        }

        public static Return OnSuccessTry<T>(this Return<T> result, Action<T> action, Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure(result.Error)
                : Return.Try(() => action(result.Value), errorHandler);
        }
    }
}
