#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        public static ValueTask<Return<T>> CheckIf<T>(this ValueTask<Return<T>> resultTask, bool condition,
            Func<T, ValueTask<Return>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static ValueTask<Return<T>> CheckIf<T, K>(this ValueTask<Return<T>> resultTask, bool condition,
            Func<T, ValueTask<Return<K>>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static ValueTask<Return<T, E>> CheckIf<T, K, E>(this ValueTask<Return<T, E>> resultTask, bool condition,
            Func<T, ValueTask<Return<K, E>>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static ValueTask<Return<T, E>> CheckIf<T, E>(this ValueTask<Return<T, E>> resultTask, bool condition,
            Func<T, ValueTask<UnitResult<E>>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static ValueTask<UnitResult<E>> CheckIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition,
            Func<ValueTask<UnitResult<E>>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static async ValueTask<Return<T>> CheckIf<T>(this ValueTask<Return<T>> resultTask,
            Func<T, bool> predicate, Func<T, ValueTask<Return>> valueTask)
        {
            Return<T> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(valueTask);
            else
                return result;
        }

        public static async ValueTask<Return<T>> CheckIf<T, K>(this ValueTask<Return<T>> resultTask,
            Func<T, bool> predicate, Func<T, ValueTask<Return<K>>> valueTask)
        {
            Return<T> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(valueTask);
            else
                return result;
        }

        public static async ValueTask<Return<T, E>> CheckIf<T, K, E>(this ValueTask<Return<T, E>> resultTask,
            Func<T, bool> predicate, Func<T, ValueTask<Return<K, E>>> valueTask)
        {
            Return<T, E> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(valueTask);
            else
                return result;
        }

        public static async ValueTask<Return<T, E>> CheckIf<T, E>(this ValueTask<Return<T, E>> resultTask,
            Func<T, bool> predicate, Func<T, ValueTask<UnitResult<E>>> valueTask)
        {
            Return<T, E> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(valueTask);
            else
                return result;
        }

        public static async ValueTask<UnitResult<E>> CheckIf<E>(this ValueTask<UnitResult<E>> resultTask,
            Func<bool> predicate, Func<ValueTask<UnitResult<E>>> valueTask)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsSuccess && predicate())
                return await result.Check(valueTask);
            else
                return result;
        }
    }
}
#endif
