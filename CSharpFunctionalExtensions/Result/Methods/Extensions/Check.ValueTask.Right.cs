#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
   public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Return<T>> Check<T>(this Return<T> result, Func<T, ValueTask<Return>> valueTask)
        {
            return await result.Bind(valueTask).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Return<T>> Check<T, K>(this Return<T> result, Func<T, ValueTask<Return<K>>> valueTask)
        {
            return await result.Bind(valueTask).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Return<T, E>> Check<T, K, E>(this Return<T, E> result, Func<T, ValueTask<Return<K, E>>> valueTask)
        {
            return await result.Bind(valueTask).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Return<T, E>> Check<T, E>(this Return<T, E> result, Func<T, ValueTask<UnitResult<E>>> valueTask)
        {
            return await result.Bind(valueTask).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Check<E>(this UnitResult<E> result, Func<ValueTask<UnitResult<E>>> valueTask)
        {
            return await result.Bind(valueTask).Map(() => result);
        }
    }
}
#endif