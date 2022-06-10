using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.TESTS.DataTests
{
    [TestFixture]
   public  class HistoryRepositioryTests
    {
        [Test]
        public async Task HistoryRepository_AddAsync_AddsValueToDatabase()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var customerRepository = new HistoryRepository(context);
            var customer = new History { Id = 4 };

            // Act
            await customerRepository.AddAsync(customer);
            await context.SaveChangesAsync();

            //Assert
            Assert.That(context.Histories.Count(), Is.EqualTo(3), message: "AddAsync method works incorrect");
        }
    }
}
