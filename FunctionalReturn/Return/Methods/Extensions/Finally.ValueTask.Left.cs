#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<T> Finally<T>(this ValueTask<Return> resultTask, Func<Return, T> valueTask)
        {
            Return result = await resultTask;
            return result.Finally(valueTask);
        }

        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<T, K>(this ValueTask<Return<T>> resultTask, Func<Return<T>, K> valueTask)
        {
            Return<T> result = await resultTask;
            return result.Finally(valueTask);
        }

        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<K, E>(this ValueTask<UnitReturn<E>> resultTask, Func<UnitReturn<E>, K> valueTask)
        {
            UnitReturn<E> result = await resultTask;
            return result.Finally(valueTask);
        }

        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<T, K, E>(this ValueTask<Return<T, E>> resultTask,
            Func<Return<T, E>, K> valueTask)
        {
            Return<T, E> result = await resultTask;
            return result.Finally(valueTask);
        }
    }
}
#endif
