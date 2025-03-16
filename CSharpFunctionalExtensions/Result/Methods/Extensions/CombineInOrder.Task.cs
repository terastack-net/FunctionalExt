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
        public static async Task<Return> CombineInOrder(this IEnumerable<Task<Return>> tasks, string errorMessageSeparator = null)
        {
            Return[] results = await CompleteInOrder(tasks).DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Return<IEnumerable<T>, E>> CombineInOrder<T, E>(this IEnumerable<Task<Return<T, E>>> tasks, Func<IEnumerable<E>, E> composerError)
        {
            Return<T, E>[] results = await CompleteInOrder(tasks).DefaultAwait();
            return results.Combine(composerError);
        }

        public static async Task<Return<IEnumerable<T>, E>> CombineInOrder<T, E>(this IEnumerable<Task<Return<T, E>>> tasks)
            where E : ICombine
        {
            Return<T, E>[] results = await CompleteInOrder(tasks).DefaultAwait();
            return results.Combine();
        }

        public static async Task<Return<IEnumerable<T>>> CombineInOrder<T>(this IEnumerable<Task<Return<T>>> tasks, string errorMessageSeparator = null)
        {
            Return<T>[] results = await CompleteInOrder(tasks).DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Return> CombineInOrder(this Task<IEnumerable<Task<Return>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Task<Return>> tasks = await task.DefaultAwait();
            return await tasks.CombineInOrder(errorMessageSeparator).DefaultAwait();
        }

        public static async Task<Return<IEnumerable<T>, E>> CombineInOrder<T, E>(this Task<IEnumerable<Task<Return<T, E>>>> task, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Task<Return<T, E>>> tasks = await task.DefaultAwait();
            return await tasks.CombineInOrder(composerError).DefaultAwait();
        }

        public static async Task<Return<IEnumerable<T>, E>> CombineInOrder<T, E>(this Task<IEnumerable<Task<Return<T, E>>>> task)
            where E : ICombine
        {
            IEnumerable<Task<Return<T, E>>> tasks = await task.DefaultAwait();
            return await tasks.CombineInOrder().DefaultAwait();
        }

        public static async Task<Return<IEnumerable<T>>> CombineInOrder<T>(this Task<IEnumerable<Task<Return<T>>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Task<Return<T>>> tasks = await task.DefaultAwait();
            return await tasks.CombineInOrder(errorMessageSeparator).DefaultAwait();
        }

        public static async Task<Return<K, E>> CombineInOrder<T, K, E>(this IEnumerable<Task<Return<T, E>>> tasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Return<T, E>> results = await CompleteInOrder(tasks).DefaultAwait();
            return results.Combine(composer, composerError);
        }

        public static async Task<Return<K, E>> CombineInOrder<T, K, E>(this IEnumerable<Task<Return<T, E>>> tasks, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<Return<T, E>> results = await CompleteInOrder(tasks).DefaultAwait();
            return results.Combine(composer);
        }

        public static async Task<Return<K>> CombineInOrder<T, K>(this IEnumerable<Task<Return<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Return<T>> results = await CompleteInOrder(tasks).DefaultAwait();
            return results.Combine(composer, errorMessageSeparator);
        }

        public static async Task<Return<K, E>> CombineInOrder<T, K, E>(this Task<IEnumerable<Task<Return<T, E>>>> task, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Task<Return<T, E>>> tasks = await task.DefaultAwait();
            return await tasks.CombineInOrder(composer, composerError).DefaultAwait();
        }

        public static async Task<Return<K, E>> CombineInOrder<T, K, E>(this Task<IEnumerable<Task<Return<T, E>>>> task, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<Task<Return<T, E>>> tasks = await task.DefaultAwait();
            return await tasks.CombineInOrder(composer).DefaultAwait();
        }

        public static async Task<Return<K>> CombineInOrder<T, K>(this Task<IEnumerable<Task<Return<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Task<Return<T>>> tasks = await task.DefaultAwait();
            return await tasks.CombineInOrder(composer, errorMessageSeparator).DefaultAwait();
        }

        public static async Task<T[]> CompleteInOrder<T>(IEnumerable<Task<T>> tasks)
        {
            List<T> results = new List<T>();
            foreach (var task in tasks)
            {
                results.Add(await task.DefaultAwait());
            }
            return results.ToArray();
        }
    }
}
