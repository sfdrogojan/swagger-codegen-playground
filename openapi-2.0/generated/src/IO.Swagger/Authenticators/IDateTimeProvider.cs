using System;

namespace IO.Swagger.Authenticators
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}