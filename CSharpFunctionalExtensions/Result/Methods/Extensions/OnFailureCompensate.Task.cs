using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        public static async Task<Return<T, E>> OnFailureCompensate<T, E>(this Task<Return<T, E>> resultTask,
            Func<Task<Return<T, E>>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return await func().DefaultAwait();

            return result;
        }

        public static async Task<Return<T>> OnFailureCompensate<T>(this Task<Return<T>> resultTask, Func<Task<Return<T>>> func)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return await func().DefaultAwait();

            return result;
        }

        public static async Task<Return> OnFailureCompensate(this Task<Return> resultTask, Func<Task<Return>> func)
        {
            Return result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return await func().DefaultAwait();

            return result;
        }
        
        
        public static async Task<Return<T>> OnFailureCompensate<T>(this Task<Return<T>> resultTask, Func<Exception, Task<Return<T>>> func)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return await func(result.Error).DefaultAwait();

            return result;
        }

        public static async Task<Return<T, E>> OnFailureCompensate<T, E>(this Task<Return<T, E>> resultTask,
            Func<E, Task<Return<T, E>>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return await func(result.Error).DefaultAwait();

            return result;
        }

        public static async Task<Return> OnFailureCompensate(this Task<Return> resultTask, Func<Exception, Task<Return>> func)
        {
            Return result = await resultTask.DefaultAwait();
            
            if (result.IsFailure)
                return await func(result.Error).DefaultAwait();

            return result;
        }
    }
}
