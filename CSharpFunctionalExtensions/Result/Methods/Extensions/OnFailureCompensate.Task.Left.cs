using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async Task<Return<T, E>> OnFailureCompensate<T, E>(this Task<Return<T, E>> resultTask,
            Func<Return<T, E>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.OnFailureCompensate(func);
        }
        
        public static async Task<Return<T>> OnFailureCompensate<T>(this Task<Return<T>> resultTask, Func<Return<T>> func)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.OnFailureCompensate(func);
        }

        public static async Task<Return> OnFailureCompensate(this Task<Return> resultTask, Func<Return> func)
        {
            Return result = await resultTask.DefaultAwait();
            return result.OnFailureCompensate(func);
        }

        public static async Task<Return<T>> OnFailureCompensate<T>(this Task<Return<T>> resultTask, Func<Exception, Return<T>> func)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.OnFailureCompensate(func);
        }

        public static async Task<Return<T, E>> OnFailureCompensate<T, E>(this Task<Return<T, E>> resultTask,
            Func<E, Return<T, E>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.OnFailureCompensate(func);
        }

        public static async Task<Return> OnFailureCompensate(this Task<Return> resultTask, Func<Exception, Return> func)
        {
            Return result = await resultTask.DefaultAwait();
            return result.OnFailureCompensate(func);
        }
    }
}
