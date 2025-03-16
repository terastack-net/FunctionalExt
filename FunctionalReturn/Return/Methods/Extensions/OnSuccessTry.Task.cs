using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static async Task<Return> OnSuccessTry(this Task<Return> task, Func<Task> func,
            Func<Exception, Exception> errorHandler = null)
        {
            var result = await task.DefaultAwait();
            return await result.OnSuccessTry(func, errorHandler).DefaultAwait();
        }

        public static async Task<Return> OnSuccessTry<T>(this Task<Return<T>> task, Func<T, Task> func,
            Func<Exception, Exception> errorHandler = null)
        {
            var result = await task.DefaultAwait();
            return await result.OnSuccessTry(func, errorHandler).DefaultAwait();
        }
    }
}
