using System;

namespace FunctionalReturn
{
    public interface IReturn
    {
        bool IsFailure { get; }
        bool IsSuccess { get; }
    }

    public interface IValue<out T>
    {
        T Value { get; }
    }

    public interface IError<out E>
    {
        E Error { get; }
    }

    public interface IReturn<out T, out E> : IValue<T>, IUnitReturn<E>
    {
    }

    public interface IReturn<out T> : IReturn<T, Exception>
    {
    }

    public interface IUnitReturn<out E> : IReturn, IError<E>
    {
    }
}
