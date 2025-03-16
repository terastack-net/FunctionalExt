using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalReturn
{
    public partial struct Return
    {
        /// <summary>
        ///     Combines several results (and any error messages) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.</summary>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <param name="errorMessagesSeparator">
        ///     A string that is used to separate any concatenated error messages. If omitted, the default <see cref="Return.Configuration.ErrorMessagesSeparator" /> is used.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static Return Combine(IEnumerable<Return> results, string errorMessagesSeparator = null)
        {
            List<Return> failedResults = results.Where(x => x.IsFailure).ToList();

            if (failedResults.Count == 0)
                return Success();

            return Failure(new AggregateException(failedResults.Select(x => x.Error).ToList()));
        }

        /// <summary>
        ///     Combines several results (and any error messages) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.</summary>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <param name="errorMessagesSeparator">
        ///     A string that is used to separate any concatenated error messages. If omitted, the default <see cref="Return.Configuration.ErrorMessagesSeparator" /> is used.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static Return Combine<T>(IEnumerable<Return<T>> results, string errorMessagesSeparator = null)
        {
            IEnumerable<Return> untyped = results.Select(result => (Return)result);
            return Combine(untyped, errorMessagesSeparator);
        }

        /// <summary>
        ///     Combines several results (and any errors) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        /// </summary>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <param name="composerError">
        ///     A function that combines any errors.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static UnitReturn<E> Combine<E>(IEnumerable<UnitReturn<E>> results, Func<IEnumerable<E>, E> composerError)
        {
            List<UnitReturn<E>> failedResults = results.Where(x => x.IsFailure).ToList();

            if (failedResults.Count == 0)
                return UnitReturn.Success<E>();

            E error = composerError(failedResults.Select(x => x.Error));
            return UnitReturn.Failure(error);
        }

        /// <summary>
        ///     Combines several results (and any errors) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        /// </summary>
        /// <param name="composerError">
        ///     A function that combines any errors.</param>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static UnitReturn<E> Combine<E>(Func<IEnumerable<E>, E> composerError, params UnitReturn<E>[] results)
            => Combine(results, composerError);

        /// <summary>
        ///     Combines several results (and any errors) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        /// </summary>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static UnitReturn<E> Combine<E>(params UnitReturn<E>[] results)
            where E : ICombineReturn
            => Combine(results, CombineErrors);

        /// <summary>
        ///     Combines several results (and any errors) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        /// </summary>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static UnitReturn<E> Combine<E>(IEnumerable<UnitReturn<E>> results)
            where E : ICombineReturn
            => Combine(results, CombineErrors);

        // TODO: Ideally, we would be using BaseResult<E> or equivalent instead of Result<bool, E>.
        /// <summary>
        ///     Combines several results (and any errors) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        ///     NB: The bool value type is arbitrary - the value is not intended to be used.</summary>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <param name="composerError">
        ///     A function that combines any errors.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static Return<bool, E> Combine<T, E>(IEnumerable<Return<T, E>> results, Func<IEnumerable<E>, E> composerError)
        {
            var combinedResult = Combine(results.Select(r => (UnitReturn<E>)r), composerError);
            return combinedResult.IsSuccess
                ? Success<bool, E>(true)
                : Failure<bool, E>(combinedResult.Error);
        }

        // TODO: Ideally, we would be using BaseResult<E> or equivalent instead of Result<bool, E>.
        /// <summary>
        ///     Combines several results (and any errors) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        ///     The E error class must implement ICombine to provide an accumulator function for combining any errors.
        ///     NB: The bool value type is arbitrary - the value is not intended to be used.</summary>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static Return<bool, E> Combine<T, E>(IEnumerable<Return<T, E>> results)
            where E : ICombineReturn
            => Combine(results, CombineErrors);

        /// <summary>
        ///     Combines several results (and any error messages) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        ///     Error messages are concatenated with the default <see cref="Return.Configuration.ErrorMessagesSeparator" /> between each message.</summary>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static Return Combine(params Return[] results)
            => Combine(results, Configuration.ErrorMessagesSeparator);

        /// <summary>
        ///     Combines several results (and any error messages) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        ///     Error messages are concatenated with the default <see cref="Return.Configuration.ErrorMessagesSeparator" /> between each message.</summary>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static Return Combine<T>(params Return<T>[] results)
            => Combine(results, Configuration.ErrorMessagesSeparator);

        // TODO: Ideally, we would be using BaseResult<E> or equivalent instead of Result<bool, E>.
        /// <summary>
        ///     Combines several results (and any errors) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        ///     The E error class must implement ICombine to provide an accumulator function for combining any errors.
        ///     NB: The bool value type is arbitrary - the result Value is not intended to be used.</summary>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static Return<bool, E> Combine<T, E>(params Return<T, E>[] results)
            where E : ICombineReturn
            => Combine(results, CombineErrors);

        /// <summary>
        ///     Combines several results (and any error messages) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.</summary>
        /// <param name="errorMessagesSeparator">
        ///     A string that is used to separate any concatenated error messages. If omitted, the default <see cref="Return.Configuration.ErrorMessagesSeparator" /> is used.</param>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static Return Combine(string errorMessagesSeparator, params Return[] results)
            => Combine(results, errorMessagesSeparator);

        /// <summary>
        ///     Combines several results (and any error messages) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.</summary>
        /// <param name="errorMessagesSeparator">
        ///     A string that is used to separate any concatenated error messages. If omitted, the default <see cref="Return.Configuration.ErrorMessagesSeparator" /> is used.</param>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static Return Combine<T>(string errorMessagesSeparator, params Return<T>[] results)
            => Combine(results, errorMessagesSeparator);

        // TODO: Ideally, we would be using BaseResult<E> or equivalent instead of Result<bool, E>.
        /// <summary>
        ///     Combines several results (and any errors) into a single result.
        ///     The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        ///     NB: The bool value type is arbitrary - the result Value is not intended to be used.</summary>
        /// <param name="composerError">
        ///     A function that combines any errors.</param>
        /// <param name="results">
        ///     The Results to be combined.</param>
        /// <returns>
        ///     A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        public static Return<bool, E> Combine<T, E>(Func<IEnumerable<E>, E> composerError, params Return<T, E>[] results)
            => Combine(results, composerError);

        private static E CombineErrors<E>(IEnumerable<E> errors)
            where E : ICombineReturn
            => errors.Aggregate((x, y) => (E)x.Combine(y));

        private static IEnumerable<string> AggregateMessages(IEnumerable<string> messages)
        {
            var dict = new Dictionary<string, int>();
            foreach (var message in messages)
            {
                if (!dict.ContainsKey(message))
                    dict.Add(message, 0);

                dict[message]++;
            }

            return dict.Select(x => x.Value == 1 ? x.Key : $"{x.Key} ({x.Value}×)");
        }
    }
}
