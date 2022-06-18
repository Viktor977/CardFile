using CardFile.BAL.ModelsDto;
using CardFile.DAL.Enums;
using FluentAssertions;
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
            var expected = ExpectedCustomerModels.ToList();

            // act
            var httpResponse = await _client.GetAsync(RequestUri);

            // assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(stringResponse).ToList();

            actual.Should().BeEquivalentTo(expected);
        }


        private static readonly IEnumerable<UserDto> ExpectedCustomerModels =
           new List<UserDto>()
           {
                 new UserDto { Id = 1, FirstName = "FNameOne", LastName = "LNameOne", Role = Roles.Registered },
                 new UserDto { Id = 2, FirstName = "FNameTwo", LastName = "LNameTwo", Role = Roles.Registered },
                 new UserDto { Id = 3, FirstName = "FNameThree", LastName = "LNameThree", Role = Roles.Registered },
           };

        [TearDown]
        public void TearDown()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}

