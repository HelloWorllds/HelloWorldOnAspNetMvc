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
    public class BookmarksController : DefaultController
    {
        public ActionResult Index(int page = 1)
        {
            var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);

            var user = Repository.Users.FirstOrDefault(p => p.Email == userEmail);
            var bookmarkView = new BookmarkView();
            bookmarkView.UserId = user.ID;
            ViewBag.ID = bookmarkView.UserId;
            var data = new PageableData<Bookmarks>(Repository.Bookmark.OrderBy(p => p.UserID).Where(x => x.UserID == bookmarkView.UserId), page, 12);
            return View(data);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var newBookmarkView = new BookmarkView();
            return View(newBookmarkView);
        }

        [HttpPost]
        public ActionResult Add(BookmarkView bookmarkView)
        {
            if (ModelState.IsValid)
            {
                var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);

                var user = Repository.Users.FirstOrDefault(p => p.Email == userEmail);
                bookmarkView.UserId = user.ID;

                var bookmark = (Bookmarks)ModelMapper.Map(bookmarkView, typeof(BookmarkView), typeof(Bookmarks));

                Repository.CreateBookmark(bookmark);
                return RedirectToAction("Index");
            }

            return View(bookmarkView);
        }

        [HttpGet]
        public ActionResult Del()
        {
            var newBookmarkView = new BookmarkView();
            return View(newBookmarkView);
        }

        [HttpPost]
        public ActionResult Del(int ID)
        {
            if (ModelState.IsValid)
            {
                Repository.RemoveBookmark(ID);

                return View("_OK");
            }

            return View();
        }
    }
}