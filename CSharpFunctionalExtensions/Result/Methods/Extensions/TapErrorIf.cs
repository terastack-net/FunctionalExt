using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Return TapErrorIf(this Return result, bool condition, Action action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Return TapErrorIf(this Return result, bool condition, Action<Exception> action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Return<T> TapErrorIf<T>(this Return<T> result, bool condition, Action action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Return<T> TapErrorIf<T>(this Return<T> result, bool condition, Action<Exception> action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static UnitResult<E> TapErrorIf<E>(this UnitResult<E> result, bool condition, Action action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static UnitResult<E> TapErrorIf<E>(this UnitResult<E> result, bool condition, Action<E> action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Return<T, E> TapErrorIf<T, E>(this Return<T, E> result, bool condition, Action action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Return<T, E> TapErrorIf<T, E>(this Return<T, E> result, bool condition, Action<E> action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Return TapErrorIf(this Return result, Func<Exception, bool> predicate, Action action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Return TapErrorIf(this Return result, Func<Exception, bool> predicate, Action<Exception> action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Return<T> TapErrorIf<T>(this Return<T> result, Func<Exception, bool> predicate, Action action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Return<T> TapErrorIf<T>(this Return<T> result, Func<Exception, bool> predicate, Action<Exception> action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Return<T, E> TapErrorIf<T, E>(this Return<T, E> result, Func<E, bool> predicate, Action action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Return<T, E> TapErrorIf<T, E>(this Return<T, E> result, Func<E, bool> predicate, Action<E> action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static UnitResult<E> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Action action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static UnitResult<E> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Action<E> action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }
    }
}
