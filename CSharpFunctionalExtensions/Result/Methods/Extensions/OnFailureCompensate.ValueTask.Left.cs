#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
      public static async ValueTask<Return<T, E>> OnFailureCompensate<T, E>(this ValueTask<Return<T, E>> resultTask,
            Func<Return<T, E>> valueTask)
        {
            Return<T, E> result = await resultTask;
            return result.OnFailureCompensate(valueTask);
        }
        
        public static async ValueTask<Return<T>> OnFailureCompensate<T>(this ValueTask<Return<T>> resultTask, Func<Return<T>> valueTask)
        {
            Return<T> result = await resultTask;
            return result.OnFailureCompensate(valueTask);
        }

        public static async ValueTask<Return> OnFailureCompensate(this ValueTask<Return> resultTask, Func<Return> valueTask)
        {
            Return result = await resultTask;
            return result.OnFailureCompensate(valueTask);
        }

        public static async ValueTask<Return<T>> OnFailureCompensate<T>(this ValueTask<Return<T>> resultTask, Func<Exception, Return<T>> valueTask)
        {
            Return<T> result = await resultTask;
            return result.OnFailureCompensate(valueTask);
        }

        public static async ValueTask<Return<T, E>> OnFailureCompensate<T, E>(this ValueTask<Return<T, E>> resultTask,
            Func<E, Return<T, E>> valueTask)
        {
            Return<T, E> result = await resultTask;
            return result.OnFailureCompensate(valueTask);
        }

        public static async ValueTask<Return> OnFailureCompensate(this ValueTask<Return> resultTask, Func<Exception, Return> valueTask)
        {
            Return result = await resultTask;
            return result.OnFailureCompensate(valueTask);
        }
    }
}
#endif