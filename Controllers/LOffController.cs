using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class LOffController : Controller
    {
        public ActionResult LogOff()
        {
            Session["User"] = null;
            Session["User1"] = null;
            return RedirectToAction("Index", "Access"); // "view", "Controller"
        }
    }
}