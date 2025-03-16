#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<Return> BindIf(this ValueTask<Return> resultTask, bool condition, Func<Return> valueTask)
        {
            var result = await resultTask;
            return result.BindIf(condition, valueTask);
        }

        public static async ValueTask<Return<T>> BindIf<T>(this ValueTask<Return<T>> resultTask, bool condition, Func<T, Return<T>> valueTask)
        {
            var result = await resultTask;
            return result.BindIf(condition, valueTask);
        }

        public static async ValueTask<UnitReturn<E>> BindIf<E>(this ValueTask<UnitReturn<E>> resultTask, bool condition, Func<UnitReturn<E>> valueTask)
        {
            var result = await resultTask;
            return result.BindIf(condition, valueTask);
        }

        public static async ValueTask<Return<T, E>> BindIf<T, E>(this ValueTask<Return<T, E>> resultTask, bool condition, Func<T, Return<T, E>> valueTask)
        {
            var result = await resultTask;
            return result.BindIf(condition, valueTask);
        }

        public static async ValueTask<Return> BindIf(this ValueTask<Return> resultTask, Func<bool> predicate, Func<Return> valueTask)
        {
            var result = await resultTask;
            return result.BindIf(predicate, valueTask);
        }

        public static async ValueTask<Return<T>> BindIf<T>(this ValueTask<Return<T>> resultTask, Func<T, bool> predicate, Func<T, Return<T>> valueTask)
        {
            var result = await resultTask;
            return result.BindIf(predicate, valueTask);
        }

        public static async ValueTask<UnitReturn<E>> BindIf<E>(this ValueTask<UnitReturn<E>> resultTask, Func<bool> predicate, Func<UnitReturn<E>> valueTask)
        {
            var result = await resultTask;
            return result.BindIf(predicate, valueTask);
        }

        public static async ValueTask<Return<T, E>> BindIf<T, E>(this ValueTask<Return<T, E>> resultTask, Func<T, bool> predicate, Func<T, Return<T, E>> valueTask)
        {
            var result = await resultTask;
            return result.BindIf(predicate, valueTask);
        }
    }
}
#endif