using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapError<T, E>(this Task<Return<T, E>> resultTask, Func<Task> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapError<T>(this Task<Return<T>> resultTask, Func<Task> func)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return> TapError(this Task<Return> resultTask, Func<Task> func)
        {
            Return result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return> TapError(this Task<Return> resultTask, Func<Exception, Task> func)
        {
            Return result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapError<E>(this Task<UnitResult<E>> resultTask, Func<E, Task> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapError<E>(this Task<UnitResult<E>> resultTask, Func<Task> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapError<T>(this Task<Return<T>> resultTask, Func<Exception, Task> func)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapError<T, E>(this Task<Return<T, E>> resultTask, Func<E, Task> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }
    }
}
