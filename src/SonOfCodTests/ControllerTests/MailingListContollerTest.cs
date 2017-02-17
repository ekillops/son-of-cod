using Microsoft.AspNetCore.Mvc;
using SonOfCod.Controllers;
using Xunit;
using SonOfCod.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SonOfCod.Tests
{
    public class MailingListControllerTest
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext( );
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public MailingListControllerTest()
        {
        }


        [Fact]
        public void Get_ViewResult_Join_Test()
        {
            //Arrange
            MailingListController controller = new MailingListController(_userManager, _signInManager, _db);

            //Act
            var result = controller.Join();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ModelList_List_Test()
        {
            //Arrange
            MailingListController controller = new MailingListController(_userManager, _signInManager, _db);
            IActionResult actionResult = controller.List();
            ViewResult listView = controller.List() as ViewResult;

            //Act
            var result = listView.ViewData.Model;

            //Assert
            Assert.IsType<List<Contact>>(result);
        }


    }
}

