using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#if NET40
using Task = System.Threading.Tasks.TaskEx;
#else
using Task = System.Threading.Tasks.Task;
#endif

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async Task<Return> Combine(this IEnumerable<Task<Return>> tasks, string errorMessageSeparator = null)
        {
            Return[] results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Return<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<Task<Return<T, E>>> tasks, Func<IEnumerable<E>, E> composerError)
        {
            Return<T, E>[] results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine(composerError);
        }

        public static async Task<Return<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<Task<Return<T, E>>> tasks)
            where E : ICombine
        {
            Return<T, E>[] results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine();
        }

        public static async Task<Return<IEnumerable<T>>> Combine<T>(this IEnumerable<Task<Return<T>>> tasks, string errorMessageSeparator = null)
        {
            Return<T>[] results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Return> Combine(this Task<IEnumerable<Return>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Return> results = await task.DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Return<IEnumerable<T>, E>> Combine<T, E>(this Task<IEnumerable<Return<T, E>>> task, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Return<T, E>> results = await task.DefaultAwait();
            return results.Combine(composerError);
        }

        public static async Task<Return<IEnumerable<T>, E>> Combine<T, E>(this Task<IEnumerable<Return<T, E>>> task)
            where E : ICombine
        {
            IEnumerable<Return<T, E>> results = await task.DefaultAwait();
            return results.Combine();
        }

        public static async Task<Return<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Return<T>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Return<T>> results = await task.DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Return> Combine(this Task<IEnumerable<Task<Return>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Task<Return>> tasks = await task.DefaultAwait();
            return await tasks.Combine(errorMessageSeparator).DefaultAwait();
        }

        public static async Task<Return<IEnumerable<T>, E>> Combine<T, E>(this Task<IEnumerable<Task<Return<T, E>>>> task, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Task<Return<T, E>>> tasks = await task.DefaultAwait();
            return await tasks.Combine(composerError).DefaultAwait();
        }

        public static async Task<Return<IEnumerable<T>, E>> Combine<T, E>(this Task<IEnumerable<Task<Return<T, E>>>> task)
            where E : ICombine
        {
            IEnumerable<Task<Return<T, E>>> tasks = await task.DefaultAwait();
            return await tasks.Combine().DefaultAwait();
        }

        public static async Task<Return<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Task<Return<T>>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Task<Return<T>>> tasks = await task.DefaultAwait();
            return await tasks.Combine(errorMessageSeparator).DefaultAwait();
        }

        public static async Task<Return<K, E>> Combine<T, K, E>(this IEnumerable<Task<Return<T, E>>> tasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Return<T, E>> results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine(composer, composerError);
        }

        public static async Task<Return<K, E>> Combine<T, K, E>(this IEnumerable<Task<Return<T, E>>> tasks, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<Return<T, E>> results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine(composer);
        }

        public static async Task<Return<K>> Combine<T, K>(this IEnumerable<Task<Return<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Return<T>> results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine(composer, errorMessageSeparator);
        }

        public static async Task<Return<K, E>> Combine<T, K, E>(this Task<IEnumerable<Task<Return<T, E>>>> task, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Task<Return<T, E>>> tasks = await task.DefaultAwait();
            return await tasks.Combine(composer, composerError).DefaultAwait();
        }

        public static async Task<Return<K, E>> Combine<T, K, E>(this Task<IEnumerable<Task<Return<T, E>>>> task, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<Task<Return<T, E>>> tasks = await task.DefaultAwait();
            return await tasks.Combine(composer).DefaultAwait();
        }

        public static async Task<Return<K>> Combine<T, K>(this Task<IEnumerable<Task<Return<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Task<Return<T>>> tasks = await task.DefaultAwait();
            return await tasks.Combine(composer, errorMessageSeparator).DefaultAwait();
        }
    }
}
