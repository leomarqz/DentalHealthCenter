
using DentalHealthCenter.Core.Domain.Exceptions;
using DentalHealthCenter.Core.Domain.ValueObjects;

namespace DentalHealthCenter.Tests.Domain.ValueObjects
{
    [TestClass]
    public class TimeIntervalTests
    {

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void CreateTimeInterval_WithStartGreaterThanEnd_ShouldThrowBusinessRuleException()
        {
            new TimeInterval(start: DateTime.UtcNow.AddHours(2), end: DateTime.UtcNow);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void CreateTimeInterval_WithStartEqualToEnd_ShouldThrowBusinessRuleException()
        {
            DateTime now = DateTime.UtcNow;
            new TimeInterval(start: now, end: now);
        }

    }
}

