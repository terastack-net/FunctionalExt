using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static Return Combine(this IEnumerable<Return> results, string errorMessageSeparator = null)
            => Return.Combine(results, errorMessageSeparator);

        public static UnitReturn<E> Combine<E>(this IEnumerable<UnitReturn<E>> results)
            where E : ICombineReturn
            => Return.Combine(results);

        public static Return<IEnumerable<T>, E> Combine<T, E>(this IEnumerable<Return<T, E>> results)
            where E : ICombineReturn
        {
            results = results.ToList();
            Return<bool, E> result = Return.Combine(results);

            return result.IsSuccess
                ? Return.Success<IEnumerable<T>, E>(results.Select(e => e.Value))
                : Return.Failure<IEnumerable<T>, E>(result.Error);
        }

        public static Return<IEnumerable<T>, E> Combine<T, E>(this IEnumerable<Return<T, E>> results, Func<IEnumerable<E>, E> composerError)
        {
            results = results.ToList();
            Return<bool, E> result = Return.Combine(results, composerError);

            return result.IsSuccess
                ? Return.Success<IEnumerable<T>, E>(results.Select(e => e.Value))
                : Return.Failure<IEnumerable<T>, E>(result.Error);
        }

        public static Return<IEnumerable<T>> Combine<T>(this IEnumerable<Return<T>> results, string errorMessageSeparator = null)
        {
            results = results.ToList();
            Return result = Return.Combine(results, errorMessageSeparator);

            return result.IsSuccess
                ? Return.Success(results.Select(e => e.Value))
                : Return.Failure<IEnumerable<T>>(result.Error);
        }

        public static Return<K, E> Combine<T, K, E>(this IEnumerable<Return<T, E>> results, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            Return<IEnumerable<T>, E> result = results.Combine(composerError);

            return result.IsSuccess
                ? Return.Success<K, E>(composer(result.Value))
                : Return.Failure<K, E>(result.Error);
        }

        public static Return<K, E> Combine<T, K, E>(this IEnumerable<Return<T, E>> results, Func<IEnumerable<T>, K> composer)
            where E : ICombineReturn
        {
            Return<IEnumerable<T>, E> result = results.Combine<T, E>();

            return result.IsSuccess
                ? Return.Success<K, E>(composer(result.Value))
                : Return.Failure<K, E>(result.Error);
        }

        public static Return<K> Combine<T, K>(this IEnumerable<Return<T>> results, Func<IEnumerable<T>, K> composer,
            string errorMessageSeparator = null)
        {
            Return<IEnumerable<T>> result = results.Combine(errorMessageSeparator);

            return result.IsSuccess
                ? Return.Success(composer(result.Value))
                : Return.Failure<K>(result.Error);
        }
    }
}
