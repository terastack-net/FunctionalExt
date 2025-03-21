﻿#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<T> GetValueOrDefault<T>(this Return<T> result, Func<ValueTask<T>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask();

            return result.Value;
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this Return<T> result, Func<T, K> selector,
            Func<ValueTask<K>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask();

            return selector(result.Value);
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this Return<T> result, Func<T, ValueTask<K>> valueTask,
            K defaultValue = default)
        {
            if (result.IsFailure)
                return defaultValue;

            return await valueTask(result.Value);
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this Return<T> result, Func<T, ValueTask<K>> valueTask,
            Func<ValueTask<K>> defaultValue)
        {
            if (result.IsFailure)
                return await defaultValue();

            return await valueTask(result.Value);
        }
    }
}
#endif
