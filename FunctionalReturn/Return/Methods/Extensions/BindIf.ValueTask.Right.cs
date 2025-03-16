#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Return> BindIf(this Return result, bool condition, Func<ValueTask<Return>> valueTask)
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(valueTask);
        }

        public static ValueTask<Return<T>> BindIf<T>(this Return<T> result, bool condition, Func<T, ValueTask<Return<T>>> valueTask)
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(valueTask);
        }

        public static ValueTask<UnitReturn<E>> BindIf<E>(this UnitReturn<E> result, bool condition, Func<ValueTask<UnitReturn<E>>> valueTask)
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(valueTask);
        }

        public static ValueTask<Return<T, E>> BindIf<T, E>(this Return<T, E> result, bool condition, Func<T, ValueTask<Return<T, E>>> valueTask)
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(valueTask);
        }

        public static ValueTask<Return> BindIf(this Return result, Func<bool> predicate, Func<ValueTask<Return>> valueTask)
        {
            if (!result.IsSuccess || !predicate())
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(valueTask);
        }

        public static ValueTask<Return<T>> BindIf<T>(this Return<T> result, Func<T, bool> predicate, Func<T, ValueTask<Return<T>>> valueTask)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(valueTask);
        }

        public static ValueTask<UnitReturn<E>> BindIf<E>(this UnitReturn<E> result, Func<bool> predicate, Func<ValueTask<UnitReturn<E>>> valueTask)
        {
            if (!result.IsSuccess || !predicate())
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(valueTask);
        }

        public static ValueTask<Return<T, E>> BindIf<T, E>(this Return<T, E> result, Func<T, bool> predicate, Func<T, ValueTask<Return<T, E>>> valueTask)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(valueTask);
        }
    }
}
#endif