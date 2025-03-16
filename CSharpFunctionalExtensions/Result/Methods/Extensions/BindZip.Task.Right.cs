#if (NETSTANDARD || NETCORE || NET5_0_OR_GREATER)
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async Task<Return<(T First, K Second)>> BindZip<T, K>(
            this Task<Return<T>> resultTask, Func<T, Return<K>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure ? Return.Failure<(T, K)>(result.Error) : result.BindZip(func);
        }

        public static async Task<Return<(T First, K Second), E>> BindZip<T, K, E>(
            this Task<Return<T, E>> resultTask, Func<T, Return<K, E>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure ? Return.Failure<(T, K), E>(result.Error) : result.BindZip(func);
        }

        public static async Task<Return<(T1 First, T2 Second, K Third)>> BindZip<T1, T2, K>(
            this Task<Return<(T1, T2)>> resultTask, Func<T1, T2, Return<K>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure
                ? Return.Failure<(T1, T2, K)>(result.Error) : result.BindZip(func);
        }

        public static async Task<Return<(T1 First, T2 Second, K Third), E>> BindZip<T1, T2, K, E>(
            this Task<Return<(T1, T2), E>> resultTask, Func<T1, T2, Return<K, E>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure
                ? Return.Failure<(T1, T2, K), E>(result.Error) : result.BindZip(func);
        }

        public static async Task<Return<(T1, T2, T3, K)>> BindZip<T1, T2, T3, K>(
            this Task<Return<(T1, T2, T3)>> resultTask, Func<T1, T2, T3, Return<K>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, K)>(result.Error)
                : result.BindZip(func);
        }

        public static async Task<Return<(T1, T2, T3, K), E>> BindZip<T1, T2, T3, K, E>(
            this Task<Return<(T1, T2, T3), E>> resultTask, Func<T1, T2, T3, Return<K, E>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, K), E>(result.Error)
                : result.BindZip(func);
        }

        public static async Task<Return<(T1, T2, T3, T4, K)>> BindZip<T1, T2, T3, T4, K>(
            this Task<Return<(T1, T2, T3, T4)>> resultTask, Func<T1, T2, T3, T4, Return<K>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, K)>(result.Error)
                : result.BindZip(func);
        }

        public static async Task<Return<(T1, T2, T3, T4, K), E>> BindZip<T1, T2, T3, T4, K, E>(
            this Task<Return<(T1, T2, T3, T4), E>> resultTask, Func<T1, T2, T3, T4, Return<K, E>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, K), E>(result.Error)
                : result.BindZip(func);
        }

        public static async Task<Return<(T1, T2, T3, T4, T5, K)>> BindZip<T1, T2, T3, T4, T5, K>(
            this Task<Return<(T1, T2, T3, T4, T5)>> resultTask, Func<T1, T2, T3, T4, T5, Return<K>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, K)>(result.Error)
                : result.BindZip(func);
        }

        public static async Task<Return<(T1, T2, T3, T4, T5, K), E>> BindZip<T1, T2, T3, T4, T5, K, E>(
            this Task<Return<(T1, T2, T3, T4, T5), E>> resultTask, Func<T1, T2, T3, T4, T5, Return<K, E>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, K), E>(result.Error)
                : result.BindZip(func);
        }

        public static async Task<Return<(T1, T2, T3, T4, T5, T6, K)>> BindZip<T1, T2, T3, T4, T5, T6, K>(
            this Task<Return<(T1, T2, T3, T4, T5, T6)>> resultTask,
            Func<T1, T2, T3, T4, T5, T6, Return<K>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, K)>(result.Error)
                : result.BindZip(func);
        }

        public static async Task<Return<(T1, T2, T3, T4, T5, T6, K), E>> BindZip<T1, T2, T3, T4, T5, T6, K, E>(
            this Task<Return<(T1, T2, T3, T4, T5, T6), E>> resultTask,
            Func<T1, T2, T3, T4, T5, T6, Return<K, E>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, K), E>(result.Error)
                : result.BindZip(func);
        }

        public static async Task<Return<(T1, T2, T3, T4, T5, T6, T7, K)>> BindZip<T1, T2, T3, T4, T5, T6, T7, K>(
            this Task<Return<(T1, T2, T3, T4, T5, T6, T7)>> resultTask,
            Func<T1, T2, T3, T4, T5, T6, T7, Return<K>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, T7, K)>(result.Error)
                : result.BindZip(func);
        }

        public static async Task<Return<(T1, T2, T3, T4, T5, T6, T7, K), E>> BindZip<T1, T2, T3, T4, T5, T6, T7, K, E>(
            this Task<Return<(T1, T2, T3, T4, T5, T6, T7), E>> resultTask,
            Func<T1, T2, T3, T4, T5, T6, T7, Return<K, E>> func
        ) {
            var result = await resultTask.DefaultAwait();

            return result.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, T7, K), E>(result.Error)
                : result.BindZip(func);
        }
    }
}
#endif
