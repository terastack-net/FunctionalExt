using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return> Tap(this Return result, Func<Task> func)
        {
            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> Tap<T>(this Return<T> result, Func<Task> func)
        {
            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> Tap<T>(this Return<T> result, Func<T, Task> func)
        {
            if (result.IsSuccess)
                await func(result.Value).DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<UnitReturn<E>> Tap<E>(this UnitReturn<E> result, Func<Task> func)
        {
            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> Tap<T, E>(this Return<T, E> result, Func<Task> func)
        {
            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> Tap<T, E>(this Return<T, E> result, Func<T, Task> func)
        {
            if (result.IsSuccess)
                await func(result.Value).DefaultAwait();

            return result;
        }
    }
}
