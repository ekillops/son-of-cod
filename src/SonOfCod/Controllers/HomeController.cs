using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SonOfCod.Models;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace SonOfCod.Controllers
{
    public partial class HomeController : BaseController
    {

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db) : base(userManager, signInManager, db)
        {
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadPhoto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadPhoto(string Name, IFormFile Data)
        {
            byte[] photoArray = new byte[0];

            if (Data != null)
            {
                using (Stream fileStream = Data.OpenReadStream())
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    photoArray = memoryStream.ToArray();
                }
            }

            Photo newPhoto = new Photo(Name, photoArray);

            _db.Photos.Add(newPhoto);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}