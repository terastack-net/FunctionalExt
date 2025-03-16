#if !NET40
using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return> TapErrorIf(this Return result, bool condition, Func<Task> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return> TapErrorIf(this Return result, bool condition, Func<Exception, Task> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T>> TapErrorIf<T>(this Return<T> result, bool condition, Func<Task> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T>> TapErrorIf<T>(this Return<T> result, bool condition, Func<Exception, Task> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T, E>> TapErrorIf<T, E>(this Return<T, E> result, bool condition, Func<Task> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T, E>> TapErrorIf<T, E>(this Return<T, E> result, bool condition, Func<E, Task> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, bool condition, Func<Task> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, bool condition, Func<E, Task> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return> TapErrorIf(this Return result, Func<Exception, bool> predicate, Func<Task> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return> TapErrorIf(this Return result, Func<Exception, bool> predicate, Func<Exception, Task> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T>> TapErrorIf<T>(this Return<T> result, Func<Exception, bool> predicate, Func<Task> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T>> TapErrorIf<T>(this Return<T> result, Func<Exception, bool> predicate, Func<Exception, Task> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T, E>> TapErrorIf<T, E>(this Return<T, E> result, Func<E, bool> predicate, Func<Task> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T, E>> TapErrorIf<T, E>(this Return<T, E> result, Func<E, bool> predicate, Func<E, Task> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Func<Task> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Func<E, Task> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return Task.FromResult(result);
        }
    }
}
#endif
