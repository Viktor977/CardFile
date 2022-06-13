using CardFile.BAL.ModelsDto;
using CardFile.BAL.Services;
using CardFile.DAL.Entities;
using CardFile.DAL.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.TESTS.BusinessTests
{   
    public class UserProfileServiceTests
    {
        [Test] 
        public async Task UserProfileService_GetAll_ReturnsAllUsers()
        {
            //Arrange
            var expected = GetTestUserProfiliesDto;
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(x => x.UserProfileRepository.GetAllAsync())
                .ReturnsAsync(GetTestUserProfileEntities.AsEnumerable());

            var customerService = new UserProfileService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());

            //Act
            var actual = await customerService.GetAllAsync();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        public List<UserProfileDto> GetTestUserProfiliesDto =>
         new List<UserProfileDto>()
         {
              new UserProfileDto{Id=1,UserId=1,Email="profileOne@gmail",Login="Profil1",Password="1qwerty"},
              new UserProfileDto{Id=2,UserId=2,Email="profileTwo@gmail",Login="Profil2",Password="2qwerty"},
              new UserProfileDto{Id=3,UserId=3,Email="profileThree@gmail",Login="Profil3",Password="3qwerty"},

         };

        public List<UserProfile> GetTestUserProfileEntities =>
          new List<UserProfile>()
          {
              new UserProfile{Id=1,UserId=1,Email="profileOne@gmail",Login="Profil1",Password="1qwerty"},
              new UserProfile{Id=2,UserId=2,Email="profileTwo@gmail",Login="Profil2",Password="2qwerty"},
              new UserProfile{Id=3,UserId=3,Email="profileThree@gmail",Login="Profil3",Password="3qwerty"},
          };
    }
}
