#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
       public static async ValueTask<Return<T, E>> OnFailureCompensate<T, E>(this ValueTask<Return<T, E>> resultTask,
            Func<ValueTask<Return<T, E>>> valueTask)
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure)
                return await valueTask();

            return result;
        }

        public static async ValueTask<Return<T>> OnFailureCompensate<T>(this ValueTask<Return<T>> resultTask, Func<ValueTask<Return<T>>> valueTask)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure)
                return await valueTask();

            return result;
        }

        public static async ValueTask<Return> OnFailureCompensate(this ValueTask<Return> resultTask, Func<ValueTask<Return>> valueTask)
        {
            Return result = await resultTask;

            if (result.IsFailure)
                return await valueTask();

            return result;
        }
        
        
        public static async ValueTask<Return<T>> OnFailureCompensate<T>(this ValueTask<Return<T>> resultTask, Func<Exception, ValueTask<Return<T>>> valueTask)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure)
                return await valueTask(result.Error);

            return result;
        }

        public static async ValueTask<Return<T, E>> OnFailureCompensate<T, E>(this ValueTask<Return<T, E>> resultTask,
            Func<E, ValueTask<Return<T, E>>> valueTask)
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure)
                return await valueTask(result.Error);

            return result;
        }

        public static async ValueTask<Return> OnFailureCompensate(this ValueTask<Return> resultTask, Func<Exception, ValueTask<Return>> valueTask)
        {
            Return result = await resultTask;
            
            if (result.IsFailure)
                return await valueTask(result.Error);

            return result;
        }
    }
}
#endif