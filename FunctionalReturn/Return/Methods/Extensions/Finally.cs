using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static T Finally<T>(this Return result, Func<Return, T> func)
            => func(result);

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static K Finally<T, K>(this Return<T> result, Func<Return<T>, K> func)
            => func(result);

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static K Finally<K, E>(this UnitReturn<E> result, Func<UnitReturn<E>, K> func)
            => func(result);

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static K Finally<T, K, E>(this Return<T, E> result, Func<Return<T, E>, K> func)
            => func(result);
    }
}