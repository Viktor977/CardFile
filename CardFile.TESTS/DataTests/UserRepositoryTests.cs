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

        [Test]
        public async Task UserRepository_Update_UpdatesEntity()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());

            var customerRepository = new UserRepository(context);
            var customer = new User
            {
                Id = 1,
                FirstName = "Benjamin ",
                LastName = "Franklin",
                Role=Roles.Admin
            };

            //Act
            customerRepository.Update(customer);
            await context.SaveChangesAsync();

            //Assert
            Assert.That(customer, Is.EqualTo(new User
            {
                Id = 1,
                FirstName = "Benjamin ",
                LastName = "Franklin",
                Role = Roles.Admin
            }).Using(new UserEqualityComparer()), message: "Update method works incorrect");
        }


        [Test]
        public async Task UserRepository_GetByIdWithDetailsAsync_ReturnsWithIncludedEntities()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var userRepository = new UserRepository(context);

            //Act
            var user = await userRepository.GetByIdWithDetailsAsync(1);
            var expected = ExpectedUserProfile.FirstOrDefault(x => x.Id == 1);

            //Assert
           

            Assert.That(user.Profile,
                Is.EqualTo(ExpectedUserProfile.FirstOrDefault(i => i.Id == expected.Id)).Using(new UserProfileEqualityCompare()), message: "GetByIdWithDetailsAsync method doesnt't return included entities");

            Assert.That(user.Profile,
                Is.EqualTo(ExpectedUserProfile.FirstOrDefault(i => i.UserId == 1)).Using(new UserProfileEqualityCompare()), message: "GetByIdWithDetailsAsync method doesnt't return included entities");

            Assert.That(user.Profile,
               Is.EqualTo(ExpectedUserProfile.FirstOrDefault(i => i.Password == expected.Password)).Using(new UserProfileEqualityCompare()), message: "GetByIdWithDetailsAsync method doesnt't return included entities");

            Assert.That(user.Profile,
               Is.EqualTo(ExpectedUserProfile.FirstOrDefault(i => i.Login == expected.Login)).Using(new UserProfileEqualityCompare()), message: "GetByIdWithDetailsAsync method doesnt't return included entities");
        }

        private static IEnumerable<User> ExpectedUsers =>
          new[]
          {
              new User { Id = 1, FirstName = "FNameOne", LastName = "LNameOne", Role = Roles.Registered },
              new User { Id = 2, FirstName = "FNameTwo", LastName = "LNameTwo", Role = Roles.Registered },
              new User { Id = 3, FirstName = "FNameThree", LastName = "LNameThree", Role = Roles.Registered }

          };

        private static IEnumerable<UserProfile> ExpectedUserProfile =>
          new[] {

              new UserProfile { Id = 1, UserId = 1, Email = "userOne@gmail", Login = "User1", Password = "@usEr!1" },
              new UserProfile { Id = 2, UserId = 2, Email = "userTwo@gmail", Login = "User2", Password = "@usEr!2" },
              new UserProfile { Id = 3, UserId = 3, Email = "userThree@gmail", Login = "User3", Password = "@usEr!3" }
            
          };
    }
}
