using CardFile.BAL.ModelsDto;
using CardFile.DAL.Data;
using CardFile.DAL.Entities;
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
   public class TextMaterialIntegrationTest
    {
        private CardFileWebApplicationFactory _factory;
        private HttpClient _client;
        private const string RequestUri = "api/TextMaterail/";

        [SetUp]
        public void Init()
        {
            _factory = new CardFileWebApplicationFactory();
            _client = _factory.CreateClient();
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task TaexMaterialController_GetByIdAsync_ReturnTextMaterialById(int id)
        {
            //arrange
            var expected = ExpectedMaterialDto.FirstOrDefault(x => x.Id == id);
      
            // act
            var httpResponse = await _client.GetAsync(RequestUri + id);

            // assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<TextMaterialDto>(stringResponse);

            actual.Should().BeEquivalentTo(expected);
        }
        
         public static readonly List<ReactionDto> GetReactionDtoUserIdOne =
         new List<ReactionDto>(){
                new ReactionDto { Id = 1, Assessment = Assessments.Like, UserId = 1, Comment = "amazing!!!" },
                new ReactionDto { Id = 2, Assessment = Assessments.Like, UserId = 2, Comment = "cool!" },
                new ReactionDto { Id = 3, Assessment = Assessments.Dislike, UserId = 3, Comment = " " },
         };
         public static List<ReactionDto> GetReactionDtoUserIdTwo =>
         new List<ReactionDto>(){
                new ReactionDto { Id = 1, Assessment = Assessments.Like, UserId = 1, Comment = "amazing!!!" },
                new ReactionDto { Id = 2, Assessment = Assessments.Like, UserId = 2, Comment = "cool!" },
                new ReactionDto { Id = 3, Assessment = Assessments.Dislike, UserId = 3, Comment = "?" },
         };

         private static readonly List<TextMaterialDto> ExpectedMaterialDto =
         new List<TextMaterialDto>()
         {
               new TextMaterialDto { Id = 1, Allows = Allows.Allowed, DatePublish = new DateTime(2020, 12, 21), Author = "Doe A." ,Title="Test1",Article="some text1",Reactions=new LinkedList<ReactionDto>(){ } },
               new TextMaterialDto { Id = 2, Allows = Allows.Accepted, DatePublish = new DateTime(2020, 12, 22), Author = "Doe B." ,Title="Test2",Article="some text2",Reactions=new LinkedList<ReactionDto>(){ }},
               new TextMaterialDto { Id = 3, Allows = Allows.Rejected, DatePublish = new DateTime(2020, 12, 23), Author = "Doe C.", Title = "Test3", Article ="some text3", Reactions=new LinkedList<ReactionDto>(){ }},
             
         };

        [TearDown]
        public void TearDown()
        {
            _factory.Dispose();
            _client.Dispose();
        }

    }
}
