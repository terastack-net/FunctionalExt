#nullable enable

using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Return<T> EnsureNotNull<T>(this Return<T?> result, Exception error)
            where T : class
        {
            return result.Ensure(value => value != null, error).Map(value => value!);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Return<T> EnsureNotNull<T>(this Return<T?> result, Exception error)
            where T : struct
        {
            return result.Ensure(value => value != null, error).Map(value => value!.Value);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Return<T> EnsureNotNull<T>(this Return<T?> result, Func<Exception> errorFactory)
            where T : class
        {
            return result.Ensure(value => value != null, _ => errorFactory()).Map(value => value!);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Return<T> EnsureNotNull<T>(this Return<T?> result, Func<Exception> errorFactory)
            where T : struct
        {
            return result.Ensure(value => value != null, _ => errorFactory()).Map(value => value!.Value);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Return<T, E> EnsureNotNull<T, E>(this Return<T?, E> result, E error)
            where T : class
        {
            return result.Ensure(value => value != null, error).Map(value => value!);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Return<T, E> EnsureNotNull<T, E>(this Return<T?, E> result, E error)
            where T : struct
        {
            return result.Ensure(value => value != null, error).Map(value => value!.Value);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Return<T, E> EnsureNotNull<T, E>(this Return<T?, E> result, Func<E> errorFactory)
            where T : class
        {
            return result.Ensure(value => value != null, _ => errorFactory()).Map(value => value!);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Return<T, E> EnsureNotNull<T, E>(this Return<T?, E> result, Func<E> errorFactory)
            where T : struct
        {
            return result.Ensure(value => value != null, _ => errorFactory()).Map(value => value!.Value);
        }
    }
}
