#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> valueTask action if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> valueTask action.
        /// </summary>
        public static async ValueTask<K> Match<T, K, E>(this ValueTask<Return<T, E>> resultTask, Func<T, K> onSuccess, Func<E, K> onFailure)
        {
            return (await resultTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> valueTask action if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> valueTask action.
        /// </summary>
        public static async ValueTask<K> Match<K, T>(this ValueTask<Return<T>> resultTask, Func<T, K> onSuccess, Func<Exception, K> onFailure)
        {
            return (await resultTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> valueTask action if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> valueTask action.
        /// </summary>
        public static async ValueTask<T> Match<T>(this ValueTask<Return> resultTask, Func<T> onSuccess, Func<Exception, T> onFailure)
        {
            return (await resultTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> valueTask action if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> valueTask action.
        /// </summary>
        public static async ValueTask<K> Match<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<K> onSuccess, Func<E, K> onFailure)
        {
            return (await resultTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<T, E>(this ValueTask<Return<T, E>> resultTask, Action<T> onSuccess, Action<E> onFailure)
        {
            (await resultTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<T>(this ValueTask<Return<T>> resultTask, Action<T> onSuccess, Action<Exception> onFailure)
        {
            (await resultTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match(this ValueTask<Return> resultTask, Action onSuccess, Action<Exception> onFailure)
        {
            (await resultTask).Match(onSuccess, onFailure);
        }
    }
}
#endif