using System;

namespace FunctionalReturn
{
    public class ReturnFailureException : Exception
    {
        public Exception Error { get; }

        internal ReturnFailureException(Exception error)
            : base(Return.Messages.ValueIsInaccessibleForFailure(error))
        {
            Error = error;
        }
    }

    public class ResultFailureException<E> : ReturnFailureException

    {
        public new E Error { get; }

        internal ResultFailureException(E error)
            : base( new Exception(error.ToString() ))
        {
            Error = error;
        }
    }
}
