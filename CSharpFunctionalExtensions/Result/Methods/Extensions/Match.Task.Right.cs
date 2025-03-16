using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static Task<K> Match<T, K, E>(this Return<T, E> result, Func<T, Task<K>> onSuccess, Func<E, Task<K>> onFailure)
        {
            return result.IsSuccess
                ? onSuccess(result.Value)
                : onFailure(result.Error);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static Task<K> Match<K, T>(this Return<T> result, Func<T, Task<K>> onSuccess, Func<Exception, Task<K>> onFailure)
        {
            return result.IsSuccess
                ? onSuccess(result.Value)
                : onFailure(result.Error);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static Task<T> Match<T>(this Return result, Func<Task<T>> onSuccess, Func<Exception, Task<T>> onFailure)
        {
            return result.IsSuccess
                ? onSuccess()
                : onFailure(result.Error);
        }
        
        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static Task<K> Match<K, E>(this UnitResult<E> result, Func<Task<K>> onSuccess, Func<E, Task<K>> onFailure)
        {
            return result.IsSuccess
                ? onSuccess()
                : onFailure(result.Error);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static Task Match<T, E>(this Return<T, E> result, Func<T, Task> onSuccess, Func<E, Task> onFailure)
        {
            return result.IsSuccess
                ? onSuccess(result.Value)
                : onFailure(result.Error);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static Task Match<E>(this UnitResult<E> result, Func<Task> onSuccess, Func<E, Task> onFailure)
        {
            return result.IsSuccess
                ? onSuccess()
                : onFailure(result.Error);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static Task Match<T>(this Return<T> result, Func<T, Task> onSuccess, Func<Exception, Task> onFailure)
        {
            return result.IsSuccess
                ? onSuccess(result.Value)
                : onFailure(result.Error);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static Task Match(this Return result, Func<Task> onSuccess, Func<Exception, Task> onFailure)
        {
            return result.IsSuccess
                ? onSuccess()
                : onFailure(result.Error);
        }
    }
}
