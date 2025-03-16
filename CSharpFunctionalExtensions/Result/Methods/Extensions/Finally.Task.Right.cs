using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static Task<T> Finally<T>(this Return result, Func<Return, Task<T>> func)
          => func(result);

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static Task<K> Finally<T, K>(this Return<T> result, Func<Return<T>, Task<K>> func)
          => func(result);

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static Task<K> Finally<K, E>(this UnitResult<E> result, Func<UnitResult<E>, Task<K>> func)
          => func(result);

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static Task<K> Finally<T, K, E>(this Return<T, E> result, Func<Return<T, E>, Task<K>> func)
          => func(result);
    }
}
