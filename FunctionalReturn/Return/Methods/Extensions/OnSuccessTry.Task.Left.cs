using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static async Task<Return> OnSuccessTry(this Task<Return> task, Action action,
            Func<Exception, Exception> errorHandler = null)
        {
            var result = await task.DefaultAwait();
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async Task<Return> OnSuccessTry<T>(this Task<Return<T>> task, Action<T> action,
            Func<Exception, Exception> errorHandler = null)
        {
            var result = await task.DefaultAwait();
            return result.OnSuccessTry(action, errorHandler);
        }
    }
}
