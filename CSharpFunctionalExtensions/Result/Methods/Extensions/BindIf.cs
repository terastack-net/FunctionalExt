using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Selects result from the return value of a given function if the condition is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return BindIf(this Return result, bool condition, Func<Return> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the condition is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<T> BindIf<T>(this Return<T> result, bool condition, Func<T, Return<T>> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the condition is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UnitResult<E> BindIf<E>(this UnitResult<E> result, bool condition, Func<UnitResult<E>> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the condition is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<T, E> BindIf<T, E>(this Return<T, E> result, bool condition, Func<T, Return<T, E>> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the predicate is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return BindIf(this Return result, Func<bool> predicate, Func<Return> func)
        {
            if (!result.IsSuccess || !predicate())
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the predicate is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<T> BindIf<T>(this Return<T> result, Func<T, bool> predicate, Func<T, Return<T>> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the predicate is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UnitResult<E> BindIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<UnitResult<E>> func)
        {
            if (!result.IsSuccess || !predicate())
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the predicate is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<T, E> BindIf<T, E>(this Return<T, E> result, Func<T, bool> predicate, Func<T, Return<T, E>> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result;
            }

            return result.Bind(func);
        }
    }
}