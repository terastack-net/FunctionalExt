using System;

namespace FunctionalReturn
{
    public class ResultSuccessException : Exception
    {
        internal ResultSuccessException()
            : base(Return.Messages.ErrorIsInaccessibleForSuccess)
        {
        }
    }
}
