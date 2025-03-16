#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<T> Finally<T>(this Return result, Func<Return, ValueTask<T>> valueTask)
        {
            return await valueTask(result);
        }

        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<T, K>(this Return<T> result, Func<Return<T>, ValueTask<K>> valueTask)
        {
            return await valueTask(result);
        }

        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<K, E>(this UnitResult<E> result, Func<UnitResult<E>, ValueTask<K>> valueTask)
        {
            return await valueTask(result);
        }

        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<T, K, E>(this Return<T, E> result, Func<Return<T, E>, ValueTask<K>> valueTask)
        {
            return await valueTask(result);
        }
    }
}
#endif
