#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Bind<T, K, E>(this ValueTask<Return<T, E>> resultTask, Func<T, ValueTask<Return<K, E>>> valueTask)
        {
            Return<T, E> result = await resultTask;
            return await result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Bind<T, K>(this ValueTask<Return<T>> resultTask, Func<T, ValueTask<Return<K>>> valueTask)
        {
            Return<T> result = await resultTask;
            return await result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Bind<K>(this ValueTask<Return> resultTask, Func<ValueTask<Return<K>>> valueTask)
        {
            Return result = await resultTask;
            return await result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return> Bind<T>(this ValueTask<Return<T>> resultTask, Func<T, ValueTask<Return>> valueTask)
        {
            Return<T> result = await resultTask;
            return await result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return> Bind(this ValueTask<Return> resultTask, Func<ValueTask<Return>> valueTask)
        {
            Return result = await resultTask;
            return await result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<T, E>> Bind<T, E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<Return<T, E>>> valueTask)
        {
            UnitResult<E> result = await resultTask;
            return await result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Bind<T, E>(this ValueTask<Return<T, E>> resultTask, Func<T, ValueTask<UnitResult<E>>> valueTask)
        {
            Return<T, E> result = await resultTask;
            return await result.Bind(valueTask);
        }
        
        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Bind<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<UnitResult<E>>> valueTask)
        {
            UnitResult<E> result = await resultTask;
            return await result.Bind(valueTask);
        }
    }
}
#endif