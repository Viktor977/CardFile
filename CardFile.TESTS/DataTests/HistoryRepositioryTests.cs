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
            var historyRepository = new HistoryRepository(context);
            var history = new History { Id = 4 ,ReaderId=2};

            // Act
            await historyRepository.AddAsync(history);
            await context.SaveChangesAsync();

            //Assert
            Assert.That(context.Histories.Count(), Is.EqualTo(3), message: "AddAsync method works incorrect");
        }

        [Test]
        public async Task HistoryRepository_Update_UpdatesEntity()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());

            var historyRepository = new HistoryRepository(context);
            var customer = new History
            {
                Id = 1,
                LastAction=new DateTime(2020,10,10),
                ReaderId=1,
                TextId=9
               
            };

            //Act
            historyRepository.Update(customer);
            await context.SaveChangesAsync();

            //Assert
            Assert.That(customer, Is.EqualTo(new History
            {
                Id = 1,
                LastAction = new DateTime(2020, 10, 10),
                ReaderId = 1,
                TextId = 9
            }).Using(new HistoryEqualityCompare()), message: "Update method works incorrect");
        }

       
    }
}
