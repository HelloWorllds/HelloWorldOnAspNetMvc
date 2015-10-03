using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaveNote.Models.Info;
using SaveNote.Model;
using SaveNote.Models.ViewModels;
using SaveNote.Tools;

namespace SaveNote.Areas.Default.Controllers
{
    [Authorize]
    public class PasswordsController : DefaultController
    {
        public ActionResult Index(int page = 1)
        {
            var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);

            var user = Repository.Users.FirstOrDefault(p => p.Email == userEmail);
            var passwordView = new PasswordsView();
            passwordView.UserId = user.ID;
            ViewBag.ID = passwordView.UserId;
            var data = new PageableData<Passwords>(Repository.Password.OrderBy(p => p.UserID).Where(x => x.UserID == passwordView.UserId), page, 20);
            return View(data);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var newPasswordsView = new PasswordsView();
            return View(newPasswordsView);
        }

        [HttpPost]
        public ActionResult Add(PasswordsView passwordsView)
        {
            if (ModelState.IsValid)
            {
                var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);

                var user = Repository.Users.FirstOrDefault(p => p.Email == userEmail);
                passwordsView.UserId = user.ID;

                var passwords = (Passwords)ModelMapper.Map(passwordsView, typeof(PasswordsView), typeof(Passwords));

                Repository.CreatePassword(passwords);
                return View("_OK");
            }

            return View(passwordsView);
        }

        [HttpGet]
        public ActionResult Del()
        {
            var newPasswordsView = new PasswordsView();
            return View(newPasswordsView);
        }

        [HttpPost]
        public ActionResult Del(int ID)
        {
            if (ModelState.IsValid)
            {
                Repository.RemovePassword(ID);

                return View("_OK");
            }

            return View();
        }
    }
}