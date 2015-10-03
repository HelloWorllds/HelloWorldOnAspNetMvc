using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaveNote.Models.ViewModels;

namespace SaveNote.Areas.Default.Controllers
{
    public class LoginController : DefaultController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult Index(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(loginView.Email, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    //Session["Email"] = loginView.Email;
                    HttpContext.Response.Cookies["Email"].Value = loginView.Email;

                    var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);
                    ViewBag.UserEmail = userEmail;
                    return RedirectToAction("Index", "Notes");
                }
                ModelState["Password"].Errors.Add("Пароли не совпадают");
            }
            return View(loginView);
        }

        public ActionResult Logout()
        {
            Auth.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
