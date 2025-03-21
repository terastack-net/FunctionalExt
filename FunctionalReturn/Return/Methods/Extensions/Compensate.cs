using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Return Compensate(this Return result, Func<Exception, Return> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static UnitReturn<E> Compensate<E>(this Return result, Func<Exception, UnitReturn<E>> func)
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E>();
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Return Compensate<T>(this Return<T> result, Func<Exception, Return> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Return<T> Compensate<T>(this Return<T> result, Func<Exception, Return<T>> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Return<T, E> Compensate<T, E>(this Return<T> result, Func<Exception, Return<T, E>> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E>(result.Value);
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Return Compensate<E>(this UnitReturn<E> result, Func<E, Return> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static UnitReturn<E2> Compensate<E, E2>(this UnitReturn<E> result, Func<E, UnitReturn<E2>> func)
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E2>();
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Return Compensate<T, E>(this Return<T, E> result, Func<E, Return> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static UnitReturn<E2> Compensate<T, E, E2>(this Return<T, E> result, Func<E, UnitReturn<E2>> func)
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E2>();
            }

            return func(result.Error);
        }

        /// <summary>
        ///     If the given result is a success returns a new success result. Otherwise it returns the result of the given function.
        /// </summary>
        public static Return<T, E2> Compensate<T, E, E2>(this Return<T, E> result, Func<E, Return<T, E2>> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E2>(result.Value);
            }

            return func(result.Error);
        }
    }
}