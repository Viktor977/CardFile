using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Enums;
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
    public class UserRepositoryTests
    {
        [Test]
        public async Task UserRepository_AddAsync_AddsValueToDatabase()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var customerRepository = new UserRepository(context);
            var customer = new User { Id = 4 };

            // Act
            await customerRepository.AddAsync(customer);
            await context.SaveChangesAsync();

            //Assert
            Assert.That(context.Users.Count(), Is.EqualTo(4), message: "AddAsync method works incorrect");
        }
        [Test]
        public async Task UserRepository_GetAllAsync_ReturnsAllValues()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var customerRepository = new UserRepository(context);

            //Act
            var customers = await customerRepository.GetAllAsync();

            //Assert
            Assert.That(customers, Is.EqualTo(ExpectedUsers).Using(new UserEqualityComparer()), message: "GetAllAsync method works incorrect");
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task UserRepository_GetByIdAsync_ReturnsSingleValue(int id)
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var customerRepository = new UserRepository(context);

            //Act
            var customer = await customerRepository.GetByIdAsync(id);
            var expected = ExpectedUsers.FirstOrDefault(x => x.Id == id);

            //Assert
            Assert.That(customer, Is.EqualTo(expected).Using(new UserEqualityComparer()), message: "GetByIdAsync method works incorrect");
        }

        [Test]
        public async Task UserRepository_DeleteByIdAsync_DeletesEntity()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var customerRepository = new UserRepository(context);

            //Act
            await customerRepository.DeleteByIdAsync(1);
            await context.SaveChangesAsync();

            //Assert
            Assert.That(context.Users.Count(), Is.EqualTo(2), message: "DeleteByIdAsync works incorrect");
        }


        private static IEnumerable<User> ExpectedUsers =>
          new[]
          {
              new User { Id = 1, FirstName = "FNameOne", LastName = "LNameOne", Role = Roles.Registered },
              new User { Id = 2, FirstName = "FNameTwo", LastName = "LNameTwo", Role = Roles.Registered },
              new User { Id = 3, FirstName = "FNameThree", LastName = "LNameThree", Role = Roles.Registered }

          };
    }
}
