using DataDomain.Data.NoSql.Models;
using DataDomain.Data.Sql.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Server.Controllers;
using Server.DTO;
using Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ServerTest.Controllers
{
    public class DraftBasketControllerTest
    {
        private readonly BasketController basketController;
        private readonly Mock<BaseServiceForMongo<BasketModel>> _basketServiceMock;
        private readonly Mock<IUserService> _userServiceMock;

        public DraftBasketControllerTest()
        {
            _userServiceMock = new Mock<IUserService>();
            _basketServiceMock = new Mock<BaseServiceForMongo<BasketModel>>();
            basketController = new BasketController(_basketServiceMock.Object, _userServiceMock.Object);
        }

        [Fact]
        public async void ShouldAddBasketAsyncIfUserExistTest()
        {
            //Arrange
            var userModel = new UserModel() { Email = "correct@mail.com" };
            _userServiceMock.Setup(us => us.FindByEmailAsync("correct@mail.com")).Returns(Task.FromResult(userModel));
            var basketModel = new BasketModel() { Amount = 5, Lego = new LegoModel(), User = userModel };
            _basketServiceMock.Setup(bs => bs.AddAsync(It.Is<BasketModel>(bm => bm.Amount == 5 && bm.User.Email == "correct@mail.com"))).Returns(Task.FromResult(basketModel));

            //Act
            var result = await basketController.AddBasketAsync(new BasketModelDTO() { userEmail = "correct@mail.com", amount = 5 });

            //Assert
            var okResult = Assert.IsType<OkResult>(result);
        }
    }
}
