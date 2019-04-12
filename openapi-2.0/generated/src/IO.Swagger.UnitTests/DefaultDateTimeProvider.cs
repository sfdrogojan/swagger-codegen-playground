using System;

namespace IO.Swagger.UnitTests
{
    public class DefaultDateTimeProvider : IDatetimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}