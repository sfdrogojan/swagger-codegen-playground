using System;

namespace IO.Swagger.UnitTests
{
    public class MyCacheService
    {
        private readonly IDatetimeProvider _datetimeProvider;
        private DateTime expireDateTime;

        public MyCacheService(IDatetimeProvider datetimeProvider)
        {
            _datetimeProvider = datetimeProvider;
        }

        public void Add()
        {
            // expiresIn the response (in seconds) - 5 min * 60 s 
            expireDateTime = _datetimeProvider.Now.AddMinutes(5);
        }

        public bool Get()
        {
            if (expireDateTime > _datetimeProvider.Now)
                return true;

            return false;
        }
    }
}