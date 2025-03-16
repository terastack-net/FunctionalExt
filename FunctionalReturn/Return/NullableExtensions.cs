#if NETCOREAPP3_0_OR_GREATER
using System.Threading.Tasks;

namespace FunctionalReturn
{

    public static partial class NullableExtensions
    {
        public static Return<T, E> ToReturn<T, E>(in this T? nullable, E error)
            where T : struct
        {
            if (!nullable.HasValue)
                return Return.Failure<T, E>(error);

            return Return.Success<T, E>(nullable.Value);
        }
        public static Return<T, E> ToReturn<T, E>(this T? obj, E error)
            where T : class
        {
            if (obj == null)
                return Return.Failure<T, E>(error);

            return Return.Success<T, E>(obj);
        }

        public static async Task<Return<T, E>> ToReturnAsync<T, E>(this Task<T?> nullableTask, E errors)
            where T : struct
        {
            var nullable = await nullableTask.ConfigureAwait(false);
            return nullable.ToReturn(errors);
        }

        public static async Task<Return<T, E>> ToReturnAsync<T, E>(this Task<T?> nullableTask, E errors)
        where T : class
        {
            var nullable = await nullableTask.ConfigureAwait(false);
            return nullable.ToReturn(errors);
        }
        
        public static async ValueTask<Return<T, E>> ToReturnAsync<T, E>(this ValueTask<T?> nullableTask, E errors)
            where T : struct
        {
            var nullable = await nullableTask.ConfigureAwait(false);
            return nullable.ToReturn(errors);
        }

        public static async ValueTask<Return<T, E>> ToResultAsync<T, E>(this ValueTask<T?> nullableTask, E errors)
            where T : class
        {
            var nullable = await nullableTask.ConfigureAwait(false);
            return nullable.ToReturn(errors);
        }
    }
}

#endif
