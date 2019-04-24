using System;

namespace IO.Swagger.Authentication
{
    internal interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}