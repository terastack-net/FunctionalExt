using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static async Task<Return<T>> OnFailureCompensate<T>(this Return<T> result, Func<Task<Return<T>>> func)
        {
            if (result.IsFailure)
                return await func().DefaultAwait();

            return result;
        }

        public static async Task<Return<T, E>> OnFailureCompensate<T, E>(this Return<T, E> result, Func<Task<Return<T, E>>> func)
        {
            if (result.IsFailure)
                return await func().DefaultAwait();

            return result;
        }

        public static async Task<Return> OnFailureCompensate(this Return result, Func<Task<Return>> func)
        {
            if (result.IsFailure)
                return await func().DefaultAwait();

            return result;
        }

        public static async Task<Return<T>> OnFailureCompensate<T>(this Return<T> result, Func<Exception, Task<Return<T>>> func)
        {
            if (result.IsFailure)
                return await func(result.Error).DefaultAwait();

            return result;
        }

        public static async Task<Return<T, E>> OnFailureCompensate<T, E>(this Return<T, E> result,
            Func<E, Task<Return<T, E>>> func)
        {
            if (result.IsFailure)
                return await func(result.Error).DefaultAwait();

            return result;
        }
        
        public static async Task<Return> OnFailureCompensate(this Return result, Func<Exception, Task<Return>> func)
        {
            if (result.IsFailure)
                return await func(result.Error).DefaultAwait();

            return result;
        }
    }
}
