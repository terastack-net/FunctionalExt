using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static Task<Return<T>> MapIf<T>(
            this Return<T> result,
            bool condition,
            Func<T, Task<T>> func
        )
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Map(func);
        }

        public static Task<Return<T>> MapIf<T, TContext>(
            this Return<T> result,
            bool condition,
            Func<T, TContext, Task<T>> func,
            TContext context
        )
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Map(func, context);
        }

        public static Task<Return<T, E>> MapIf<T, E>(
            this Return<T, E> result,
            bool condition,
            Func<T, Task<T>> func
        )
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Map(func);
        }

        public static Task<Return<T, E>> MapIf<T, E, TContext>(
            this Return<T, E> result,
            bool condition,
            Func<T, TContext, Task<T>> func,
            TContext context
        )
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Map(func, context);
        }

        public static Task<Return<T>> MapIf<T>(
            this Return<T> result,
            Func<T, bool> predicate,
            Func<T, Task<T>> func
        )
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedTask();
            }

            return result.Map(func);
        }

        public static Task<Return<T>> MapIf<T, TContext>(
            this Return<T> result,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, Task<T>> func,
            TContext context
        )
        {
            if (!result.IsSuccess || !predicate(result.Value, context))
            {
                return result.AsCompletedTask();
            }

            return result.Map(func, context);
        }

        public static Task<Return<T, E>> MapIf<T, E>(
            this Return<T, E> result,
            Func<T, bool> predicate,
            Func<T, Task<T>> func
        )
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedTask();
            }

            return result.Map(func);
        }

        public static Task<Return<T, E>> MapIf<T, E, TContext>(
            this Return<T, E> result,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, Task<T>> func,
            TContext context
        )
        {
            if (!result.IsSuccess || !predicate(result.Value, context))
            {
                return result.AsCompletedTask();
            }

            return result.Map(func, context);
        }
    }
}
