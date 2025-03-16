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
        public static Task<Return<T>> EnsureNotNull<T>(this Task<Return<T?>> resultTask, Exception error)
            where T : class
        {
            return resultTask.Ensure(value => value != null, error).Map(value => value!);
        }

        public static Task<Return<T>> EnsureNotNull<T>(this Task<Return<T?>> resultTask, Exception error)
            where T : struct
        {
            return resultTask.Ensure(value => value != null, error).Map(value => value!.Value);
        }

        public static Task<Return<T>> EnsureNotNull<T>(this Task<Return<T?>> resultTask, Func<Task<Exception>> errorFactory)
            where T : class
        {
            return resultTask.Ensure(value => value != null, _ => errorFactory()).Map(value => value!);
        }

        public static Task<Return<T>> EnsureNotNull<T>(this Task<Return<T?>> resultTask, Func<Task<Exception>> errorFactory)
            where T : struct
        {
            return resultTask.Ensure(value => value != null, _ => errorFactory()).Map(value => value!.Value);
        }

        public static Task<Return<T, E>> EnsureNotNull<T, E>(this Task<Return<T?, E>> resultTask, E error)
            where T : class
        {
            return resultTask.Ensure(value => value != null, error).Map(value => value!);
        }

        public static Task<Return<T, E>> EnsureNotNull<T, E>(this Task<Return<T?, E>> resultTask, E error)
            where T : struct
        {
            return resultTask.Ensure(value => value != null, error).Map(value => value!.Value);
        }

        public static Task<Return<T, E>> EnsureNotNull<T, E>(this Task<Return<T?, E>> resultTask, Func<Task<E>> errorFactory)
            where T : class
        {
            return resultTask.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static Task<Return<T, E>> EnsureNotNull<T, E>(this Task<Return<T?, E>> resultTask, Func<Task<E>> errorFactory)
            where T : struct
        {
            return resultTask.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }
    }
}
