using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Cryptology.Controllers
{
    public class AuthUserController : Controller
    {
        // GET: AuthUser
        [AllowAnonymous]
        public ActionResult logIn()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult logIn(User ob)
        {
            CryptologyDbContext cm = new CryptologyDbContext();
            var count = cm.Users.Where(u => u.email == ob.email && u.pword == ob.pword).Count();
            if(count == 0)
            {
                ViewBag.msg = "invalid User";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(ob.email, false);
                ViewBag.name = ob.email;
                return RedirectToAction("Index","Home");
            }
        }
        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}