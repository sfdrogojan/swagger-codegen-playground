using System;
using NSubstitute;
using NUnit.Framework;

namespace IO.Swagger.UnitTests
{
    [TestFixture]
    public class MyCacheServiceTests
    {
        //[Test]
        //public void Get_WhenCacheIsNotExpired_ReturnsTrue()
        //{
        //    IDatetimeProvider datetimeProvider = Substitute.For<IDatetimeProvider>();
        //    datetimeProvider.Now.Returns(DateTime.Now);

        //    MyCacheService cs = new MyCacheService(datetimeProvider);
        //    var result = cs.Get();

        //    Assert.IsTrue(result);
        //}

        [Test]
        public void Get_WhenCacheIsNotExpired_ReturnsFalse()
        {
            var sdtp = new SettableDateTimeProvider();
            MyCacheService cs = new MyCacheService(sdtp);
            cs.Add();

            // simulate time passing .... wwwwaaaa
            sdtp.Now = DateTime.Now.AddMinutes(6);

            var result = cs.Get();

            Assert.IsFalse(result);
        }
    }

    public class SettableDateTimeProvider : IDatetimeProvider
    {
        private DateTime dt;
        public DateTime Now {
            get
            {
                if (dt == DateTime.MinValue)
                {
                    dt = DateTime.Now;
                }
                return dt;
            }
            set { dt = value; }
        }
    }
}