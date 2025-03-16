#nullable enable

using System;
using System.Threading.Tasks;

#if NET40
using Task = System.Threading.Tasks.TaskEx;
#else
using Task = System.Threading.Tasks.Task;
#endif

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static Task<Return<T>> EnsureNotNull<T>(this Return<T?> result)
            where T : class
        {
            return result.Ensure(value => Task.FromResult(value != null), _ => new ArgumentNullException() ).Map(value => value!);
        }

        public static Return<T> EnsureNotNull<T>(this Return<T?> result, string error)
            where T : class
        {
            return result.Ensure(value => value != null, _ => new Exception(error)).Map(value => value!);
        }

        public static Task<Return<T>> EnsureNotNull<T>(this Return<T?> result, Func<Task<Exception>> errorFactory)
            where T : class
        {
            return result.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static Task<Return<T>> EnsureNotNull<T>(this Return<T?> result, Func<Task<Exception>> errorFactory)
            where T : struct
        {
            return result.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }

        public static Task<Return<T, E>> EnsureNotNull<T, E>(this Return<T?, E> result, Func<Task<E>> errorFactory)
            where T : class
        {
            return result.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static Task<Return<T, E>> EnsureNotNull<T, E>(this Return<T?, E> result, Func<Task<E>> errorFactory)
            where T : struct
        {
            return result.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }
    }
}
