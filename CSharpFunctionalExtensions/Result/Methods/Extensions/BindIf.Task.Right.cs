using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static Task<Return> BindIf(this Return result, bool condition, Func<Task<Return>> func)
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<Return<T>> BindIf<T>(this Return<T> result, bool condition, Func<T, Task<Return<T>>> func)
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<UnitReturn<E>> BindIf<E>(this UnitReturn<E> result, bool condition, Func<Task<UnitReturn<E>>> func)
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<Return<T, E>> BindIf<T, E>(this Return<T, E> result, bool condition, Func<T, Task<Return<T, E>>> func)
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<Return> BindIf(this Return result, Func<bool> predicate, Func<Task<Return>> func)
        {
            if (!result.IsSuccess || !predicate())
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<Return<T>> BindIf<T>(this Return<T> result, Func<T, bool> predicate, Func<T, Task<Return<T>>> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<UnitReturn<E>> BindIf<E>(this UnitReturn<E> result, Func<bool> predicate, Func<Task<UnitReturn<E>>> func)
        {
            if (!result.IsSuccess || !predicate())
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<Return<T, E>> BindIf<T, E>(this Return<T, E> result, Func<T, bool> predicate, Func<T, Task<Return<T, E>>> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }
    }
}