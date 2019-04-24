using System;

namespace IO.Swagger.Authentication
{
    internal class DefaultDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}