using System;
using IO.Swagger.Authenticators;

namespace IO.Swagger.UnitTests
{
    public class SettableDateTimeProvider : IDateTimeProvider
    {
        private DateTime dateTime;

        public SettableDateTimeProvider(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }
        
        public DateTime Now
        {
            get
            {
                return dateTime;
            }
            set { dateTime = value; }
        }
    }
}