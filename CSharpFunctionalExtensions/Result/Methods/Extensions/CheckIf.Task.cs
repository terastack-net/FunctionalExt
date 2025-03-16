using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        public static Task<Return<T>> CheckIf<T>(this Task<Return<T>> resultTask, bool condition, Func<T, Task<Return>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static Task<Return<T>> CheckIf<T, K>(this Task<Return<T>> resultTask, bool condition, Func<T, Task<Return<K>>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static Task<Return<T, E>> CheckIf<T, K, E>(this Task<Return<T, E>> resultTask, bool condition, Func<T, Task<Return<K, E>>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static Task<Return<T, E>> CheckIf<T, E>(this Task<Return<T, E>> resultTask, bool condition, Func<T, Task<UnitResult<E>>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static Task<UnitResult<E>> CheckIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<Task<UnitResult<E>>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }
        
        public static async Task<Return<T>> CheckIf<T>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Return>> func)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }

        public static async Task<Return<T>> CheckIf<T, K>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Return<K>>> func)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }

        public static async Task<Return<T, E>> CheckIf<T, K, E>(this Task<Return<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task<Return<K, E>>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }

        public static async Task<Return<T, E>> CheckIf<T, E>(this Task<Return<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task<UnitResult<E>>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }

        public static async Task<UnitResult<E>> CheckIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Func<Task<UnitResult<E>>> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate())
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }
    }
}
