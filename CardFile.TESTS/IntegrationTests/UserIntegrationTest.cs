using CardFile.BAL.ModelsDto;
using CardFile.DAL.Data;
using CardFile.DAL.Enums;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.TESTS.IntegrationTests
{
    class UserIntegrationTest
    {
        private CardFileWebApplicationFactory _factory;
        private HttpClient _client;
        private const string RequestUri = "api/User/";

        [SetUp]
        public void Init()
        {
            _factory = new CardFileWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task UserController_GetAllUsers_ReturnsAllFromDb()
        {
            //arrange
            var expected = ExpectedUserDto.ToList();

            // act
            var httpResponse = await _client.GetAsync(RequestUri);

            // assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(stringResponse).ToList();

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task UserController_GetByIdAsync_ReturnEntity()
        {
            //Arrange
            var expected = ExpectedUserDto.First();
            var reactionId = 1;

            // Act
            var httpResponse = await _client.GetAsync(RequestUri + reactionId);

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<UserDto>(stringResponse);

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task UserController_AddUser_AddUserToDB()
        {
            //Arrange
            var user = new UserDto
            {
                Id = 4,
                FirstName = "FNameFour",
                LastName = "LNameFour",
                Role = Roles.Registered,
                Email = "userfour@gmail",
                Password = "@usEr!4"
            };
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            //Act
            var httpResponse = await _client.PostAsync(RequestUri, content);

            //Assert
            httpResponse.EnsureSuccessStatusCode();
            await CheckUserIntoDb(user, user.Id, 4);
        }

        private static readonly IEnumerable<UserDto> ExpectedUserDto =
           new List<UserDto>()
           {
                 new UserDto { Id = 1, FirstName = "FNameOne", LastName = "LNameOne", Role = Roles.Registered , Email = "userOne@gmail", Password = "@usEr!1" },
                 new UserDto { Id = 2, FirstName = "FNameTwo", LastName = "LNameTwo", Role = Roles.Registered, Email = "userTwo@gmail", Password = "@usEr!2" },
                 new UserDto { Id = 3, FirstName = "FNameThree", LastName = "LNameThree", Role = Roles.Registered, Email = "userThree@gmail", Password = "@usEr!3" },
           };

        private async Task CheckUserIntoDb(UserDto user, int userId, int expectedLength)
        {
            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<CardFileDBContext>();
                context.Users.Should().HaveCount(expectedLength);

                var dbUser = await context.Users.FindAsync(userId);
                dbUser.Should().NotBeNull();


                var dbPerson = await context.Users.FindAsync(userId);
                dbPerson.Should().NotBeNull().And.BeEquivalentTo(user, options => options
                    .Including(x => x.FirstName)
                    .Including(x => x.LastName)
                    .Including(x => x.Role)
                    .Including(x => x.Email)
                    .Including(x => x.Password)
                ); 
            }
        }

        [TearDown]
        public void TearDown()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}

