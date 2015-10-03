using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SaveNote.Models.Info;
using SaveNote.Model;
using SaveNote.Models.ViewModels;
using SaveNote.Tools;

namespace SaveNote.Areas.Default.Controllers
{
    [Authorize]
    public class CalendarController : DefaultController
    {
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);

            var user = Repository.Users.FirstOrDefault(p => p.Email == userEmail);
            var calendarView = new CalendarView();
            calendarView.UserId = user.ID;
            ViewBag.ID = calendarView.UserId;
            var data = new PageableData<Calendar>(Repository.Calendar.Where(x => x.UserID == calendarView.UserId).Where(d => d.Date.Day == DateTime.Now.Day).OrderBy(p => p.Date).OrderBy(p => p.Time), page, 10);
            return View(data);
        }

        [HttpPost]
        public ActionResult Events(DateTime date, int page = 1)
        {
            var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);

            var user = Repository.Users.FirstOrDefault(p => p.Email == userEmail);
            var calendarView = new CalendarView();
            calendarView.UserId = user.ID;
            ViewBag.ID = calendarView.UserId;

            var data = new PageableData<Calendar>(Repository.Calendar.Where(x => x.UserID == calendarView.UserId).Where(d => d.Date.Day == date.Day).OrderBy(p => p.Date).OrderBy(p => p.Time), page, 10);
            return PartialView("Event", data);
            //return View(data);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var newCalendarView = new CalendarView();
            return View(newCalendarView);
        }

        [HttpPost]
        public ActionResult Add(CalendarView calendarView)
        {
            var userEmail = Convert.ToString(HttpContext.Request.Cookies["Email"].Value);

            var user = Repository.Users.FirstOrDefault(p => p.Email == userEmail);
            calendarView.UserId = user.ID;

            var calendar = (Calendar)ModelMapper.Map(calendarView, typeof(CalendarView), typeof(Calendar));

            Repository.CreateCalendar(calendar);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Del()
        {
            var newCalendarView = new CalendarView();
            return View(newCalendarView);
        }

        [HttpPost]
        public ActionResult Del(int ID)
        {
            if (ModelState.IsValid)
            {
                Repository.RemoveCalendar(ID);

                return View("_OK");
            }

            return View();
        }
    }
}
