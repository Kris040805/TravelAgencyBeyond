using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business;
using TravelAgency.Data;

namespace TravelAgencyTests
{
    public class Test02
    {
        [TestCase]
        public void GetBusById()
        {
            /*
            var data = new List<Bus>
            {
                new Bus("Volvo", 25, 100_000),
                new Bus("Mercedes", 50, 10_000)
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Bus>>();
            mockSet.As<IQueryable<Bus>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Bus>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Bus>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Bus>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<TravelAgencyContext>();
            mockContext.Setup(c => c.Buses).Returns(mockSet.Object);

            var service = new BusBusiness();
            data.ToList().ForEach(p => service.Add(p));

            var bus = service.Get(1);
            Assert.AreEqual("Volvo", bus.Model);
            */
        }
    }
}
