using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public class ElementJsonIntKey
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }

        public ActionResult Index()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            using (Models.MyProjectEntities dtbs = new Models.MyProjectEntities())
            {
                lst = (from d in dtbs.book_class
                       select new SelectListItem
                       {
                           Value = d.id.ToString(),
                           Text = d.name
                       }).ToList();

            }
            return View(lst);
        }

        [HttpGet]
        public JsonResult Book(int IdBookClass)
        {
            List<ElementJsonIntKey> lst = new List<ElementJsonIntKey>();

            using (Models.MyProjectEntities dtbs = new Models.MyProjectEntities())
            {
                lst = (from d in dtbs.book
                       where d.idBook_class == IdBookClass
                       select new ElementJsonIntKey
                       {
                           Value = d.id,
                           Text = d.name
                       }
                       ).ToList();
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

    }
}