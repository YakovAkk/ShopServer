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
    public class DraftAccountControllerTest
    {
        [Fact]
        public async void LoginUserOkWhenDataNotNull()
        {
            //Arrange
            var correctDto = new UserLoginDTO();
            correctDto.Email = "vasyan@gmail.com";
            correctDto.Password = "pass";

            var resultModel = new UserModel();
            resultModel.Name = correctDto.Email;

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(x => x.LoginUserAsync(It.IsNotNull<UserModel>())).Returns(Task.FromResult(resultModel));
            // mockedUserService.Reset(); // used to clear all setups
            // mockedUserService.Invocations.Clear(); // reset all invocations already stored

            var controller = new AccountController(mockedUserService.Object);

            //Act
            var result = await controller.LoginUser(correctDto);

            //Assert
            var viewResult = Assert.IsType<OkResult>(result);
            mockedUserService.Verify(mock => mock.LoginUserAsync(It.IsNotNull<UserModel>()), Times.Once); // not always needed to check it, because in most cases you dont care about inner logic.
        }

        [Fact]
        public async void LoginUserBedWhenDataNotFull()
        {
            //Arrange
            var dto = new UserLoginDTO();
            dto.Email = "vasyan@gmail.com";
            // dto.Password = "pass"; //not correct anymore, because password missed

            var resultModel = new UserModel();
            resultModel.Name = dto.Email;

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(x => x.LoginUserAsync(It.IsNotNull<UserModel>())).Returns(Task.FromResult(resultModel));

            var controller = new AccountController(mockedUserService.Object);

            //Act
            var result = await controller.LoginUser(dto);

            //Assert
            var viewResult = Assert.IsType<BadRequestObjectResult>(result);
            mockedUserService.Verify(mock => mock.LoginUserAsync(It.IsNotNull<UserModel>()), Times.Never); // not always needed to check it, because in most cases you dont care about inner logic.
        }

        [Fact]
        public async void LoginUserOkWhenDataForSpecificUserVasyan()
        {
            //Arrange
            var correctDto = new UserLoginDTO();
            correctDto.Email = "vasyan@gmail.com";
            correctDto.Password = "pass";

            var resultModel = new UserModel();
            resultModel.Name = correctDto.Email;

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(x => x.LoginUserAsync(It.Is<UserModel>(um => um.Email == "vasyan@gmail.com"))).Returns(Task.FromResult(resultModel));

            var controller = new AccountController(mockedUserService.Object);

            //Act
            var result = await controller.LoginUser(correctDto);

            //Assert
            var viewResult = Assert.IsType<OkResult>(result);
            mockedUserService.Verify(mock => mock.LoginUserAsync(It.IsNotNull<UserModel>()), Times.Once); // not always needed to check it, because in most cases you dont care about inner logic.
        }

        [Fact]
        public async void LoginUserBadWhenDataForSpecificUserNotVasyan()
        {
            //Arrange
            var correctDto = new UserLoginDTO();
            correctDto.Email = "petro@gmail.com";
            correctDto.Password = "pass";

            var resultModel = new UserModel();
            resultModel.Name = correctDto.Email;

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(x => x.LoginUserAsync(It.Is<UserModel>(um => um.Email == "vasyan@gmail.com"))).Returns(Task.FromResult(resultModel));

            var controller = new AccountController(mockedUserService.Object);

            //Act
            var result = await controller.LoginUser(correctDto);

            //Assert
            var viewResult = Assert.IsType<BadRequestObjectResult>(result);
            mockedUserService.Verify(mock => mock.LoginUserAsync(It.IsNotNull<UserModel>()), Times.Once); // not always needed to check it, because in most cases you dont care about inner logic.
        }
    }
}
