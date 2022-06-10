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
            var userRepository = new UserRepository(context);
            var user = new User { Id = 4 };

            // Act
            await userRepository.AddAsync(user);
            await context.SaveChangesAsync();

            //Assert
            Assert.That(context.Users.Count(), Is.EqualTo(4), message: "AddAsync method works incorrect");
        }
        [Test]
        public async Task UserRepository_GetAllAsync_ReturnsAllValues()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var userRepository = new UserRepository(context);

            //Act
            var user = await userRepository.GetAllAsync();

            //Assert
            Assert.That(user, Is.EqualTo(ExpectedUsers).Using(new UserEqualityComparer()), message: "GetAllAsync method works incorrect");
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task UserRepository_GetByIdAsync_ReturnsSingleValue(int id)
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var userRepository = new UserRepository(context);

            //Act
            var user = await userRepository.GetByIdAsync(id);
            var expected = ExpectedUsers.FirstOrDefault(x => x.Id == id);

            //Assert
            Assert.That(user, Is.EqualTo(expected).Using(new UserEqualityComparer()), message: "GetByIdAsync method works incorrect");
        }

        [Test]
        public async Task UserRepository_DeleteByIdAsync_DeletesEntity()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var userRepository = new UserRepository(context);

            //Act
            await userRepository.DeleteByIdAsync(1);
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
