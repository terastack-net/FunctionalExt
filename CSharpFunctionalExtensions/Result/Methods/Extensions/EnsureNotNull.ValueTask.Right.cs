#if NET5_0_OR_GREATER
#nullable enable

using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Return<T>> EnsureNotNull<T>(this Return<T?> result, Func<ValueTask<string>> errorFactory)
            where T : class
        {
            return result.Ensure(value => ValueTask.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static ValueTask<Return<T>> EnsureNotNull<T>(this Return<T?> result, Func<ValueTask<string>> errorFactory)
            where T : struct
        {
            return result.Ensure(value => ValueTask.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }

        public static ValueTask<Return<T, E>> EnsureNotNull<T, E>(this Return<T?, E> result, Func<ValueTask<E>> errorFactory)
            where T : class
        {
            return result.Ensure(value => ValueTask.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static ValueTask<Return<T, E>> EnsureNotNull<T, E>(this Return<T?, E> result, Func<ValueTask<E>> errorFactory)
            where T : struct
        {
            return result.Ensure(value => ValueTask.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }
    }
}
#endif