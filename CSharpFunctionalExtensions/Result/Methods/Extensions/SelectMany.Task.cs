using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async Task<Return<TR>> SelectMany<T, TK, TR>(
            this Task<Return<T>> resultTask,
            Func<T, Task<Return<TK>>> func,
            Func<T, TK, TR> project)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return await result.SelectMany(func, project).DefaultAwait();
        }

        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async Task<Return<TR, TE>> SelectMany<T, TK, TE, TR>(
            this Task<Return<T, TE>> resultTask,
            Func<T, Task<Return<TK, TE>>> func,
            Func<T, TK, TR> project)
        {
            Return<T, TE> result = await resultTask.DefaultAwait();
            return await result.SelectMany(func, project).DefaultAwait();
        }
    }
}