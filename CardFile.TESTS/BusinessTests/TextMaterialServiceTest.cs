using CardFile.BAL.ModelsDto;
using CardFile.BAL.Services;
using CardFile.DAL.Entities;
using CardFile.DAL.Enums;
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
    public class TextMaterialServiceTest
    {
        [Test]
        public async Task TextMaterialService_GetAll_ReturnsAllEntity()
        {
            //Arrange
            var expected = GetTestTextMaterialDto;
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(x => x.TextMaterialRepository.GetAllAsync())
                .ReturnsAsync(GetTestTextMaterialEntities.AsEnumerable());

            var textMaterialService = new TextMaterialService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());

            //Act
            var actual = await textMaterialService.GetAllAsync();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task TextMaterialService_AddAsync_ReturEntity()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.TextMaterialRepository.AddAsync(It.IsAny<TextMaterial>()));

            var textMaterialService = new TextMaterialService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());
            var text = GetTestTextMaterialDto.First();

            //Act
            await textMaterialService.AddAsync(text);

            //Assert
            mockUnitOfWork.Verify(x => x.TextMaterialRepository.AddAsync(It.Is<TextMaterial>(c => c.Id == text.Id)), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);

        }

        [Test]
        public async Task  TextMaterialService_UpDate_ReturnTextUpdated()
        {
            //Arrange
            var expected = new TextMaterialDto
            {
                Id = 1,
                Allows = Allows.Allowed,
                DatePublish = new DateTime(2020, 12, 21),
                Author = "Doe A.",
                Title = "Test1",
                Article = "some text1 and added new text",
            };
              
            var text = GetTestTextMaterialEntities.First();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(x => x.TextMaterialRepository.Update(text));
                
            var textMaterialService = new TextMaterialService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());

            //Act
            await textMaterialService.UpdateAsync(expected);
               
            //Assert
                mockUnitOfWork.Verify(x => x.TextMaterialRepository.Update(It.Is<TextMaterial>(x=> x.Id == text.Id)), Times.Once);
                mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
            
        }

        [TestCase("Test1")]
        [TestCase("Test2")]
        public async Task TextMaterialService_SearchByFilter(string searchTitle)
        {
            //Arrange
            var seacher = new FilterSearchDto();
            seacher.TitleText = searchTitle;
            var expected = GetTestTextMaterialDto.FirstOrDefault(t => t.Title == searchTitle);
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(x => x.TextMaterialRepository.GetByTitleWithDetailsAsync(seacher.TitleText))
                .ReturnsAsync(GetTestTextMaterialEntities.FirstOrDefault(t=>t.Title==seacher.TitleText));

            var textMaterialService = new TextMaterialService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());

            //Act
            var actual = await textMaterialService.SearchByFilter(seacher);

            ///Assert
            actual.Should().BeEquivalentTo(expected);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task TextMaterialService_GetByIdAsync_RteurnEntity(int id)
        {
            
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.TextMaterialRepository.GetByIdAsync(id))
                .ReturnsAsync(GetTestTextMaterialEntities.FirstOrDefault(t=>t.Id==id));

            var textMaterialService = new TextMaterialService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());
            var expected = GetTestTextMaterialDto.FirstOrDefault(t => t.Id == id);

            //Act
            var actual=await textMaterialService.GetByIdAsync(id);

            //Assert
            actual.Should().BeEquivalentTo(expected);

        }

        #region TestData
        public List<TextMaterialDto> GetTestTextMaterialDto =>
        new List<TextMaterialDto>()
        {
             new TextMaterialDto { Id = 1, Allows = Allows.Allowed, DatePublish = new DateTime(2020, 12, 21), Author = "Doe A." ,Title="Test1",Article="some text1",Reactions=GetReactionDto},
             new TextMaterialDto { Id = 2, Allows = Allows.Accepted, DatePublish = new DateTime(2020, 12, 22), Author = "Doe B." ,Title="Test2",Article="some text2",Reactions=GetReactionDto},
             new TextMaterialDto { Id = 3, Allows = Allows.Rejected, DatePublish = new DateTime(2020, 12, 23), Author = "Doe C.", Title = "Test3", Article ="some text3",Reactions=GetReactionDto },

        };

        public List<TextMaterial> GetTestTextMaterialEntities =>
          new List<TextMaterial>()
          {
              new TextMaterial { Id = 1, Allows = Allows.Allowed, DatePublish = new DateTime(2020, 12, 21), Author = "Doe A." ,Title="Test1",Article="some text1",Reactions=GetReactionsEntity},
              new TextMaterial { Id = 2, Allows = Allows.Accepted, DatePublish = new DateTime(2020, 12, 22), Author = "Doe B." ,Title="Test2",Article="some text2",Reactions=GetReactionsEntity},
              new TextMaterial { Id = 3, Allows = Allows.Rejected, DatePublish = new DateTime(2020, 12, 23), Author = "Doe C.", Title = "Test3", Article ="some text3",Reactions=GetReactionsEntity },
          };

        public List<ReactionDto> GetReactionDto =>
           new List<ReactionDto>(){
                new ReactionDto { Id = 1, Assessment = Assessments.Like, UserId = 1, Comment = "amazing!!!" },
                new ReactionDto { Id = 2, Assessment = Assessments.Like, UserId = 2, Comment = "cool!" },
                new ReactionDto { Id = 3, Assessment = Assessments.Dislike, UserId = 3, Comment = " " },
           };
        public List<Reaction> GetReactionsEntity =>
            new List<Reaction>(){
                new Reaction { Id = 1, TextId = 1, Assessment = Assessments.Like, UserId = 1, Comment = "amazing!!!" },
                new Reaction { Id = 2, TextId = 1, Assessment = Assessments.Like, UserId = 2, Comment = "cool!" },
                new Reaction { Id = 3, TextId = 1, Assessment = Assessments.Dislike, UserId = 3, Comment = " " },
            };
        public List<UserDto> GetTestUserDto =>
          new List<UserDto>()
          {
                 new UserDto { Id = 1, FirstName = "FNameOne", LastName = "LNameOne", Role = Roles.Registered, Email="profileOne@gmail",Password="1qwerty"},
                 new UserDto { Id = 2, FirstName = "FNameTwo", LastName = "LNameTwo", Role = Roles.Registered ,Email="profileTwo@gmail",Password="2qwerty"},
                 new UserDto { Id = 3, FirstName = "FNameThree", LastName = "LNameThree", Role = Roles.Registered,Email="profileThree@gmail",Password="3qwerty" }

          };

        public List<User> GetTestUserEntities =>
           new List<User>()
           {
                 new User { Id = 1, FirstName = "FNameOne", LastName = "LNameOne", Role = Roles.Registered ,Email="profileOne@gmail",Password="1qwerty"},
                 new User { Id = 2, FirstName = "FNameTwo", LastName = "LNameTwo", Role = Roles.Registered ,Email="profileTwo@gmail",Password="2qwerty"},
                 new User { Id = 3, FirstName = "FNameThree", LastName = "LNameThree", Role = Roles.Registered ,Email="profileThree@gmail",Password="3qwerty"}
           };
        #endregion
    }
}
