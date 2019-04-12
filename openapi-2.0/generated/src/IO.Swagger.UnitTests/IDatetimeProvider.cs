using System;

namespace IO.Swagger.UnitTests
{
    public interface IDatetimeProvider
    {
        DateTime Now { get; }
    }
}