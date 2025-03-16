using System;

namespace CSharpFunctionalExtensions
{
    public class ResultSuccessException : Exception
    {
        internal ResultSuccessException()
            : base(Return.Messages.ErrorIsInaccessibleForSuccess)
        {
        }
    }
}
