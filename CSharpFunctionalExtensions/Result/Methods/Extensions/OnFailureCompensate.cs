using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Return<T, E> OnFailureCompensate<T, E>(this Return<T, E> result,
            Func<Return<T, E>> func)
        {
            if (result.IsFailure)
                return func();

            return result;
        }
        
        public static Return<T> OnFailureCompensate<T>(this Return<T> result, Func<Return<T>> func)
        {
            if (result.IsFailure)
                return func();

            return result;
        }
        
        public static Return OnFailureCompensate(this Return result, Func<Return> func)
        {
            if (result.IsFailure)
                return func();

            return result;
        }
        
        public static Return<T, E> OnFailureCompensate<T, E>(this Return<T, E> result,
            Func<E, Return<T, E>> func)
        {
            if (result.IsFailure)
                return func(result.Error);

            return result;
        }
        
        public static Return<T> OnFailureCompensate<T>(this Return<T> result, Func<Exception, Return<T>> func)
        {
            if (result.IsFailure)
                return func(result.Error);

            return result;
        }

        public static Return OnFailureCompensate(this Return result, Func<Exception, Return> func)
        {
            if (result.IsFailure)
                return func(result.Error);

            return result;
        }
    }
}
