#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<Return<K, E>> Bind<T, K, E>(this Return<T, E> result, Func<T, ValueTask<Return<K, E>>> valueTask)
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error).AsCompletedValueTask();

            return valueTask(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<Return<K>> Bind<T, K>(this Return<T> result, Func<T, ValueTask<Return<K>>> valueTask)
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error).AsCompletedValueTask();

            return valueTask(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<Return<K>> Bind<K>(this Return result, Func<ValueTask<Return<K>>> valueTask)
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error).AsCompletedValueTask();

            return valueTask();
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<Return> Bind<T>(this Return<T> result, Func<T, ValueTask<Return>> valueTask)
        {
            if (result.IsFailure)
                return Return.Failure(result.Error).AsCompletedValueTask();

            return valueTask(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<Return> Bind(this Return result, Func<ValueTask<Return>> valueTask)
        {
            if (result.IsFailure)
                return result.AsCompletedValueTask();

            return valueTask();
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<UnitResult<E>> Bind<E>(this UnitResult<E> result, Func<ValueTask<UnitResult<E>>> valueTask)
        {
            if (result.IsFailure)
                return UnitResult.Failure(result.Error).AsCompletedValueTask();

            return valueTask();
        }
        
        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<Return<T, E>> Bind<T, E>(this UnitResult<E> result, Func<ValueTask<Return<T, E>>> valueTask)
        {
            if (result.IsFailure)
                return Return.Failure<T, E>(result.Error).AsCompletedValueTask();

            return valueTask();
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<UnitResult<E>> Bind<T, E>(this Return<T, E> result, Func<T, ValueTask<UnitResult<E>>> valueTask)
        {
            if (result.IsFailure)
                return UnitResult.Failure(result.Error).AsCompletedValueTask();

            return valueTask(result.Value);
        }
    }
}
#endif