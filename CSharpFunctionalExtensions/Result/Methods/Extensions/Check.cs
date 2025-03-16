using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Return<T> Check<T>(this Return<T> result, Func<T, Return> func)
        {
            return result.Bind(func).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Return<T> Check<T, K>(this Return<T> result, Func<T, Return<K>> func)
        {
            return result.Bind(func).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Return<T, E> Check<T, K, E>(this Return<T, E> result, Func<T, Return<K, E>> func)
        {
            return result.Bind(func).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Return<T, E> Check<T, E>(this Return<T, E> result, Func<T, UnitReturn<E>> func)
        {
            return result.Bind(func).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static UnitReturn<E> Check<E>(this UnitReturn<E> result, Func<UnitReturn<E>> func)
        {
            return result.Bind(func).Map(() => result);
        }
    }
}