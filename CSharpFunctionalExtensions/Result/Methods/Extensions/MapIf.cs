using System;

namespace CSharpFunctionalExtensions
{
    /// <summary>
    ///     Creates a new result from the return value of a given function if the condition is true. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    public static partial class ResultExtensions
    {
        public static Return<T> MapIf<T>(this Return<T> result, bool condition, Func<T, T> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Map(func);
        }

        public static Return<T> MapIf<T, TContext>(
            this Return<T> result,
            bool condition,
            Func<T, TContext, T> func,
            TContext context
        )
        {
            if (!condition)
            {
                return result;
            }

            return result.Map(func, context);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function if the condition is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<T, E> MapIf<T, E>(
            this Return<T, E> result,
            bool condition,
            Func<T, T> func
        )
        {
            if (!condition)
            {
                return result;
            }

            return result.Map(func);
        }

        public static Return<T, E> MapIf<T, E, TContext>(
            this Return<T, E> result,
            bool condition,
            Func<T, TContext, T> func,
            TContext context
        )
        {
            if (!condition)
            {
                return result;
            }

            return result.Map(func, context);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function if the predicate is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<T> MapIf<T>(
            this Return<T> result,
            Func<T, bool> predicate,
            Func<T, T> func
        )
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result;
            }

            return result.Map(func);
        }

        public static Return<T> MapIf<T, TContext>(
            this Return<T> result,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, T> func,
            TContext context
        )
        {
            if (!result.IsSuccess || !predicate(result.Value, context))
            {
                return result;
            }

            return result.Map(func, context);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function if the predicate is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<T, E> MapIf<T, E>(
            this Return<T, E> result,
            Func<T, bool> predicate,
            Func<T, T> func
        )
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result;
            }

            return result.Map(func);
        }

        public static Return<T, E> MapIf<T, E, TContext>(
            this Return<T, E> result,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, T> func,
            TContext context
        )
        {
            if (!result.IsSuccess || !predicate(result.Value, context))
            {
                return result;
            }

            return result.Map(func, context);
        }
    }
}
