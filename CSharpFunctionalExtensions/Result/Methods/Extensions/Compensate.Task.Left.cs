using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static async Task<Return> Compensate(this Task<Return> resultTask, Func<Exception, Return> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<UnitResult<E>> Compensate<E>(this Task<Return> resultTask, Func<Exception, UnitResult<E>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<Return> Compensate<T>(this Task<Return<T>> resultTask, Func<Exception, Return> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<Return<T>> Compensate<T>(this Task<Return<T>> resultTask, Func<Exception, Return<T>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<Return<T, E>> Compensate<T, E>(this Task<Return<T>> resultTask, Func<Exception, Return<T, E>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<Return> Compensate<E>(this Task<UnitResult<E>> resultTask, Func<E, Return> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<UnitResult<E2>> Compensate<E, E2>(this Task<UnitResult<E>> resultTask, Func<E, UnitResult<E2>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<Return> Compensate<T, E>(this Task<Return<T, E>> resultTask, Func<E, Return> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<UnitResult<E2>> Compensate<T, E, E2>(this Task<Return<T, E>> resultTask, Func<E, UnitResult<E2>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<Return<T, E2>> Compensate<T, E, E2>(this Task<Return<T, E>> resultTask, Func<E, Return<T, E2>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }
    }
}