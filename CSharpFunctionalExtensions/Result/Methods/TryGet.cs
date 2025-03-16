#if NET45_OR_GREATER || NETSTANDARD || NETCORE || NET5_0_OR_GREATER
using System;
using System.Runtime.CompilerServices;
#endif
#if NET5_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace FunctionalReturn
{
    partial struct Return
    {
#if NET45_OR_GREATER || NETSTANDARD || NETCORE || NET5_0_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetError(
#if NET5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out Exception error)
        {
            error = _error;
            return IsFailure;
        }
    }

    partial struct Return<T>
    {
#if NET45_OR_GREATER || NETSTANDARD || NETCORE || NET5_0_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetValue(
#if NET5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out T value)
        {
            value = _value;
            return IsSuccess;
        }

#if NET45_OR_GREATER || NETSTANDARD || NETCORE || NET5_0_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetError(
#if NET5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out Exception error)
        {
            error = _error;
            return IsFailure;
        }

#if NET45_OR_GREATER || NETSTANDARD || NETCORE || NET5_0_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetValue(
#if NET5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out T value,
#if NET5_0_OR_GREATER
            [NotNullWhen(false), MaybeNullWhen(true)]
#endif
            out Exception error
            )
        {
            value = _value;
            error = _error;
            return IsSuccess;
        }

#if NET45_OR_GREATER || NETSTANDARD || NETCORE || NET5_0_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetError(
#if NET5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out Exception error,
#if NET5_0_OR_GREATER
            [NotNullWhen(false), MaybeNullWhen(true)]
#endif
            out T value
            )
        {
            value = _value;
            error = _error;
            return IsFailure;
        }
    }

    partial struct Return<T, E>
    {

#if NET45_OR_GREATER || NETSTANDARD || NETCORE || NET5_0_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetValue(
#if NET5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out T value)
        {
            value = _value;
            return IsSuccess;
        }

#if NET45_OR_GREATER || NETSTANDARD || NETCORE || NET5_0_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetError(
#if NET5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out E error)
        {
            error = _error;
            return IsFailure;
        }

#if NET45_OR_GREATER || NETSTANDARD || NETCORE || NET5_0_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetValue(
#if NET5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out T value,
#if NET5_0_OR_GREATER
            [NotNullWhen(false), MaybeNullWhen(true)]
#endif
            out E error
        )
        {
            value = _value;
            error = _error;
            return IsSuccess;
        }

#if NET45_OR_GREATER || NETSTANDARD || NETCORE || NET5_0_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetError(
#if NET5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out E error,
#if NET5_0_OR_GREATER
            [NotNullWhen(false), MaybeNullWhen(true)]
#endif
            out T value
        )
        {
            value = _value;
            error = _error;
            return IsFailure;
        }
    }

    partial struct UnitReturn<E>
    {
#if NET45_OR_GREATER || NETSTANDARD || NETCORE || NET5_0_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetError(
#if NET5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out E error)
        {
            error = _error;
            return IsFailure;
        }
    }
}
