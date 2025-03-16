#if NET5_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async ValueTask<Return> CombineInOrder(this IEnumerable<ValueTask<Return>> tasks, string errorMessageSeparator = null)
        {
            Return[] results = await CompleteInOrder(tasks);
            return results.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Return<IEnumerable<T>, E>> CombineInOrder<T, E>(this IEnumerable<ValueTask<Return<T, E>>> tasks, Func<IEnumerable<E>, E> composerError)
        {
            Return<T, E>[] results = await CompleteInOrder(tasks);
            return results.Combine(composerError);
        }

        public static async ValueTask<Return<IEnumerable<T>, E>> CombineInOrder<T, E>(this IEnumerable<ValueTask<Return<T, E>>> tasks)
            where E : ICombine
        {
            Return<T, E>[] results = await CompleteInOrder(tasks);
            return results.Combine();
        }

        public static async ValueTask<Return<IEnumerable<T>>> CombineInOrder<T>(this IEnumerable<ValueTask<Return<T>>> tasks, string errorMessageSeparator = null)
        {
            Return<T>[] results = await CompleteInOrder(tasks);
            return results.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Return> CombineInOrder(this ValueTask<IEnumerable<ValueTask<Return>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<ValueTask<Return>> tasks = await task;
            return await tasks.CombineInOrder(errorMessageSeparator);
        }

        public static async ValueTask<Return<IEnumerable<T>, E>> CombineInOrder<T, E>(this ValueTask<IEnumerable<ValueTask<Return<T, E>>>> task, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<ValueTask<Return<T, E>>> tasks = await task;
            return await tasks.CombineInOrder(composerError);
        }

        public static async ValueTask<Return<IEnumerable<T>, E>> CombineInOrder<T, E>(this ValueTask<IEnumerable<ValueTask<Return<T, E>>>> task)
            where E : ICombine
        {
            IEnumerable<ValueTask<Return<T, E>>> tasks = await task;
            return await tasks.CombineInOrder();
        }

        public static async ValueTask<Return<IEnumerable<T>>> CombineInOrder<T>(this ValueTask<IEnumerable<ValueTask<Return<T>>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<ValueTask<Return<T>>> tasks = await task;
            return await tasks.CombineInOrder(errorMessageSeparator);
        }

        public static async ValueTask<Return<K, E>> CombineInOrder<T, K, E>(this IEnumerable<ValueTask<Return<T, E>>> tasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Return<T, E>> results = await CompleteInOrder(tasks);
            return results.Combine(composer, composerError);
        }

        public static async ValueTask<Return<K, E>> CombineInOrder<T, K, E>(this IEnumerable<ValueTask<Return<T, E>>> tasks, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<Return<T, E>> results = await CompleteInOrder(tasks);
            return results.Combine(composer);
        }

        public static async ValueTask<Return<K>> CombineInOrder<T, K>(this IEnumerable<ValueTask<Return<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Return<T>> results = await CompleteInOrder(tasks);
            return results.Combine(composer, errorMessageSeparator);
        }

        public static async ValueTask<Return<K, E>> CombineInOrder<T, K, E>(this ValueTask<IEnumerable<ValueTask<Return<T, E>>>> task, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<ValueTask<Return<T, E>>> tasks = await task;
            return await tasks.CombineInOrder(composer, composerError);
        }

        public static async ValueTask<Return<K, E>> CombineInOrder<T, K, E>(this ValueTask<IEnumerable<ValueTask<Return<T, E>>>> task, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<ValueTask<Return<T, E>>> tasks = await task;
            return await tasks.CombineInOrder(composer);
        }

        public static async ValueTask<Return<K>> CombineInOrder<T, K>(this ValueTask<IEnumerable<ValueTask<Return<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<ValueTask<Return<T>>> tasks = await task;
            return await tasks.CombineInOrder(composer, errorMessageSeparator);
        }

        public static async ValueTask<T[]> CompleteInOrder<T>(IEnumerable<ValueTask<T>> tasks)
        {
            List<T> results = new List<T>();
            foreach (var task in tasks)
            {
                results.Add(await task);
            }
            return results.ToArray();
        }
    }
}
#endif
