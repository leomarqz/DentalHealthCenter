

using System;

namespace DentalHealthCenter.Core.Application.Exceptions
{
    public class MediatorException : Exception
    {
        public MediatorException(string message) : base(message)
        {
        }
    }
}
