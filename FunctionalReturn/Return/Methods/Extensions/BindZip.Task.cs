#if (NETSTANDARD || NETCORE || NET5_0_OR_GREATER)
using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static async Task<Return<(T First, K Second)>> BindZip<T, K>(
            this Task<Return<T>> resultTask, Func<T, Task<Return<K>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T, K)>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T, K)>(resultToZip.Error)
                : Return.Success<(T, K)>((v, resultToZip.Value));
        }

        public static async Task<Return<(T First, K Second), E>> BindZip<T, K, E>(
            this Task<Return<T, E>> resultTask, Func<T, Task<Return<K, E>>> func
        ) {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T, K), E>(result.Error);
            }

            var value = result.Value;
            var resultToZip = await func(value).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T, K), E>(resultToZip.Error)
                : Return.Success<(T, K), E>((value, resultToZip.Value));
        }

        public static async Task<Return<(T1 First, T2 Second, K Third)>> BindZip<T1, T2, K>(
            this Task<Return<(T1, T2)>> resultTask, Func<T1, T2, Task<Return<K>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, K)>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v.Item1, v.Item2).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T1, T2, K)>(resultToZip.Error)
                : Return.Success<(T1, T2, K)>((v.Item1, v.Item2, resultToZip.Value));
        }

        public static async Task<Return<(T1 First, T2 Second, K Third), E>> BindZip<T1, T2, K, E>(
            this Task<Return<(T1, T2), E>> resultTask, Func<T1, T2, Task<Return<K, E>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, K), E>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v.Item1, v.Item2).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T1, T2, K), E>(resultToZip.Error)
                : Return.Success<(T1, T2, K), E>((v.Item1, v.Item2, resultToZip.Value));
        }

        public static async Task<Return<(T1, T2, T3, K)>> BindZip<T1, T2, T3, K>(
            this Task<Return<(T1, T2, T3)>> resultTask, Func<T1, T2, T3, Task<Return<K>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, K)>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v.Item1, v.Item2, v.Item3).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T1, T2, T3, K)>(resultToZip.Error)
                : Return.Success<(T1, T2, T3, K)>((v.Item1, v.Item2, v.Item3, resultToZip.Value));
        }

        public static async Task<Return<(T1, T2, T3, K), E>> BindZip<T1, T2, T3, K, E>(
            this Task<Return<(T1, T2, T3), E>> resultTask, Func<T1, T2, T3, Task<Return<K, E>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, K), E>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v.Item1, v.Item2, v.Item3).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T1, T2, T3, K), E>(resultToZip.Error)
                : Return.Success<(T1, T2, T3, K), E>((v.Item1, v.Item2, v.Item3, resultToZip.Value));
        }


        public static async Task<Return<(T1, T2, T3, T4, K)>> BindZip<T1, T2, T3, T4, K>(
            this Task<Return<(T1, T2, T3, T4)>> resultTask, Func<T1, T2, T3, T4, Task<Return<K>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, K)>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v.Item1, v.Item2, v.Item3, v.Item4).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, K)>(resultToZip.Error)
                : Return.Success<(T1, T2, T3, T4, K)>((v.Item1, v.Item2, v.Item3, v.Item4, resultToZip.Value));
        }

        public static async Task<Return<(T1, T2, T3, T4, K), E>> BindZip<T1, T2, T3, T4, K, E>(
            this Task<Return<(T1, T2, T3, T4), E>> resultTask, Func<T1, T2, T3, T4, Task<Return<K, E>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, K), E>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v.Item1, v.Item2, v.Item3, v.Item4).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, K), E>(resultToZip.Error)
                : Return.Success<(T1, T2, T3, T4, K), E>((v.Item1, v.Item2, v.Item3, v.Item4, resultToZip.Value));
        }

        public static async Task<Return<(T1, T2, T3, T4, T5, K)>> BindZip<T1, T2, T3, T4, T5, K>(
            this Task<Return<(T1, T2, T3, T4, T5)>> resultTask, Func<T1, T2, T3, T4, T5, Task<Return<K>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, T5, K)>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, K)>(resultToZip.Error)
                : Return.Success<(T1, T2, T3, T4, T5, K)>(
                    (v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, resultToZip.Value)
                );
        }

        public static async Task<Return<(T1, T2, T3, T4, T5, K), E>> BindZip<T1, T2, T3, T4, T5, K, E>(
            this Task<Return<(T1, T2, T3, T4, T5), E>> resultTask, Func<T1, T2, T3, T4, T5, Task<Return<K, E>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, T5, K), E>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, K), E>(resultToZip.Error)
                : Return.Success<(T1, T2, T3, T4, T5, K), E>(
                    (v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, resultToZip.Value)
                );
        }

        public static async Task<Return<(T1, T2, T3, T4, T5, T6, K)>> BindZip<T1, T2, T3, T4, T5, T6, K>(
            this Task<Return<(T1, T2, T3, T4, T5, T6)>> resultTask,
            Func<T1, T2, T3, T4, T5, T6, Task<Return<K>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, T5, T6, K)>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, K)>(resultToZip.Error)
                : Return.Success<(T1, T2, T3, T4, T5, T6, K)>(
                    (v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, resultToZip.Value)
                );
        }

        public static async Task<Return<(T1, T2, T3, T4, T5, T6, K), E>> BindZip<T1, T2, T3, T4, T5, T6, K, E>(
            this Task<Return<(T1, T2, T3, T4, T5, T6), E>> resultTask,
            Func<T1, T2, T3, T4, T5, T6, Task<Return<K, E>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, T5, T6, K), E>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, K), E>(resultToZip.Error)
                : Return.Success<(T1, T2, T3, T4, T5, T6, K), E>(
                    (v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, resultToZip.Value)
                );
        }

        public static async Task<Return<(T1, T2, T3, T4, T5, T6, T7, K)>> BindZip<T1, T2, T3, T4, T5, T6, T7, K>(
            this Task<Return<(T1, T2, T3, T4, T5, T6, T7)>> resultTask,
            Func<T1, T2, T3, T4, T5, T6, T7, Task<Return<K>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, T5, T6, T7, K)>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, v.Item7).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, T7, K)>(resultToZip.Error)
                : Return.Success<(T1, T2, T3, T4, T5, T6, T7, K)>(
                    (v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, v.Item7, resultToZip.Value)
                );
        }

        public static async Task<Return<(T1, T2, T3, T4, T5, T6, T7, K), E>> BindZip<T1, T2, T3, T4, T5, T6, T7, K, E>(
            this Task<Return<(T1, T2, T3, T4, T5, T6, T7), E>> resultTask,
            Func<T1, T2, T3, T4, T5, T6, T7, Task<Return<K, E>>> func
        ) {
            var result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, T5, T6, T7, K), E>(result.Error);
            }

            var v = result.Value;
            var resultToZip = await func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, v.Item7).DefaultAwait();

            return resultToZip.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, T7, K), E>(resultToZip.Error)
                : Return.Success<(T1, T2, T3, T4, T5, T6, T7, K), E>(
                    (v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, v.Item7, resultToZip.Value)
                );
        }
    }
}
#endif
