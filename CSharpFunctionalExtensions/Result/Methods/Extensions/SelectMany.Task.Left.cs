using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async Task<Return<TR>> SelectMany<T, TK, TR>(
            this Task<Return<T>> resultTask,
            Func<T, Return<TK>> func,
            Func<T, TK, TR> project)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.SelectMany(func, project);
        }

        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async Task<Return<TR, TE>> SelectMany<T, TK, TE, TR>(
            this Task<Return<T, TE>> resultTask,
            Func<T, Return<TK, TE>> func,
            Func<T, TK, TR> project)
        {
            Return<T, TE> result = await resultTask.DefaultAwait();
            return result.SelectMany(func, project);
        }
    }
}