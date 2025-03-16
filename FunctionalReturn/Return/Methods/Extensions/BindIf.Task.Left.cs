using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static async Task<Return> BindIf(this Task<Return> resultTask, bool condition, Func<Return> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(condition, func);
        }

        public static async Task<Return<T>> BindIf<T>(this Task<Return<T>> resultTask, bool condition, Func<T, Return<T>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(condition, func);
        }

        public static async Task<UnitReturn<E>> BindIf<E>(this Task<UnitReturn<E>> resultTask, bool condition, Func<UnitReturn<E>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(condition, func);
        }

        public static async Task<Return<T, E>> BindIf<T, E>(this Task<Return<T, E>> resultTask, bool condition, Func<T, Return<T, E>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(condition, func);
        }

        public static async Task<Return> BindIf(this Task<Return> resultTask, Func<bool> predicate, Func<Return> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(predicate, func);
        }

        public static async Task<Return<T>> BindIf<T>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Func<T, Return<T>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(predicate, func);
        }

        public static async Task<UnitReturn<E>> BindIf<E>(this Task<UnitReturn<E>> resultTask, Func<bool> predicate, Func<UnitReturn<E>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(predicate, func);
        }

        public static async Task<Return<T, E>> BindIf<T, E>(this Task<Return<T, E>> resultTask, Func<T, bool> predicate, Func<T, Return<T, E>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(predicate, func);
        }
    }
}