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
    public class ReactionIntegratonTest
    {
        private CardFileWebApplicationFactory _factory;
        private HttpClient _client;
        private  string RequestUri = "api/Reaction";
        
        [SetUp]
        public void Init()
        {
            _factory = new CardFileWebApplicationFactory();
            _client = _factory.CreateClient();
        }
       
        [Test]
        public async Task ReactionController_Add_AddReactionToDB()
        {
            //Arrange
            var reaction = new ReactionDto
            {
                Id=4,
                TextId = 1,
                Assessment = Assessments.Like,
                UserId = 4,
                Comment = "good!!!"
            };
            var content = new StringContent(JsonConvert.SerializeObject(reaction), Encoding.UTF8, "application/json");

            //Act
            var httpResponse = await _client.PostAsync(RequestUri,content);

            //Assert
            httpResponse.EnsureSuccessStatusCode();        
            await CheckReactionIntoDb(reaction,reaction.Id, 4);
        }

        [Test]
        public async Task ReactionController_GetAllAsync_ReturnAllFromDB()
        {
            //Arrange
            var expected = GetReactionDtoUserIdOne.ToList();

            // Act
            var httpResponse = await _client.GetAsync(RequestUri);

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<ReactionDto>>(stringResponse);

            actual.Should().BeEquivalentTo(expected);

        }
        [Test]
        public async Task ReactionController_GetByIdAsync_ReturnEntityById()
        {
            //Arrange
            var expected = GetReactionDtoUserIdOne.First();
            var reactionId = 1;

            // Act
            var httpResponse = await _client.GetAsync(RequestUri +"/"+ reactionId);

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<ReactionDto>(stringResponse);

            actual.Should().BeEquivalentTo(expected);
        }

       
        [Test]
        public async Task ReactionController_UpDate_UpdateReactionInDB()
        {
            //Arrange
            var reaction = new ReactionDto
            {
                Id = 1,
                TextId = 1,
                Assessment = Assessments.Like,
                UserId = 1,
                Comment = "good!!!"
            };
            var content = new StringContent(JsonConvert.SerializeObject(reaction), Encoding.UTF8, "application/json");

            //Act
            var httpResponse = await _client.PutAsync(RequestUri,content);

            //Assert
            httpResponse.EnsureSuccessStatusCode();       
            await CheckReactionIntoDb(reaction, reaction.Id, 3);

        }

        public static readonly List<ReactionDto> GetReactionDtoUserIdOne =
        new List<ReactionDto>(){
                new ReactionDto { Id = 1,TextId=1, Assessment = Assessments.Like, UserId = 1, Comment = "amazing!!!" },
                new ReactionDto { Id = 2,TextId=1, Assessment = Assessments.Like, UserId = 2, Comment = "cool!" },
                new ReactionDto { Id = 3,TextId=1, Assessment = Assessments.Dislike, UserId = 3, Comment = " " },
        };
        private async Task CheckReactionIntoDb(ReactionDto reaction, int reactionId, int expectedLength)
        {
            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<CardFileDBContext>();
                context.Reactions.Should().HaveCount(expectedLength);

                var dbReaction = await context.Reactions.FindAsync(reactionId);
                dbReaction.Should().NotBeNull();
              

                var dbPerson = await context.Reactions.FindAsync(reactionId);
                dbPerson.Should().NotBeNull().And.BeEquivalentTo(reaction, options => options
                    .Including(x => x.Assessment)
                    .Including(x => x.Comment)
                    .Including(x => x.TextId)
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
