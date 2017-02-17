using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SonOfCod.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FlickrClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult UploadPhoto()
        {
            return View();
        }

        [Authorize]
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