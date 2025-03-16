using System;

namespace FunctionalReturn
{
    public class ReturnSuccessException : Exception
    {
        internal ReturnSuccessException()
            : base(Return.Messages.ErrorIsInaccessibleForSuccess)
        {
        }
    }
}
