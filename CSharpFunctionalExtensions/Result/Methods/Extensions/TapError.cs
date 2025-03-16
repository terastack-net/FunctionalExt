using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static Return<T, E> TapError<T, E>(this Return<T, E> result, Action action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static Return<T> TapError<T>(this Return<T> result, Action action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static Return TapError(this Return result, Action action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static UnitResult<E> TapError<E>(this UnitResult<E> result, Action<E> action)
        {
            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static UnitResult<E> TapError<E>(this UnitResult<E> result, Action action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static Return<T, E> TapError<T, E>(this Return<T, E> result, Action<E> action)
        {
            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static Return<T> TapError<T>(this Return<T> result, Action<Exception> action)
        {
            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static Return TapError(this Return result, Action<Exception> action)
        {
            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }
    }
}
