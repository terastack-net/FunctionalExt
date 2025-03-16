#if NET5_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
       public static async ValueTask<Return> Combine(this IEnumerable<ValueTask<Return>> tasks, string errorMessageSeparator = null)
        {
            Return[] results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Return<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<ValueTask<Return<T, E>>> tasks, Func<IEnumerable<E>, E> composerError)
        {
            Return<T, E>[] results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine(composerError);
        }

        public static async ValueTask<Return<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<ValueTask<Return<T, E>>> tasks)
            where E : ICombine
        {
            Return<T, E>[] results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine();
        }

        public static async ValueTask<Return<IEnumerable<T>>> Combine<T>(this IEnumerable<ValueTask<Return<T>>> tasks, string errorMessageSeparator = null)
        {
            Return<T>[] results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Return> Combine(this ValueTask<IEnumerable<Return>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Return> results = await task;
            return results.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Return<IEnumerable<T>, E>> Combine<T, E>(this ValueTask<IEnumerable<Return<T, E>>> task, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Return<T, E>> results = await task;
            return results.Combine(composerError);
        }

        public static async ValueTask<Return<IEnumerable<T>, E>> Combine<T, E>(this ValueTask<IEnumerable<Return<T, E>>> task)
            where E : ICombine
        {
            IEnumerable<Return<T, E>> results = await task;
            return results.Combine();
        }

        public static async ValueTask<Return<IEnumerable<T>>> Combine<T>(this ValueTask<IEnumerable<Return<T>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Return<T>> results = await task;
            return results.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Return> Combine(this ValueTask<IEnumerable<ValueTask<Return>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<ValueTask<Return>> tasks = await task;
            return await tasks.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Return<IEnumerable<T>, E>> Combine<T, E>(this ValueTask<IEnumerable<ValueTask<Return<T, E>>>> task, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<ValueTask<Return<T, E>>> tasks = await task;
            return await tasks.Combine(composerError);
        }

        public static async ValueTask<Return<IEnumerable<T>, E>> Combine<T, E>(this ValueTask<IEnumerable<ValueTask<Return<T, E>>>> task)
            where E : ICombine
        {
            IEnumerable<ValueTask<Return<T, E>>> tasks = await task;
            return await tasks.Combine();
        }

        public static async ValueTask<Return<IEnumerable<T>>> Combine<T>(this ValueTask<IEnumerable<ValueTask<Return<T>>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<ValueTask<Return<T>>> tasks = await task;
            return await tasks.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Return<K, E>> Combine<T, K, E>(this IEnumerable<ValueTask<Return<T, E>>> tasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Return<T, E>> results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine(composer, composerError);
        }

        public static async ValueTask<Return<K, E>> Combine<T, K, E>(this IEnumerable<ValueTask<Return<T, E>>> tasks, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<Return<T, E>> results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine(composer);
        }

        public static async ValueTask<Return<K>> Combine<T, K>(this IEnumerable<ValueTask<Return<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Return<T>> results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine(composer, errorMessageSeparator);
        }

        public static async ValueTask<Return<K, E>> Combine<T, K, E>(this ValueTask<IEnumerable<ValueTask<Return<T, E>>>> task, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<ValueTask<Return<T, E>>> tasks = await task;
            return await tasks.Combine(composer, composerError);
        }

        public static async ValueTask<Return<K, E>> Combine<T, K, E>(this ValueTask<IEnumerable<ValueTask<Return<T, E>>>> task, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<ValueTask<Return<T, E>>> tasks = await task;
            return await tasks.Combine(composer);
        }

        public static async ValueTask<Return<K>> Combine<T, K>(this ValueTask<IEnumerable<ValueTask<Return<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<ValueTask<Return<T>>> tasks = await task;
            return await tasks.Combine(composer, errorMessageSeparator);
        }
    }
}
#endif