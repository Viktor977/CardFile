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
    public class ReactionServiceTest
    {
        [Test]
        public async Task ReactionService_AddReaction_ReturnTrue()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var reactionService = new ReactionService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());
            mockUnitOfWork
              .Setup(x => x.ReactionRepository.GetAllAsync())
              .ReturnsAsync(ReactionEntity.AsEnumerable());
            var reaction = new ReactionDto { Assessment = Assessments.Like,UserId=1};
         
            //Act
           await reactionService.AddAsync(reaction);

            //Assert
            mockUnitOfWork.Verify(x => x.ReactionRepository.AddAsync(It.Is<Reaction>(c => c.TextId == reaction.Id)), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);


        }

        [Test]
        public async Task ReactionService_GetAllAsync_ReturnReactions()
        {
            //arrange
            var expected = ReactionDtoEntity;
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(x => x.ReactionRepository.GetAllAsync())
                .ReturnsAsync(ReactionEntity.AsEnumerable());

            var reactionService = new ReactionService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());

            //act
            var actual = await reactionService.GetAllAsync();

            //assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task ReactionService_UpdateAsync_UpdatesReaction()
        {
            //arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.ReactionRepository.Update(It.IsAny<Reaction>()));

            var receiptService = new ReactionService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());
            var reaction = ReactionDtoEntity.First();

            //act
            await receiptService.UpdateAsync(reaction);

            //assert
            mockUnitOfWork.Verify(x => x.ReactionRepository.Update(It.Is<Reaction>(x => x.Id == reaction.Id)), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task ReactionService_GetByIdAsync_RteurnEntity(int id)
        {

            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.ReactionRepository.GetByIdAsync(id))
                .ReturnsAsync(ReactionEntity
                .FirstOrDefault(t => t.Id == id));

            var reactionService = new ReactionService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());
            var expected = ReactionDtoEntity.FirstOrDefault(t => t.Id == id);

            //Act
            var actual = await reactionService.GetByIdAsync(id);

            //Assert
            actual.Should().BeEquivalentTo(expected);

        }

        public List<Reaction> ReactionEntity =>
        new List<Reaction>()
        {
             new Reaction { Id = 1, TextId = 1, Assessment = Assessments.Like, UserId = 1, Comment = "amazing!!!" },
             new Reaction { Id = 2, TextId = 1, Assessment = Assessments.Like, UserId = 2, Comment = "cool!" },
             new Reaction { Id = 3, TextId = 1, Assessment = Assessments.Dislike, UserId = 3, Comment = " " }
        };
       public List<ReactionDto> ReactionDtoEntity =>
       new List<ReactionDto>()
       {
             new ReactionDto { Id = 1, Assessment = Assessments.Like, UserId = 1, Comment = "amazing!!!" },
             new ReactionDto { Id = 2, Assessment = Assessments.Like, UserId = 2, Comment = "cool!" },
             new ReactionDto { Id = 3,  Assessment = Assessments.Dislike, UserId = 3, Comment = " " }
       };

    }
}
