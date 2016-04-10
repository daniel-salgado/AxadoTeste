using AxadoTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AxadoTeste.Controllers
{
    public class LoginController : Controller
    {
        private dbContext db = new dbContext();

        public ActionResult Index()
        {

            FormsAuthentication.SignOut();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User _user)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }



            User user = db.User.Where(X => X.UserName == _user.UserName && X.Password == _user.Password).FirstOrDefault();

            if (user == null)
            {
                ModelState.AddModelError("", "Password is incorrect.");
                return View(user);
            }

            Session["id_User"] = user.id.ToString();
            Session["UserName"] = user.UserName.ToString();




            return RedirectToAction("Index", "Carrier");




        }

        public ActionResult LogOut()
        {

            Session.RemoveAll();

            return RedirectToAction("Index", "Home");
        }

    }
}