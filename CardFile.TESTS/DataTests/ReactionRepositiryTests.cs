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
   public class ReactionRepositiryTests
    {
        [Test]
        public async Task ReactionRepository_AddAsync_AddsValueToDatabase()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var reactionRepository = new ReactionRepository(context);
            var reaction = new Reaction { Id = 4 };

            // Act
            await reactionRepository.AddAsync(reaction);
            await context.SaveChangesAsync();

            //Assert
            Assert.That(context.Reactions.Count(), Is.EqualTo(4), message: "AddAsync method works incorrect");
        }

    }
}
