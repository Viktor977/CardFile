using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Enums;
using CardFile.DAL.Repositories;
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
        
        [Test]
        public async Task TextMaterialRepository_AddAsync_AddsValueToDatabase()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var textRepository = new TextMaterialRepository(context);
            var material = new TextMaterial { Id = 4 };

            // Act
            await textRepository.AddAsync(material);
            await context.SaveChangesAsync();

            //Assert
            Assert.That(context.Materials.Count(), Is.EqualTo(4), message: "AddAsync method works incorrect");
        }
       
        [TestCase("Test1")]
        [TestCase("Test2")]
        [TestCase("Test3")]
        public async Task TextMaterialRepository_GetByTitleAsync_ReturnText(string title)
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var textRepository = new TextMaterialRepository(context);

            //Act
            var actual =await textRepository.GetByTitleAsync(title);
            //Assert
         
            Assert.That(actual,
              Is.EqualTo(ExpectedTextMaterial.FirstOrDefault(i => i.Title == title)).Using(new TextMaterialEqualityComparer()), message: " GetByTitleAsync method doesnt't return included entities");
        }
         [Test]
        public async Task TextMaterialRepository_GetByDateWithDetailsAsync_ReturnText()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var textRepository = new TextMaterialRepository(context);
            DateTime date = new DateTime(2020, 12, 21);
            DateTime expected = new DateTime(2020, 12, 21);

            //Act
            var actual = await textRepository.GetByDateWithDetailsAsync(date);

            //Assert

            Assert.AreEqual(expected, actual.DatePublish);

        }

        IEnumerable<TextMaterial> ExpectedTextMaterial =>
            new[]
            {
             new TextMaterial { Id = 1, Allows = Allows.Allowed, DatePublish = new DateTime(2020, 12, 21), Author = "Doe A." ,Title="Test1",Article="some text1"},
             new TextMaterial { Id = 2, Allows = Allows.Accepted, DatePublish = new DateTime(2020, 12, 22), Author = "Doe B." ,Title="Test2",Article="some text2"},
             new TextMaterial { Id = 3, Allows = Allows.Rejected, DatePublish = new DateTime(2020, 12, 23), Author = "Doe C.", Title = "Test3", Article ="some text3" },
            };
    }
}
