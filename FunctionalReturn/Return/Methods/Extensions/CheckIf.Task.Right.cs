using System;
using System.Threading.Tasks;

#if NET40
using Task = System.Threading.Tasks.TaskEx;
#else
using Task = System.Threading.Tasks.Task;
#endif

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static Task<Return<T>> CheckIf<T>(this Return<T> result, bool condition, Func<T, Task<Return>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Return<T>> CheckIf<T, K>(this Return<T> result, bool condition, Func<T, Task<Return<K>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Return<T, E>> CheckIf<T, K, E>(this Return<T, E> result, bool condition, Func<T, Task<Return<K, E>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Return<T, E>> CheckIf<T, E>(this Return<T, E> result, bool condition, Func<T, Task<UnitReturn<E>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<UnitReturn<E>> CheckIf<E>(this UnitReturn<E> result, bool condition, Func<Task<UnitReturn<E>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Return<T>> CheckIf<T>(this Return<T> result, Func<T, bool> predicate, Func<T, Task<Return>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Return<T>> CheckIf<T, K>(this Return<T> result, Func<T, bool> predicate, Func<T, Task<Return<K>>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Return<T, E>> CheckIf<T, K, E>(this Return<T, E> result, Func<T, bool> predicate, Func<T, Task<Return<K, E>>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Return<T, E>> CheckIf<T, E>(this Return<T, E> result, Func<T, bool> predicate, Func<T, Task<UnitReturn<E>>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static async Task<UnitReturn<E>> CheckIf<E>(this UnitReturn<E> result, Func<bool> predicate, Func<Task<UnitReturn<E>>> func)
        {
            if (result.IsSuccess && predicate())
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }
    }
}
