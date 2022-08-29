using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using MyProject.Models.TableViewModels;
using MyProject.Models.ViewModels;

namespace MyProject.Controllers
{
    public class RequestBookController : Controller
    {
        // GET: RequestBook
        public ActionResult Index()
        {
            List<CatalogTableVM> lst = null;
            using (MyProjectEntities dtbs = new MyProjectEntities())
            {
                lst = (from d in dtbs.book_class
                       orderby d.id
                       select new CatalogTableVM
                       {
                           ClassId = d.id,
                           Classname = d.name
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult BookList(int id)
        {
            List<CatalogTableVM> lst = null;
            using (MyProjectEntities dtbs = new MyProjectEntities())
            {
                lst = (from d in dtbs.book
                       where d.idBook_class == id //active
                       orderby d.author
                       select new CatalogTableVM
                       {
                           Author = d.author,
                           Title = d.name,
                           Id = d.id
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Select(int Id, int BId)
        {
            
            CatalogViewModel bmodel = new CatalogViewModel();

            using (var dtbs = new MyProjectEntities())
            {
                var user1 = dtbs.user.Find(Id); 
                var book1 = dtbs.book.Find(BId);
                
            }

            return View();
        }
    }
}