#if (NETSTANDARD || NETCORE || NET5_0_OR_GREATER)
using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static Task<Return<(T First, K Second)>> BindZip<T, K>(
            this Return<T> result, Func<T, Task<Return<K>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T, K)>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T First, K Second), E>> BindZip<T, K, E>(
            this Return<T, E> result, Func<T, Task<Return<K, E>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T, K), E>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T1 First, T2 Second, K Third)>> BindZip<T1, T2, K>(
            this Return<(T1, T2)> result, Func<T1, T2, Task<Return<K>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T1, T2, K)>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T1 First, T2 Second, K Third), E>> BindZip<T1, T2, K, E>(
            this Return<(T1, T2), E> result, Func<T1, T2, Task<Return<K, E>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T1, T2, K), E>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T1, T2, T3, K)>> BindZip<T1, T2, T3, K>(
            this Return<(T1, T2, T3)> result, Func<T1, T2, T3, Task<Return<K>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, K)>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T1, T2, T3, K), E>> BindZip<T1, T2, T3, K, E>(
            this Return<(T1, T2, T3), E> result, Func<T1, T2, T3, Task<Return<K, E>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, K), E>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T1, T2, T3, T4, K)>> BindZip<T1, T2, T3, T4, K>(
            this Return<(T1, T2, T3, T4)> result, Func<T1, T2, T3, T4, Task<Return<K>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, K)>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T1, T2, T3, T4, K), E>> BindZip<T1, T2, T3, T4, K, E>(
            this Return<(T1, T2, T3, T4), E> result, Func<T1, T2, T3, T4, Task<Return<K, E>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, K), E>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T1, T2, T3, T4, T5, K)>> BindZip<T1, T2, T3, T4, T5, K>(
            this Return<(T1, T2, T3, T4, T5)> result, Func<T1, T2, T3, T4, T5, Task<Return<K>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, K)>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T1, T2, T3, T4, T5, K), E>> BindZip<T1, T2, T3, T4, T5, K, E>(
            this Return<(T1, T2, T3, T4, T5), E> result, Func<T1, T2, T3, T4, T5, Task<Return<K, E>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, K), E>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T1, T2, T3, T4, T5, T6, K)>> BindZip<T1, T2, T3, T4, T5, T6, K>(
            this Return<(T1, T2, T3, T4, T5, T6)> result, Func<T1, T2, T3, T4, T5, T6, Task<Return<K>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, K)>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T1, T2, T3, T4, T5, T6, K), E>> BindZip<T1, T2, T3, T4, T5, T6, K, E>(
            this Return<(T1, T2, T3, T4, T5, T6), E> result, Func<T1, T2, T3, T4, T5, T6, Task<Return<K, E>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, K), E>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T1, T2, T3, T4, T5, T6, T7, K)>> BindZip<T1, T2, T3, T4, T5, T6, T7, K>(
            this Return<(T1, T2, T3, T4, T5, T6, T7)> result,
            Func<T1, T2, T3, T4, T5, T6, T7, Task<Return<K>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, T7, K)>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }

        public static Task<Return<(T1, T2, T3, T4, T5, T6, T7, K), E>> BindZip<T1, T2, T3, T4, T5, T6, T7, K, E>(
            this Return<(T1, T2, T3, T4, T5, T6, T7), E> result,
            Func<T1, T2, T3, T4, T5, T6, T7, Task<Return<K, E>>> func
        ) {
            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, T7, K), E>(result.Error).AsCompletedTask()
                : result.AsCompletedTask().BindZip(func);
        }
    }
}
#endif
