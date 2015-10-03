﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveNote.Areas.Default.Controllers
{
    public class StartPageController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
