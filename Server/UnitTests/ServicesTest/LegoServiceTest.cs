
using DataDomain.Data.NoSql.Models;
using Moq;
using Repositories.RepositoriesMongo.Base;
using Server.Controllers;
using Services.Services.Base;
using Xunit;

namespace UnitTests.ServicesTest
{
    public class LegoServiceTest
    {
        private readonly BaseServiceForMongo<LegoModel> _legoService;
        private readonly MongoDbBase<LegoModel> _repository;
        [Fact]
        public async void GetAllTesting()
        {
           
            // Arrange
            var mockService = new Mock<BaseServiceForMongo<LegoModel>>();
            mockService.Setup(r => r.GetAllAsync().Result).Returns(await _legoService.GetAllAsync());

            var mockRepos = new Mock<MongoDbBase<LegoModel>>();
            mockRepos.Setup(r => r.GetAllAsync().Result).Returns(await _repository.GetAllAsync());

            // Act

            //var result1 = await mockService.Object.GetAllAsync();
            //var result2 = await mockRepos.Object.GetAllAsync();

            var result1 = await _legoService.GetAllAsync();
            var result2 = await _repository.GetAllAsync();
            // Assert
            //Console.WriteLine(result1.Count);
            //Console.WriteLine(result2.Count);
            Assert.Equal(result1.Count , result2.Count);

        }

        public LegoServiceTest(BaseServiceForMongo<LegoModel> legoService, MongoDbBase<LegoModel> repository)
        {
            _legoService = legoService;
            _repository = repository;
        }
    }
}
