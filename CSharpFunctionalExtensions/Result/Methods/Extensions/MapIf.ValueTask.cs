#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<Return<T>> MapIf<T>(
            this ValueTask<Return<T>> resultTask,
            bool condition,
            Func<T, ValueTask<T>> valueTask
        )
        {
            var result = await resultTask;
            return await result.MapIf(condition, valueTask);
        }

        public static async ValueTask<Return<T>> MapIf<T, TContext>(
            this ValueTask<Return<T>> resultTask,
            bool condition,
            Func<T, TContext, ValueTask<T>> valueTask,
            TContext context
        )
        {
            var result = await resultTask;
            return await result.MapIf(condition, valueTask, context);
        }

        public static async ValueTask<Return<T, E>> MapIf<T, E>(
            this ValueTask<Return<T, E>> resultTask,
            bool condition,
            Func<T, ValueTask<T>> valueTask
        )
        {
            var result = await resultTask;
            return await result.MapIf(condition, valueTask);
        }

        public static async ValueTask<Return<T, E>> MapIf<T, E, TContext>(
            this ValueTask<Return<T, E>> resultTask,
            bool condition,
            Func<T, TContext, ValueTask<T>> valueTask,
            TContext context
        )
        {
            var result = await resultTask;
            return await result.MapIf(condition, valueTask, context);
        }

        public static async ValueTask<Return<T>> MapIf<T>(
            this ValueTask<Return<T>> resultTask,
            Func<T, bool> predicate,
            Func<T, ValueTask<T>> valueTask
        )
        {
            var result = await resultTask;
            return await result.MapIf(predicate, valueTask);
        }

        public static async ValueTask<Return<T>> MapIf<T, TContext>(
            this ValueTask<Return<T>> resultTask,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, ValueTask<T>> valueTask,
            TContext context
        )
        {
            var result = await resultTask;
            return await result.MapIf(predicate, valueTask, context);
        }

        public static async ValueTask<Return<T, E>> MapIf<T, E>(
            this ValueTask<Return<T, E>> resultTask,
            Func<T, bool> predicate,
            Func<T, ValueTask<T>> valueTask
        )
        {
            var result = await resultTask;
            return await result.MapIf(predicate, valueTask);
        }

        public static async ValueTask<Return<T, E>> MapIf<T, E, TContext>(
            this ValueTask<Return<T, E>> resultTask,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, ValueTask<T>> valueTask,
            TContext context
        )
        {
            var result = await resultTask;
            return await result.MapIf(predicate, valueTask, context);
        }
    }
}
#endif
