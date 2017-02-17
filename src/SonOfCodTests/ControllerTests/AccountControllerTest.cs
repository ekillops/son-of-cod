using Microsoft.AspNetCore.Mvc;
using SonOfCod.Controllers;
using Xunit;
using SonOfCod.Models;
using Microsoft.AspNetCore.Identity;

namespace SonOfCod.Tests
{
    public class AccountControllerTest
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountControllerTest()
        {
        }


        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            AccountController controller = new AccountController(_userManager, _signInManager, _db);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ViewResult_Signup_Test()
        {
            //Arrange
            AccountController controller = new AccountController(_userManager, _signInManager, _db);

            //Act
            var result = controller.Signup();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ViewResult_Login_Test()
        {
            //Arrange
            AccountController controller = new AccountController(_userManager, _signInManager, _db);

            //Act
            var result = controller.Login();

            //Assert
            Assert.IsType<ViewResult>(result);
        }


    }
}
