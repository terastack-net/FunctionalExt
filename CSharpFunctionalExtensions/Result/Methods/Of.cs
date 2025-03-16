using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Return
    {
        /// <summary>
        ///     Creates a successful <see cref="Return{T}" /> containing the given value.
        /// </summary>
        public static Return<T> Of<T>(T value) where T : notnull
        {
            return new Return<T>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Return{T}" /> containing the given value from a <see cref="Func{T}" />.
        /// </summary>
        public static Return<T> Of<T>(Func<T> func) where T : notnull
        {
            T value = func();

            return new Return<T>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Return{T}" /> containing the given async value.
        /// </summary>
        public static async Task<Return<T>> Of<T>(Task<T> valueTask) where T : notnull
        {
            T value = await valueTask;

            return new Return<T>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Return{T}" /> containing the given value from an async <see cref="Func{T}" />.
        /// </summary>
        public static async Task<Return<T>> Of<T>(Func<Task<T>> valueTaskFunc) where T : notnull
        {
            T value = await valueTaskFunc();

            return new Return<T>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Return{T}" /> containing the given value.
        /// </summary>
        public static Return<T, E> Of<T, E>(T value) where T : notnull
        {
            return new Return<T, E>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Return{T}" /> containing the given value from a <see cref="Func{T}" />.
        /// </summary>
        public static Return<T, E> Of<T, E>(Func<T> func) where T : notnull
        {
            T value = func();

            return new Return<T, E>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Return{T}" /> containing the given async value.
        /// </summary>
        public static async Task<Return<T, E>> Of<T, E>(Task<T> valueTask) where T : notnull
        {
            T value = await valueTask;

            return new Return<T, E>(false, default, value);
        }

        /// <summary>
        ///     Creates a successful <see cref="Return{T}" /> containing the given value from an async <see cref="Func{T}" />.
        /// </summary>
        public static async Task<Return<T, E>> Of<T, E>(Func<Task<T>> valueTaskFunc) where T : notnull
        {
            T value = await valueTaskFunc();

            return new Return<T, E>(false, default, value);
        }
    }
}
