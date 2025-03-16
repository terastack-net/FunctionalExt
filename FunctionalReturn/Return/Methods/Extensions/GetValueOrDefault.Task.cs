using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static async Task<T> GetValueOrDefault<T>(this Task<Return<T>> resultTask, Func<Task<T>> defaultValue)
        {
            var result = await resultTask.DefaultAwait();
            return await result.GetValueOrDefault(defaultValue).DefaultAwait();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Task<Return<T>> resultTask, Func<T, Task<K>> selector,
            K defaultValue = default)
        {
            var result = await resultTask.DefaultAwait();
            return await result.GetValueOrDefault(selector, defaultValue).DefaultAwait();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Task<Return<T>> resultTask, Func<T, Task<K>> selector,
            Func<Task<K>> defaultValue)
        {
            var result = await resultTask.DefaultAwait();
            return await result.GetValueOrDefault(selector, defaultValue).DefaultAwait();
        }
    }
}
