

using System;

namespace DentalHealthCenter.Core.Domain.ValueObjects
{
    public record TimeInterval
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public TimeInterval(DateTime start, DateTime end)
        {
            if (start >= end)
            {
                throw new ArgumentException("Start time must be earlier than end time.");
            }

            Start = start;
            End = end;
        }
    }
}
