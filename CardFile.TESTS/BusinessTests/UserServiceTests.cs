using CardFile.BAL.ModelsDto;
using CardFile.BAL.Services;
using CardFile.DAL.Entities;
using CardFile.DAL.Enums;
using CardFile.DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using System.Threading.Tasks;

namespace CardFile.TESTS.BusinessTests
{
    public class UserServiceTests
    {
        [Test]
        public async Task UserService_GetAll_ReturnsAllUsers()
        {
            //Arrange
            var expected = GetTestUserDto;
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(x => x.UserRepositiory.GetAllAsync())
                .ReturnsAsync(GetTestUserEntities.AsEnumerable());

            var customerService = new UserService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());

            //Act
            var actual = await customerService.GetAllAsync();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task UserService_GetByIdWithDetailsAsync_ReturnsUserDto(int id)
        {
            //arrange
            var expected = GetEntityExpected.FirstOrDefault(x => x.Id == id);
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(m => m.UserRepositiory.GetByIdWithDetailsAsync(It.IsAny<int>()))
                .ReturnsAsync(GetEntity.FirstOrDefault(x => x.Id == id));

            var userService = new UserService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());

            //act
            var actual = await userService.GetByIdWithDetailsAsync(1);

            //assert
            actual.Should().BeEquivalentTo(expected);
        }
        [Test]
        public async Task UserService_CheckUser_ReturnFalse()
        {
            //arrange
            var expected = GetEntityExpected.FirstOrDefault(x => x.Id == 1);
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(m => m.UserRepositiory.ChekUser(It.IsAny<User>()));
                
              

            var userService = new UserService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());


            var userDto = new UserDto
            {
                Id = 1,
                FirstName = "FNameOne",
                LastName = "LNameOne",
                Role = Roles.Registered,
                UserProfileDto = new UserProfileDto { Id = 1, UserId = 1, Email = "userOne@gmail", Login = "User1", Password = "@usEr!1" }
            };

            //Act

            var actual = await userService.CheckUser(userDto);

            //Assert
            Assert.IsTrue(!actual, message:"Method CheckUser work incorrect!");
        }

        #region TestData
        public List<UserDto> GetTestUserDto =>
           new List<UserDto>()
           {
                 new UserDto { Id = 1, FirstName = "FNameOne", LastName = "LNameOne", Role = Roles.Registered },
                 new UserDto { Id = 2, FirstName = "FNameTwo", LastName = "LNameTwo", Role = Roles.Registered },
                 new UserDto { Id = 3, FirstName = "FNameThree", LastName = "LNameThree", Role = Roles.Registered }

           };

        public List<User> GetTestUserEntities =>
           new List<User>()
           {
                 new User { Id = 1, FirstName = "FNameOne", LastName = "LNameOne", Role = Roles.Registered },
                 new User { Id = 2, FirstName = "FNameTwo", LastName = "LNameTwo", Role = Roles.Registered },
                 new User { Id = 3, FirstName = "FNameThree", LastName = "LNameThree", Role = Roles.Registered }
           };
        public List<UserProfileDto> GetTestUserProfileDto =>
          new List<UserProfileDto>()
          {
                new UserProfileDto { Id = 1, UserId = 1, Email = "userOne@gmail", Login = "User1", Password = "@usEr!1" },
                new UserProfileDto { Id = 2, UserId = 2, Email = "userTwo@gmail", Login = "User2", Password = "@usEr!2" },
                new UserProfileDto { Id = 3, UserId = 3, Email = "userThree@gmail", Login = "User3", Password = "@usEr!3" }

          };

        public List<UserProfileDto> GetEntityUserProfileDto =>
          new List<UserProfileDto>()
          {
                new UserProfileDto { Id = 1, UserId = 1, Email = "userOne@gmail", Login = "User1", Password = "@usEr!1" },
                new UserProfileDto { Id = 2, UserId = 2, Email = "userTwo@gmail", Login = "User2", Password = "@usEr!2" },
                new UserProfileDto { Id = 3, UserId = 3, Email = "userThree@gmail", Login = "User3", Password = "@usEr!3" }
          };

        public List<UserDto> GetEntityExpected =>
           new List<UserDto>()
           {
               new UserDto{
               Id = 1,
               FirstName = "FNameOne",
               LastName = "LNameOne",
               Role = Roles.Registered,
               UserProfileDto=new UserProfileDto{Id = 1, UserId = 1, Email = "userOne@gmail", Login = "User1", Password = "@usEr!1"}
               },

                 new UserDto { Id = 2, FirstName = "FNameTwo", LastName = "LNameTwo", Role = Roles.Admin ,
                 UserProfileDto= new UserProfileDto { Id = 2, UserId = 2, Email = "userTwo@gmail", Login = "User2", Password = "@usEr!2" },
                 },

           };
        public List<User> GetEntity =>
          new List<User>()
          {
               new User{
               Id = 1,
               FirstName = "FNameOne",
               LastName = "LNameOne",
               Role = Roles.Registered,
               Profile=new UserProfile{Id = 1, UserId = 1, Email = "userOne@gmail", Login = "User1", Password = "@usEr!1"}
               },

                new User { Id = 2, FirstName = "FNameTwo", LastName = "LNameTwo", Role = Roles.Admin ,
                Profile= new UserProfile { Id = 2, UserId = 2, Email = "userTwo@gmail", Login = "User2", Password = "@usEr!2" },
                },

          };
        #endregion
    }
}
