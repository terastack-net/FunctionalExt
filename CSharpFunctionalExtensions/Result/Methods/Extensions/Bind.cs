using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<K, E> Bind<T, K, E>(this Return<T, E> result, Func<T, Return<K, E>> func)
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<K> Bind<T, K>(this Return<T> result, Func<T, Return<K>> func)
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<K> Bind<K>(this Return result, Func<Return<K>> func)
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return Bind<T>(this Return<T> result, Func<T, Return> func)
        {
            if (result.IsFailure)
                return result;

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return Bind(this Return result, Func<Return> func)
        {
            if (result.IsFailure)
                return result;

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UnitReturn<E> Bind<E>(this UnitReturn<E> result, Func<UnitReturn<E>> func)
        {
            if (result.IsFailure)
                return result.Error;
            
            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<T, E> Bind<T, E>(this UnitReturn<E> result, Func<Return<T, E>> func)
        {
            if (result.IsFailure)
                return result.Error;
            
            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UnitReturn<E> Bind<T, E>(this Return<T, E> result, Func<T, UnitReturn<E>> func)
        {
            if (result.IsFailure) 
                return result.Error;

            return func(result.Value);
        }
    }
}
