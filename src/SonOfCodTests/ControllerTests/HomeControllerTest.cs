using Microsoft.AspNetCore.Mvc;
using SonOfCod.Controllers;
using Xunit;
using SonOfCod.Models;
using Microsoft.AspNetCore.Identity;

namespace SonOfCod.Tests
{
    public class HomeControllerTest
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeControllerTest()
        {
        }


        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            HomeController controller = new HomeController(_userManager, _signInManager, _db);
            
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ViewResult_UploadPhoto_Test()
        {
            //Arrange
            HomeController controller = new HomeController(_userManager, _signInManager, _db);

            //Act
            var result = controller.UploadPhoto();

            //Assert
            Assert.IsType<ViewResult>(result);
        }


    }
 }
