using System;

namespace IO.Swagger.Authenticators
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