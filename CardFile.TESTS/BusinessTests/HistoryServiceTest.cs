using CardFile.BAL.ModelsDto;
using CardFile.BAL.Services;
using CardFile.DAL.Entities;
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
    public class HistoryServiceTest
    {
        [Test]
        public async Task HistoryService_GetAll_ReturnsAllEntity()
        {
            //Arrange
            var expected = HistoryDtoEntity;
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(x => x.HistoryRepository.GetAllAsync())
                .ReturnsAsync(HistoryEntity.AsEnumerable());

            var historyService = new HistoryService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());

            //Act
            var actual = await historyService.GetAllAsync();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task HistoryService_AddAsync_ReturEntity()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.HistoryRepository.AddAsync(It.IsAny<History>()));

            var historyService = new HistoryService(mockUnitOfWork.Object, UnitTestsHelper.CreateMapperProfile());
            var history = HistoryDtoEntity.First();

            //Act
            await historyService.AddAsync(history);

            //Assert
            mockUnitOfWork.Verify(x => x.HistoryRepository.AddAsync(It.Is<History>(c => c.Id == history.Id)), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveAsync(), Times.Once);

        }



        public List<History>HistoryEntity=>
           new List<History>()
           {
                 new History { Id = 1, ReaderId = 1, TextId = 1, LastAction = new DateTime(2022, 02, 20) },
                 new History { Id = 2, ReaderId = 2, TextId = 2, LastAction = new DateTime(2022, 02, 21) }
            };
        public List<HistoryDto> HistoryDtoEntity =>
          new List<HistoryDto>()
          {
                 new HistoryDto { Id = 1, ReaderId = 1, TextId = 1, LastAction = new DateTime(2022, 02, 20) },
                 new HistoryDto { Id = 2, ReaderId = 2, TextId = 2, LastAction = new DateTime(2022, 02, 21) }
           };

    }
}
