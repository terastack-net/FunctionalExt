#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Return<T>> MapIf<T>(
            this Return<T> result,
            bool condition,
            Func<T, ValueTask<T>> valueTask
        )
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Map(valueTask);
        }

        public static ValueTask<Return<T>> MapIf<T, TContext>(
            this Return<T> result,
            bool condition,
            Func<T, TContext, ValueTask<T>> valueTask,
            TContext context
        )
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Map(valueTask, context);
        }

        public static ValueTask<Return<T, E>> MapIf<T, E>(
            this Return<T, E> result,
            bool condition,
            Func<T, ValueTask<T>> valueTask
        )
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Map(valueTask);
        }

        public static ValueTask<Return<T, E>> MapIf<T, E, TContext>(
            this Return<T, E> result,
            bool condition,
            Func<T, TContext, ValueTask<T>> valueTask,
            TContext context
        )
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Map(valueTask, context);
        }

        public static ValueTask<Return<T>> MapIf<T>(
            this Return<T> result,
            Func<T, bool> predicate,
            Func<T, ValueTask<T>> valueTask
        )
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedValueTask();
            }

            return result.Map(valueTask);
        }

        public static ValueTask<Return<T>> MapIf<T, TContext>(
            this Return<T> result,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, ValueTask<T>> valueTask,
            TContext context
        )
        {
            if (!result.IsSuccess || !predicate(result.Value, context))
            {
                return result.AsCompletedValueTask();
            }

            return result.Map(valueTask, context);
        }

        public static ValueTask<Return<T, E>> MapIf<T, E>(
            this Return<T, E> result,
            Func<T, bool> predicate,
            Func<T, ValueTask<T>> valueTask
        )
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedValueTask();
            }

            return result.Map(valueTask);
        }

        public static ValueTask<Return<T, E>> MapIf<T, E, TContext>(
            this Return<T, E> result,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, ValueTask<T>> valueTask,
            TContext context
        )
        {
            if (!result.IsSuccess || !predicate(result.Value, context))
            {
                return result.AsCompletedValueTask();
            }

            return result.Map(valueTask, context);
        }
    }
}
#endif
