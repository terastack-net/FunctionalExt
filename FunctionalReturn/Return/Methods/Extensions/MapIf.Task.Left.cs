using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static async Task<Return<T>> MapIf<T>(
            this Task<Return<T>> resultTask,
            bool condition,
            Func<T, T> func
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(condition, func);
        }

        public static async Task<Return<T>> MapIf<T, TContext>(
            this Task<Return<T>> resultTask,
            bool condition,
            Func<T, TContext, T> func,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(condition, func, context);
        }

        public static async Task<Return<T, E>> MapIf<T, E>(
            this Task<Return<T, E>> resultTask,
            bool condition,
            Func<T, T> func
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(condition, func);
        }

        public static async Task<Return<T, E>> MapIf<T, E, TContext>(
            this Task<Return<T, E>> resultTask,
            bool condition,
            Func<T, TContext, T> func,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(condition, func, context);
        }

        public static async Task<Return<T>> MapIf<T>(
            this Task<Return<T>> resultTask,
            Func<T, bool> predicate,
            Func<T, T> func
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(predicate, func);
        }

        public static async Task<Return<T>> MapIf<T, TContext>(
            this Task<Return<T>> resultTask,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, T> func,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(predicate, func, context);
        }

        public static async Task<Return<T, E>> MapIf<T, E>(
            this Task<Return<T, E>> resultTask,
            Func<T, bool> predicate,
            Func<T, T> func
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(predicate, func);
        }

        public static async Task<Return<T, E>> MapIf<T, E, TContext>(
            this Task<Return<T, E>> resultTask,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, T> func,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(predicate, func, context);
        }
    }
}
