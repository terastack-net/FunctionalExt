using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapError<T>(this Return<T> result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapError<T, E>(this Return<T, E> result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return> TapError(this Return result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return> TapError(this Return result, Func<Exception, Task> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapError<E>(this UnitResult<E> result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapError<E>(this UnitResult<E> result, Func<E, Task> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapError<T>(this Return<T> result, Func<Exception, Task> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapError<T, E>(this Return<T, E> result, Func<E, Task> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }
    }
}
