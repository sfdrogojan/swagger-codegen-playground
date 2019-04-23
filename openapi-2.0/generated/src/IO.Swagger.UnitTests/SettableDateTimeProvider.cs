using System;
using IO.Swagger.Authentication;

namespace IO.Swagger.UnitTests
{
    public class SettableDateTimeProvider : IDateTimeProvider
    {
        public SettableDateTimeProvider(DateTime dateTime)
        {
            this.Now = dateTime;
        }

        public DateTime Now { get; set; }
    }
}