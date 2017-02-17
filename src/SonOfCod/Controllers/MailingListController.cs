using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SonOfCod.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;


namespace SonOfCod.Controllers
{
    public partial class MailingListController : BaseController
    {
        public MailingListController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db) : base(userManager, signInManager, db)
        {
        }

        public IActionResult Join()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Join(Contact newContact)
        {
            _db.Contacts.Add(newContact);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult List()
        {
            List<Contact> allContacts = _db.Contacts.ToList();
            return View(allContacts);
        }
    }
}
