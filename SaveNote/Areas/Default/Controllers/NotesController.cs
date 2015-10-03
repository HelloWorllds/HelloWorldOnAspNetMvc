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
    [ValidateInput(false)]
    [Authorize]
    public class NotesController : DefaultController
    {        
        public ActionResult Index(int page = 1)
        {
            var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);

            var user = Repository.Users.FirstOrDefault(p => p.Email == userEmail);
            var notesView = new NotesView();
            notesView.UserId = user.ID;
            ViewBag.ID = notesView.UserId;
            var data = new PageableData<Notes>(Repository.Note.OrderBy(p => p.UserID).Where(x => x.UserID == notesView.UserId), page, 10);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var newNotesView = new NotesView();
            return View(newNotesView);
        }

        [HttpPost]
        public ActionResult Edit(NotesView notesView)
        {
            var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);

            var user = Repository.Users.FirstOrDefault(p => p.Email == userEmail);
            notesView.UserId = user.ID;

            var note = (Notes)ModelMapper.Map(notesView, typeof(NotesView), typeof(Notes));

            Repository.UpdateNote(note);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            var newNotesView = new NotesView();
            return View(newNotesView);
        }

        [HttpPost]
        public ActionResult Add(NotesView notesView)
        {
            if (ModelState.IsValid)
            {
                var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);

                var user = Repository.Users.FirstOrDefault(p => p.Email == userEmail);
                notesView.UserId = user.ID;

                var note = (Notes)ModelMapper.Map(notesView, typeof(NotesView), typeof(Notes));

                Repository.CreateNote(note);
                return RedirectToAction("Index");
            }

            return View(notesView);
        }

        [HttpGet]
        public ActionResult Del()
        {
            var newNotesView = new NotesView();
            return View(newNotesView);
        }

        [HttpPost]
        public ActionResult Del(int ID)
        {
            if (ModelState.IsValid)
            {
                Repository.RemoveNote(ID);

                return View("_OK");
            }

            return View();
        }

        public ActionResult ViewFullModal(int id)
        {
            var model = Repository.Note.FirstOrDefault(p => p.ID == id);
            return PartialView("FullNote", model);
        }
    }
}
