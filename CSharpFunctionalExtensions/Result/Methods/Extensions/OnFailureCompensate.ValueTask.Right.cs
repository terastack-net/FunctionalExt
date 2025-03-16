#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static async ValueTask<Return<T>> OnFailureCompensate<T>(this Return<T> result, Func<ValueTask<Return<T>>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask();

            return result;
        }

        public static async ValueTask<Return<T, E>> OnFailureCompensate<T, E>(this Return<T, E> result, Func<ValueTask<Return<T, E>>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask();

            return result;
        }

        public static async ValueTask<Return> OnFailureCompensate(this Return result, Func<ValueTask<Return>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask();

            return result;
        }

        public static async ValueTask<Return<T>> OnFailureCompensate<T>(this Return<T> result, Func<Exception, ValueTask<Return<T>>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask(result.Error);

            return result;
        }

        public static async ValueTask<Return<T, E>> OnFailureCompensate<T, E>(this Return<T, E> result,
            Func<E, ValueTask<Return<T, E>>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask(result.Error);

            return result;
        }
        
        public static async ValueTask<Return> OnFailureCompensate(this Return result, Func<Exception, ValueTask<Return>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask(result.Error);

            return result;
        }
    }
}
#endif
