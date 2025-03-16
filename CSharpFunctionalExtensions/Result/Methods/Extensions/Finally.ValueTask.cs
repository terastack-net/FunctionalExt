#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<T> Finally<T>(this ValueTask<Return> resultTask, Func<Return, ValueTask<T>> valueTask)
        {
            Return result = await resultTask;
            return await valueTask(result);
        }

        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<T, K>(this ValueTask<Return<T>> resultTask, Func<Return<T>, ValueTask<K>> valueTask)
        {
            Return<T> result = await resultTask;
            return await valueTask(result);
        }

        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<UnitResult<E>, ValueTask<K>> valueTask) 
        {
            UnitResult<E> result = await resultTask;
            return await valueTask(result);
        }

        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<T, K, E>(this ValueTask<Return<T, E>> resultTask,
            Func<Return<T, E>, ValueTask<K>> valueTask)
        {
            Return<T, E> result = await resultTask;
            return await valueTask(result);
        }
    }
}
#endif
