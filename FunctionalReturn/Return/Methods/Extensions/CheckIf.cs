using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling result is a success and the condition is true, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Return<T> CheckIf<T>(this Return<T> result, bool condition, Func<T, Return> func)
        {
            if (condition)
                return result.Check(func);
            else
                return result;
        }

        /// <summary>
        ///     If the calling result is a success and the condition is true, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Return<T> CheckIf<T, K>(this Return<T> result, bool condition, Func<T, Return<K>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return result;
        }

        /// <summary>
        ///     If the calling result is a success and the condition is true, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Return<T, E> CheckIf<T, K, E>(this Return<T, E> result, bool condition, Func<T, Return<K, E>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return result;
        }

        /// <summary>
        ///     If the calling result is a success and the condition is true, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Return<T, E> CheckIf<T, E>(this Return<T, E> result, bool condition, Func<T, UnitReturn<E>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return result;
        }

        /// <summary>
        ///     If the calling result is a success and the condition is true, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static UnitReturn<E> CheckIf<E>(this UnitReturn<E> result, bool condition, Func<UnitReturn<E>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return result;
        }

        /// <summary>
        ///     If the calling result is a success and the predicate is true, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Return<T> CheckIf<T>(this Return<T> result, Func<T, bool> predicate, Func<T, Return> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        /// <summary>
        ///     If the calling result is a success and the predicate is true, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Return<T> CheckIf<T, K>(this Return<T> result, Func<T, bool> predicate, Func<T, Return<K>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        /// <summary>
        ///     If the calling result is a success and the predicate is true, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Return<T, E> CheckIf<T, K, E>(this Return<T, E> result, Func<T, bool> predicate, Func<T, Return<K, E>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        /// <summary>
        ///     If the calling result is a success and the predicate is true, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Return<T, E> CheckIf<T, E>(this Return<T, E> result, Func<T, bool> predicate, Func<T, UnitReturn<E>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        /// <summary>
        ///     If the calling result is a success and the predicate is true, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static UnitReturn<E> CheckIf<E>(this UnitReturn<E> result, Func<bool> predicate, Func<UnitReturn<E>> func)
        {
            if (result.IsSuccess && predicate())
                return result.Check(func);
            else
                return result;
        }
    }
}