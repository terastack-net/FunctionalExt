using System;

namespace CSharpFunctionalExtensions
{
    public partial struct Return
    {
        /// <summary>
        ///     Creates a failure result with the given error message.
        /// </summary>
        public static Return Failure(Exception error)
        {
            return new Return(true, error);
        }


        public static Return Failure(string  error)
        {
            return new Return(true, new Exception(error));
        }

        /// <summary>
        ///     Creates a failure result with the given error message.
        /// </summary>
        public static Return<T> Failure<T>(Exception error)
        {
            return new Return<T>(true, error, default);
        }
        
        /// <summary>
        ///     Creates a failure result with the given error message.
        /// </summary>
        public static Return<T> Failure<T>(string error)
        {
            return new Return<T>(true, new Exception(error), default);
        }


        /// <summary>
        ///     Creates a failure result with the given error.
        /// </summary>
        public static Return<T, E> Failure<T, E>(E error)
        {
            return new Return<T, E>(true, error, default);
        }

    }
}
