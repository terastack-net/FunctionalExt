#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
   public static partial class AsyncResultExtensionsLeftOperand
    {
        public static ValueTask<Return<T>> CheckIf<T>(this ValueTask<Return<T>> resultTask, bool condition, Func<T, Return> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static ValueTask<Return<T>> CheckIf<T, K>(this ValueTask<Return<T>> resultTask, bool condition, Func<T, Return<K>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static ValueTask<Return<T, E>> CheckIf<T, K, E>(this ValueTask<Return<T, E>> resultTask, bool condition, Func<T, Return<K, E>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static ValueTask<Return<T, E>> CheckIf<T, E>(this ValueTask<Return<T, E>> resultTask, bool condition, Func<T, UnitReturn<E>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static ValueTask<UnitReturn<E>> CheckIf<E>(this ValueTask<UnitReturn<E>> resultTask, bool condition, Func<UnitReturn<E>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static async ValueTask<Return<T>> CheckIf<T>(this ValueTask<Return<T>> resultTask, Func<T, bool> predicate, Func<T, Return> valueTask)
        {
            Return<T> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(valueTask);
            else
                return result;
        }

        public static async ValueTask<Return<T>> CheckIf<T, K>(this ValueTask<Return<T>> resultTask, Func<T, bool> predicate, Func<T, Return<K>> valueTask)
        {
            Return<T> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(valueTask);
            else
                return result;
        }

        public static async ValueTask<Return<T, E>> CheckIf<T, K, E>(this ValueTask<Return<T, E>> resultTask, Func<T, bool> predicate, Func<T, Return<K, E>> valueTask)
        {
            Return<T, E> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(valueTask);
            else
                return result;
        }

        public static async ValueTask<Return<T, E>> CheckIf<T, E>(this ValueTask<Return<T, E>> resultTask, Func<T, bool> predicate, Func<T, UnitReturn<E>> valueTask)
        {
            Return<T, E> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(valueTask);
            else
                return result;
        }

        public static async ValueTask<UnitReturn<E>> CheckIf<E>(this ValueTask<UnitReturn<E>> resultTask, Func<bool> predicate, Func<UnitReturn<E>> valueTask)
        {
            UnitReturn<E> result = await resultTask;

            if (result.IsSuccess && predicate())
                return result.Check(valueTask);
            else
                return result;
        }
    }
}
#endif