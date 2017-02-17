using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SonOfCod.Models;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SonOfCod.Controllers
{
    public abstract partial class BaseController : Controller
    {

        public readonly ApplicationDbContext _db;
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;

        //public static Photo Boats { get; set; }
        //public static Photo Nets { get; set; }

        public BaseController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            //Boats = _db.Photos.FirstOrDefault(ph => ph.Name == "Boats");
            //Nets = _db.Photos.FirstOrDefault(ph => ph.Name == "Nets");

        }

    }
}
