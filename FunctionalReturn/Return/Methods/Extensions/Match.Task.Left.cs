using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async Task<K> Match<T, K, E>(this Task<Return<T, E>> resultTask, Func<T, K> onSuccess, Func<E, K> onFailure)
        {
            return (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async Task<K> Match<K, T>(this Task<Return<T>> resultTask, Func<T, K> onSuccess, Func<Exception, K> onFailure)
        {
            return (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async Task<T> Match<T>(this Task<Return> resultTask, Func<T> onSuccess, Func<Exception, T> onFailure)
        {
            return (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }
        
        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async Task<K> Match<K, E>(
            this Task<UnitReturn<E>> resultTask,
            Func<K> onSuccess, 
            Func<E, K> onFailure)
        {
            return (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<T, E>(this Task<Return<T, E>> resultTask, Action<T> onSuccess, Action<E> onFailure)
        {
            (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<E>(this Task<UnitReturn<E>> resultTask, Action onSuccess, Action<E> onFailure)
        {
            (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<T>(this Task<Return<T>> resultTask, Action<T> onSuccess, Action<Exception> onFailure)
        {
            (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match(this Task<Return> resultTask, Action onSuccess, Action<Exception> onFailure)
        {
            (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }
    }
}
