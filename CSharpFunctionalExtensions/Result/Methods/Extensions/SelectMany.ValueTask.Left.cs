#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async ValueTask<Return<TR>> SelectMany<T, TK, TR>(
            this ValueTask<Return<T>> resultTask,
            Func<T, Return<TK>> valueTask,
            Func<T, TK, TR> project)
        {
            Return<T> result = await resultTask;
            return result.SelectMany(valueTask, project);
        }

        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async ValueTask<Return<TR, TE>> SelectMany<T, TK, TE, TR>(
            this ValueTask<Return<T, TE>> resultTask,
            Func<T, Return<TK, TE>> valueTask,
            Func<T, TK, TR> project)
        {
            Return<T, TE> result = await resultTask;
            return result.SelectMany(valueTask, project);
        }
    }
}
#endif