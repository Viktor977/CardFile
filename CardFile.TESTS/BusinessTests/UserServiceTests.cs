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
        #endregion
    }
}
