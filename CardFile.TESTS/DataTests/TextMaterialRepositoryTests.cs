using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Enums;
using CardFile.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.TESTS.DataTests
{
    [TestFixture]
   public class TextMaterialRepositoryTests
    {
        private  DbContextOptions<CardFileDBContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = UnitTestsHelper.GetUnitTestDbOptions();
        }

        [Test]
        public async Task TextMaterialRepository_AddAsync_AddsValueToDatabase()
        {

            using (var context = new CardFileDBContext(_options))
            {
                //Arrange            
                var textRepository = new TextMaterialRepository(context);
                var material = new TextMaterial { Id = 4 };

                // Act
                await textRepository.AddAsync(material);
                await context.SaveChangesAsync();

                //Assert
                Assert.That(context.Materials.Count(), Is.EqualTo(4), message: "AddAsync method works incorrect");
            }
        }
       
        [TestCase("Test1")]
        [TestCase("Test2")]
        [TestCase("Test3")]
        public async Task TextMaterialRepository_GetByTitleWithDetailsAsync_ReturnText(string title)
        {
          
            using (var context = new CardFileDBContext(_options))
            {
               //Arrange
                var textRepository = new TextMaterialRepository(context);

                //Act
                var actual = await textRepository.GetByTitleWithDetailsAsync(title);
                //Assert

                Assert.That(actual,
                  Is.EqualTo(ExpectedTextMaterial.FirstOrDefault(i => i.Title == title)).Using(new TextMaterialEqualityComparer()), message: " GetByTitleAsync method doesnt't return included entities");
            }
        }
         [Test]
        public async Task TextMaterialRepository_GetByDateWithDetailsAsync_ReturnTextDatePublish()
        {
            using (var context = new CardFileDBContext(_options))
            {
                //Arrange
               
                var textRepository = new TextMaterialRepository(context);
                DateTime date = new DateTime(2020, 12, 21);
                DateTime expected = new DateTime(2020, 12, 21);

                //Act
                var actual = await textRepository.GetByDateWithDetailsAsync(date);

                //Assert

                Assert.AreEqual(expected, actual.DatePublish);
            }
        }
      

        [Test]
        public async Task TextMaterialRepository_Delete_DelitesEntity()
        {
            using (var context = new CardFileDBContext(_options))
            {
                //Arrange
                var textRepository = new TextMaterialRepository(context);
                var textCard = new TextMaterial() { Id = 1, Allows = Allows.Allowed, DatePublish = new DateTime(2020, 12, 21), Author = "Doe A.", Title = "Test1", Article = "some text1" };

                //Act
                 textRepository.Delete(textCard);
                await context.SaveChangesAsync();

                //Assert
                Assert.That(context.Materials.Count(), Is.EqualTo(2), message: "Delete works incorrect");

            }
        }

        [Test]
        public async Task TextMaterialRepository_GetByAuthorWithDetailsAsync_ReturnEntity()
        {
            using (var context = new CardFileDBContext(_options))
            {
                //Arrange
                var textRepository = new TextMaterialRepository(context);
                string author = "Doe A.";

                //Act
                var textMaterial = await textRepository.GetByAuthorWithDetailsAsync(author);
                //Assert
                Assert.That(textMaterial,
               Is.EqualTo(ExpectedTextMaterial.FirstOrDefault(i => i.Id == textMaterial.Id)).Using(new TextMaterialEqualityComparer()), message: "GetByIdWithDetailsAsync method doesnt't return included entities");

                Assert.That(textMaterial,
               Is.EqualTo(ExpectedTextMaterial.FirstOrDefault(i => i.DatePublish == textMaterial.DatePublish)).Using(new TextMaterialEqualityComparer()), message: "GetByIdWithDetailsAsync method doesnt't return included entities");

                Assert.That(textMaterial,
              Is.EqualTo(ExpectedTextMaterial.FirstOrDefault(i => i.Author == textMaterial.Author)).Using(new TextMaterialEqualityComparer()), message: "GetByIdWithDetailsAsync method doesnt't return included entities");

                Assert.That(textMaterial,
               Is.EqualTo(ExpectedTextMaterial.FirstOrDefault(i => i.Title == textMaterial.Title)).Using(new TextMaterialEqualityComparer()), message: "GetByIdWithDetailsAsync method doesnt't return included entities");

                Assert.That(textMaterial,
                Is.EqualTo(ExpectedTextMaterial.FirstOrDefault(i => i.Article == textMaterial.Article)).Using(new TextMaterialEqualityComparer()), message: "GetByIdWithDetailsAsync method doesnt't return included entities");

                Assert.That(textMaterial.Reactions.ToArray()[0],
               Is.EqualTo(ExpectedReaction.First(i => i.TextId == textMaterial.Id)).Using(new ReactionEqualityComparer()), message: "GetByIdWithDetailsAsync method doesnt't return included entities");

                Assert.That(textMaterial.Reactions.ToArray()[0],
               Is.EqualTo(ExpectedReaction.First(i => i.Assessment == textMaterial.Reactions.ToArray()[0].Assessment)).Using(new ReactionEqualityComparer()), message: "GetByIdWithDetailsAsync method doesnt't return included entities");
            }

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task TextMaterialRepository_GetByIdAsync_ReturnEntity(int id)
        {
            using (var context = new CardFileDBContext(_options))
            {
                //Arrange
                var textRepository = new TextMaterialRepository(context);
                //Act
                var textMaterial = await textRepository.GetByIdAsync(id);
                var expected = ExpectedTextMaterial.FirstOrDefault(x => x.Id == id);

                //Assert
                Assert.That(textMaterial, Is.EqualTo(expected).Using(new TextMaterialEqualityComparer()), message: "GetByIdAsync method works incorrect");
               
            }
        }

     
      
        [Test]
        public async Task TextMaterialRepository_Update_UpdateEntity()
        {
            using (var context = new CardFileDBContext(_options))
            {

                //Arrange
                var textRepository = new TextMaterialRepository(context);
                var textMaterial = new TextMaterial { Id = 3, Allows = Allows.Rejected, DatePublish = new DateTime(2020, 12, 24), Author = "Doe C.", Title = "Test3", Article = " new some text3" };

                //Act
                textRepository.Update(textMaterial);
                await context.SaveChangesAsync();
                //Assert
                Assert.That(textMaterial, Is.EqualTo(new TextMaterial
                { Id = 3, Allows = Allows.Rejected, DatePublish = new DateTime(2020, 12, 24), Author = "Doe C.", Title = "Test3", Article = " new some text3" }).Using(new TextMaterialEqualityComparer()), message: "Update method works incorrect");
            }
        }

        IEnumerable<TextMaterial> ExpectedTextMaterial =>
         new[]
         {
             new TextMaterial { Id = 1, Allows = Allows.Allowed, DatePublish = new DateTime(2020, 12, 21), Author = "Doe A." ,Title="Test1",Article="some text1"},
             new TextMaterial { Id = 2, Allows = Allows.Accepted, DatePublish = new DateTime(2020, 12, 22), Author = "Doe B." ,Title="Test2",Article="some text2"},
             new TextMaterial { Id = 3, Allows = Allows.Rejected, DatePublish = new DateTime(2020, 12, 23), Author = "Doe C.", Title = "Test3", Article ="some text3" },
         };
        IEnumerable<Reaction> ExpectedReaction =>
         new[]
         {
             new Reaction { Id = 1,TextId=1, Assessment = Assessments.Like, UserId = 1, Comment = "amazing!!!" },
             new Reaction { Id = 2,TextId=1, Assessment = Assessments.Like, UserId = 2, Comment = "cool!" },
             new Reaction { Id = 3,TextId=1, Assessment = Assessments.Dislike, UserId = 3, Comment = " " },
         };
    }
}
