#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<Return> Compensate(this ValueTask<Return> resultTask, Func<Exception, Return> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<UnitResult<E>> Compensate<E>(this ValueTask<Return> resultTask, Func<Exception, UnitResult<E>> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<Return> Compensate<T>(this ValueTask<Return<T>> resultTask, Func<Exception, Return> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<Return<T>> Compensate<T>(this ValueTask<Return<T>> resultTask, Func<Exception, Return<T>> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<Return<T, E>> Compensate<T, E>(this ValueTask<Return<T>> resultTask, Func<Exception, Return<T, E>> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<Return> Compensate<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, Return> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<UnitResult<E2>> Compensate<E, E2>(this ValueTask<UnitResult<E>> resultTask, Func<E, UnitResult<E2>> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<Return> Compensate<T, E>(this ValueTask<Return<T, E>> resultTask, Func<E, Return> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<UnitResult<E2>> Compensate<T, E, E2>(this ValueTask<Return<T, E>> resultTask, Func<E, UnitResult<E2>> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<Return<T, E2>> Compensate<T, E, E2>(this ValueTask<Return<T, E>> resultTask, Func<E, Return<T, E2>> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }
    }
}
#endif