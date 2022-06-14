using CardFile.DAL.Data;
using CardFile.DAL.Entities;
using CardFile.DAL.Repositories;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace CardFile.TESTS.DataTests
{
    [TestFixture]
   public class UserProfileRepositoryTests
    {

        [Test]
        public async Task UserProfileRepository_AddAsync_AddsValueToDatabase()
        {
            //Arrange
            using var context = new CardFileDBContext(UnitTestsHelper.GetUnitTestDbOptions());
            var profileRepository = new UserProfileRepository(context);
            var profile = new UserProfile { Id = 4 };

            // Act
            await profileRepository.AddAsync(profile);
            await context.SaveChangesAsync();

            //Assert
            Assert.That(context.UserProfiles.Count(), Is.EqualTo(4), message: "AddAsync method works incorrect");
        }
    }
}
