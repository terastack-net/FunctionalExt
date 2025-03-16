using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static async Task<Return> BindIf(this Task<Return> resultTask, bool condition, Func<Task<Return>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.BindIf(condition, func).DefaultAwait();
        }

        public static async Task<Return<T>> BindIf<T>(this Task<Return<T>> resultTask, bool condition, Func<T, Task<Return<T>>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.BindIf(condition, func).DefaultAwait();
        }

        public static async Task<UnitResult<E>> BindIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<Task<UnitResult<E>>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.BindIf(condition, func).DefaultAwait();
        }

        public static async Task<Return<T, E>> BindIf<T, E>(this Task<Return<T, E>> resultTask, bool condition, Func<T, Task<Return<T, E>>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.BindIf(condition, func).DefaultAwait();
        }

        public static async Task<Return> BindIf(this Task<Return> resultTask, Func<bool> predicate, Func<Task<Return>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.BindIf(predicate, func).DefaultAwait();
        }

        public static async Task<Return<T>> BindIf<T>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Return<T>>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.BindIf(predicate, func).DefaultAwait();
        }

        public static async Task<UnitResult<E>> BindIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Func<Task<UnitResult<E>>> func)
        {
            
            var result = await resultTask.DefaultAwait();
            return await result.BindIf(predicate, func).DefaultAwait();
        }

        public static async Task<Return<T, E>> BindIf<T, E>(this Task<Return<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task<Return<T, E>>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.BindIf(predicate, func).DefaultAwait();
        }
    }
}