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
    public class YouTubeLinksController : DefaultController
    {
        public ActionResult Index(int page = 1)
        {
            var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);

            var user = Repository.Users.FirstOrDefault(p => p.Email == userEmail);
            var videoView = new VideoView();
            videoView.UserId = user.ID;
            ViewBag.ID = videoView.UserId;
            var data = new PageableData<YouTubeLinks>(Repository.YouTubeLink.OrderBy(p => p.UserID).Where(x => x.UserID == videoView.UserId), page, 6);
            return View(data);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var newVideoView = new VideoView();
            return View(newVideoView);
        }

        [HttpPost]
        public ActionResult Add(VideoView videoView)
        {
            if (ModelState.IsValid)
            {
                var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);

                var user = Repository.Users.FirstOrDefault(p => p.Email == userEmail);
                videoView.UserId = user.ID;

                var videos = (YouTubeLinks)ModelMapper.Map(videoView, typeof(VideoView), typeof(YouTubeLinks));

                Repository.CreateYouTubeLink(videos);
                return RedirectToAction("Index");
            }

            return View(videoView);
        }

        [HttpGet]
        public ActionResult Del()
        {
            var newVideoView = new VideoView();
            return View(newVideoView);
        }

        [HttpPost]
        public ActionResult Del(int ID)
        {
            if (ModelState.IsValid)
            {
                Repository.RemoveYouTubeLink(ID);

                return View("_OK");
            }

            return View();
        }
    }
}