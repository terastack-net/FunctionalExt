using System;

namespace FunctionalReturn
{
    public class ResultFailureException : Exception
    {
        public Exception Error { get; }

        internal ResultFailureException(Exception error)
            : base(Return.Messages.ValueIsInaccessibleForFailure(error))
        {
            Error = error;
        }
    }

    public class ResultFailureException<E> : ResultFailureException
    {
        public new E Error { get; }

        internal ResultFailureException(E error)
            : base( new Exception(error.ToString() ))
        {
            Error = error;
        }
    }
}
