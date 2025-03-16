using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static Task<Return<TR>> SelectMany<T, TK, TR>(
            this Return<T> result,
            Func<T, Task<Return<TK>>> func,
            Func<T, TK, TR> project)
        {
            return result
                .Bind(func)
                .Map(x => project(result.Value, x));
        }

        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static Task<Return<TR, TE>> SelectMany<T, TK, TE, TR>(
            this Return<T, TE> result,
            Func<T, Task<Return<TK, TE>>> func,
            Func<T, TK, TR> project)
        {
            return result
                .Bind(func)
                .Map(x => project(result.Value, x));
        }
    }
}