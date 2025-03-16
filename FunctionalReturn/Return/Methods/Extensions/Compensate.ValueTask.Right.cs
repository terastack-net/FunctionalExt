#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Return> Compensate(this Return result, Func<Exception, ValueTask<Return>> valueTask)
        {
            if (result.IsSuccess)
            {
                return Return.Success().AsCompletedValueTask();
            }

            return valueTask(result.Error);
        }

        public static ValueTask<UnitReturn<E>> Compensate<E>(this Return result, Func<Exception, ValueTask<UnitReturn<E>>> valueTask)
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E>().AsCompletedValueTask();
            }

            return valueTask(result.Error);
        }

        public static ValueTask<Return> Compensate<T>(this Return<T> result, Func<Exception, ValueTask<Return>> valueTask)
        {
            if (result.IsSuccess)
            {
                return Return.Success().AsCompletedValueTask();
            }

            return valueTask(result.Error);
        }

        public static ValueTask<Return<T>> Compensate<T>(this Return<T> result, Func<Exception, ValueTask<Return<T>>> valueTask)
        {
            if (result.IsSuccess)
            {
                return Return.Success(result.Value).AsCompletedValueTask();
            }

            return valueTask(result.Error);
        }

        public static ValueTask<Return<T, E>> Compensate<T, E>(this Return<T> result, Func<Exception, ValueTask<Return<T, E>>> valueTask)
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E>(result.Value).AsCompletedValueTask();
            }

            return valueTask(result.Error);
        }

        public static ValueTask<Return> Compensate<E>(this UnitReturn<E> result, Func<E, ValueTask<Return>> valueTask)
        {
            if (result.IsSuccess)
            {
                return Return.Success().AsCompletedValueTask();
            }

            return valueTask(result.Error);
        }

        public static ValueTask<UnitReturn<E2>> Compensate<E, E2>(this UnitReturn<E> result, Func<E, ValueTask<UnitReturn<E2>>> valueTask)
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E2>().AsCompletedValueTask();
            }

            return valueTask(result.Error);
        }

        public static ValueTask<Return> Compensate<T, E>(this Return<T, E> result, Func<E, ValueTask<Return>> valueTask)
        {
            if (result.IsSuccess)
            {
                return Return.Success().AsCompletedValueTask();
            }

            return valueTask(result.Error);
        }

        public static ValueTask<UnitReturn<E2>> Compensate<T, E, E2>(this Return<T, E> result, Func<E, ValueTask<UnitReturn<E2>>> valueTask)
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E2>().AsCompletedValueTask();
            }

            return valueTask(result.Error);
        }

        public static ValueTask<Return<T, E2>> Compensate<T, E, E2>(this Return<T, E> result, Func<E, ValueTask<Return<T, E2>>> valueTask)
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E2>(result.Value).AsCompletedValueTask();
            }

            return valueTask(result.Error);
        }
    }
}
#endif
