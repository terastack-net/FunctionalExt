using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return> TapErrorIf(this Task<Return> resultTask, bool condition, Func<Task> func)
        {
            if (condition)
            {
                return resultTask.TapError(func);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return> TapErrorIf(this Task<Return> resultTask, bool condition, Func<Exception, Task> func)
        {
            if (condition)
            {
                return resultTask.TapError(func);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T>> TapErrorIf<T>(this Task<Return<T>> resultTask, bool condition, Func<Task> func)
        {
            if (condition)
            {
                return resultTask.TapError(func);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T>> TapErrorIf<T>(this Task<Return<T>> resultTask, bool condition, Func<Exception, Task> func)
        {
            if (condition)
            {
                return resultTask.TapError(func);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T, E>> TapErrorIf<T, E>(this Task<Return<T, E>> resultTask, bool condition, Func<Task> func)
        {
            if (condition)
            {
                return resultTask.TapError(func);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T, E>> TapErrorIf<T, E>(this Task<Return<T, E>> resultTask, bool condition, Func<E, Task> func)
        {
            if (condition)
            {
                return resultTask.TapError(func);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<Task> func)
        {
            if (condition)
            {
                return resultTask.TapError(func);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<E, Task> func)
        {
            if (condition)
            {
                return resultTask.TapError(func);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return> TapErrorIf(this Task<Return> resultTask, Func<Exception, bool> predicate, Func<Task> func)
        {
            Return result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(func).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return> TapErrorIf(this Task<Return> resultTask, Func<Exception, bool> predicate, Func<Exception, Task> func)
        {
            Return result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(func).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapErrorIf<T>(this Task<Return<T>> resultTask, Func<Exception, bool> predicate, Func<Task> func)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(func).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapErrorIf<T>(this Task<Return<T>> resultTask, Func<Exception, bool> predicate, Func<Exception, Task> func)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(func).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapErrorIf<T, E>(this Task<Return<T, E>> resultTask, Func<E, bool> predicate, Func<Task> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(func).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapErrorIf<T, E>(this Task<Return<T, E>> resultTask, Func<E, bool> predicate, Func<E, Task> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(func).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, Func<E, bool> predicate, Func<Task> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(func).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, Func<E, bool> predicate, Func<E, Task> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(func).DefaultAwait();
            }

            return result;
        }
    }
}
