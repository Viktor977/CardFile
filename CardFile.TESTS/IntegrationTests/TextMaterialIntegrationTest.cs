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
      
        [Test]
        public async Task TexMaterialController_GetAllAsync_ReturnTextMaterialAll()
        {
            //Arrange
            var expected = ExpectedMaterialDto.ToList();
      
            // Act
            var httpResponse = await _client.GetAsync(RequestUri);

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<TextMaterialDto>>(stringResponse);

           actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task TextMaterialController_SearchByFilterWithTitle_RetutnEntity()
        {
            //Arrange
            var expected = new TextMaterialDto
            {
                Id = 1,
                Allows = Allows.Allowed,
                DatePublish = new DateTime(2020, 12, 21),
                Author = "Doe A.",
                Title = "Test1",
                Article = "some text1",
                Reactions = GetReactionDtoUserIdOne,
            };
          
           
            //Act
            var httpResponce = await _client.GetAsync(RequestUri + "filter?TitleText=Test1");
          

            //Assert
            httpResponce.EnsureSuccessStatusCode();
            var stringReaponce = await httpResponce.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<TextMaterialDto>(stringReaponce);
            actual.Should().BeEquivalentTo(expected);

        }

        [Test]
        public async Task TextMaterialController_GetById_ReturnEntity()
        {
            //Arrange
            var expected = new TextMaterialDto
            {
                Id = 1,
                Allows = Allows.Allowed,
                DatePublish = new DateTime(2020, 12, 21),
                Author = "Doe A.",
                Title = "Test1",
                Article = "some text1",
                Reactions = new List<ReactionDto>() { }
            };


            //Act
            var httpResponce = await _client.GetAsync(RequestUri + 1);
         
            //Assert
            httpResponce.EnsureSuccessStatusCode();
            var stringReaponce = await httpResponce.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<TextMaterialDto>(stringReaponce);
            actual.Should().BeEquivalentTo(expected);

        }

        [Test]
        public async Task ReactionController_Add_AddTextmaterialToDB()
        {
            //Arrange
            var textMaterialDto = new TextMaterialDto
            {
                Id = 4,
                Allows = Allows.Allowed,
                DatePublish = new DateTime(2020, 12, 21),
                Author = "Doe A.",
                Title = "TestNN",
                Article = "some new  text and text",
                Reactions = new List<ReactionDto>() { }
            };
            var content = new StringContent(JsonConvert.SerializeObject(textMaterialDto), Encoding.UTF8, "application/json");

            //Act
            var httpResponse = await _client.PostAsync(RequestUri, content);

            //Assert
            httpResponse.EnsureSuccessStatusCode();
            await CheckTextMaterialIntoDb(textMaterialDto, textMaterialDto.Id, 4);
        }

        [Test]
        public async Task ReactionController_UpDate_UpdateTextMaterialInDB()
        {
            //Arrange
            var textMaterial = new TextMaterialDto
            {
                Id = 2,
                Allows = Allows.Allowed,
                DatePublish = new DateTime(2020, 12, 21),
                Author = "Doe A.",
                Title = "TestNN",
                Article = "some text some text",
              
            };
            var content = new StringContent(JsonConvert.SerializeObject(textMaterial), Encoding.UTF8, "application/json");

            //Act
            var httpResponse = await _client.PutAsync(RequestUri, content);

            //Assert
            httpResponse.EnsureSuccessStatusCode();
            await CheckTextMaterialIntoDb(textMaterial, textMaterial.Id, 3);

        }

        public static readonly List<ReactionDto> GetReactionDtoUserIdOne =
         new List<ReactionDto>(){
                new ReactionDto { Id = 1,TextId=1, Assessment = Assessments.Like, UserId = 1, Comment = "amazing!!!" },
                new ReactionDto { Id = 2,TextId=1, Assessment = Assessments.Like, UserId = 2, Comment = "cool!" },
                new ReactionDto { Id = 3,TextId=1, Assessment = Assessments.Dislike, UserId = 3, Comment = " " },
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
               new TextMaterialDto { Id = 1, Allows = Allows.Allowed, DatePublish = new DateTime(2020, 12, 21), Author = "Doe A." ,Title="Test1",Article="some text1",Reactions=new List<ReactionDto>(){ } },
               new TextMaterialDto { Id = 2, Allows = Allows.Accepted, DatePublish = new DateTime(2020, 12, 22), Author = "Doe B." ,Title="Test2",Article="some text2",Reactions=new List<ReactionDto>(){ } },
               new TextMaterialDto { Id = 3, Allows = Allows.Rejected, DatePublish = new DateTime(2020, 12, 23), Author = "Doe C.", Title = "Test3", Article ="some text3",Reactions=new List<ReactionDto>(){ } },
             
         };

        private async Task CheckTextMaterialIntoDb(TextMaterialDto textMaterialDto, int textId, int expectedLength)
        {
            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<CardFileDBContext>();
                context.Materials.Should().HaveCount(expectedLength);

                var dbReaction = await context.Materials.FindAsync(textId);
                dbReaction.Should().NotBeNull();


                var dbPerson = await context.Materials.FindAsync(textId);
                dbPerson.Should().NotBeNull().And.BeEquivalentTo(textMaterialDto, options => options
                    .Including(x => x.Allows)
                    .Including(x => x.Author)
                    .Including(x => x.DatePublish)
                    .Including(x => x.Article)
                 
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
