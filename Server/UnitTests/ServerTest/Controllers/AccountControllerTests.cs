using DataDomain.Data.Sql.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Server.Controllers;
using Server.DTO;
using Services.Services;
using Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ServerTest.Controllers
{
    public class AccountControllerTests
    {
        private readonly Mock<IUserService> userServiceMock;
        private readonly AccountController controller;

        public AccountControllerTests()
        {
            userServiceMock = new Mock<IUserService>();
            controller = new AccountController(userServiceMock.Object);
        }

        [Fact]
        public async void LoginUserReturnsErrorIfPasswordNotExistTest()
        {
            //Arrange
            var dto = new UserLoginDTO();
            dto.Email = "qqq@qqq.com";
            dto.RememberMe = true;

            //Act
            var result = await controller.LoginUser(dto);

            //Assert
            var res = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Input data not valid", res.Value);
        }

        [Fact(Skip = "pzdc")]
        public async void LoginUserOkWhenDataCorrectTest()
        {
            //Arrange
            var userModel = new UserModel();
            userModel.Password = "aaaaaaaPass1!";
            userModel.Email = "qqq@qqq.com";

            var userModel2 = new UserModel();
            userModel2.Password = "aaaaaaaPass1!";
            userModel2.Email = "www@qqq.com";

            userServiceMock.Setup(us => us.LoginUserAsync(It.Is<UserModel>(um => um.Email == "qqq@qqq.com"))).Returns(Task.FromResult(userModel));
            userServiceMock.Setup(us => us.LoginUserAsync(It.Is<UserModel>(um => um.Email == "www@qqq.com"))).Returns(Task.FromResult(userModel2));

            //Act
            var dto = new UserLoginDTO();
            dto.Email = "qqq@qqq.com";
            dto.Password = "aaaaaaaPass1!";
            dto.RememberMe = true;

            var result = await controller.LoginUser(dto);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            userServiceMock.Verify(mock => mock.LoginUserAsync(It.IsAny<UserModel>()), Times.Once); // not always needed to check it, because in most cases you dont care about inner logic.
        }
    }
}
