using System;
using Xunit;
using Moq;
using DMedics.Repository.Repository;
using DMedics.Domain.Entities;

namespace DMedics.Test
{
    public class MainTest
    {
        private Mock<IBaseRepository<Appointment>> mockInvoiceRepo = new Mock<IBaseRepository<Appointment>>();

        [Fact]
        public void TestCase1()
        {
            //arrange

            //act

            //assert
        }

    }
}
