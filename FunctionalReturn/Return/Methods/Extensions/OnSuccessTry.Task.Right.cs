using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static async Task<Return> OnSuccessTry(this Return result, Func<Task> func,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? result
                : await Return.Try(func, errorHandler).DefaultAwait();
        }

        public static async Task<Return> OnSuccessTry<T>(this Return<T> result, Func<T, Task> func,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure(result.Error)
                : await Return.Try(() => func.Invoke(result.Value), errorHandler).DefaultAwait();
        }
    }
}
