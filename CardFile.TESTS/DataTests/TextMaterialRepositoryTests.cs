using CardFile.DAL.Data;
using CardFile.DAL.Entities;
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
    }
}
