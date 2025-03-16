using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async Task<Return<T>> MapIf<T>(
            this Task<Return<T>> resultTask,
            bool condition,
            Func<T, Task<T>> func
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapIf(condition, func).DefaultAwait();
        }

        public static async Task<Return<T>> MapIf<T, TContext>(
            this Task<Return<T>> resultTask,
            bool condition,
            Func<T, TContext, Task<T>> func,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapIf(condition, func, context).DefaultAwait();
        }

        public static async Task<Return<T, E>> MapIf<T, E>(
            this Task<Return<T, E>> resultTask,
            bool condition,
            Func<T, Task<T>> func
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapIf(condition, func).DefaultAwait();
        }

        public static async Task<Return<T, E>> MapIf<T, E, TContext>(
            this Task<Return<T, E>> resultTask,
            bool condition,
            Func<T, TContext, Task<T>> func,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapIf(condition, func, context).DefaultAwait();
        }

        public static async Task<Return<T>> MapIf<T>(
            this Task<Return<T>> resultTask,
            Func<T, bool> predicate,
            Func<T, Task<T>> func
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapIf(predicate, func).DefaultAwait();
        }

        public static async Task<Return<T>> MapIf<T, TContext>(
            this Task<Return<T>> resultTask,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, Task<T>> func,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapIf(predicate, func, context).DefaultAwait();
        }

        public static async Task<Return<T, E>> MapIf<T, E>(
            this Task<Return<T, E>> resultTask,
            Func<T, bool> predicate,
            Func<T, Task<T>> func
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapIf(predicate, func).DefaultAwait();
        }

        public static async Task<Return<T, E>> MapIf<T, E, TContext>(
            this Task<Return<T, E>> resultTask,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, Task<T>> func,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapIf(predicate, func, context).DefaultAwait();
        }
    }
}
