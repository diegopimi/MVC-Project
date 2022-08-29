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
    public class CatalogController : Controller
    {
        // GET: Catalog
        public ActionResult Index()
        {
            List<CatalogTableVM> lst = null;
            using (MyProjectEntities dtbs = new MyProjectEntities())
            {
                lst = (from d in dtbs.book
                       where d.id != null
                       orderby d.author
                       select new CatalogTableVM
                       {
                           Id = d.id,
                           Author = d.author,
                           Title = d.name,
                           IdBook_Class = d.idBook_class

                       }).ToList();


                return View(lst);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost] //specify u want this method to go in as post
        public ActionResult Add(CatalogViewModel model)
        {
            if (!ModelState.IsValid) // global object, check all validations for true
            {
                return View(model); // return me to view (filled with model)
            }

            using (var dtbs = new MyProjectEntities())
            {
                book book1 = new book();
                book1.author = model.Author; //active
                book1.name = model.Title;
                book1.idBook_class = model.IdBook_Class;

                dtbs.book.Add(book1); //add it to database
                dtbs.SaveChanges(); //save
            }

            return Redirect(Url.Content("~/Catalog/")); //redirect us to list of users
        }

        public ActionResult Edit(int Id)
        {
            EditCatalogViewModel model = new EditCatalogViewModel(); //create model

            using (var dtbs = new MyProjectEntities())
            {
                var user1 = dtbs.book.Find(Id); // assign user values to those from the user with specified ID
                model.Author = user1.author;
                model.Title = user1.name;
                model.Id = user1.id;
            }

            return View(); //return to view
        }

        [HttpPost]
        public ActionResult Edit(EditCatalogViewModel model) //this occurs once you attempt to save changes
        {
            if (!ModelState.IsValid) //validate everything
            {
                return View(model);
            }

            using (var dtbs = new MyProjectEntities())
            {
                var book1 = dtbs.book.Find(model.Id); //take the id from that specified before in the model
                book1.author = model.Author; //assign its data to user1 ,remember user1 is an object
                book1.name = model.Title;
                book1.idBook_class = model.IdBook_Class;

                dtbs.Entry(book1).State = System.Data.Entity.EntityState.Modified; //modify changes
                dtbs.SaveChanges(); //save changes
            }

            return Redirect(Url.Content("~/Catalog/")); //redirect us to catalog
        }

        [HttpPost]
        public ActionResult Delete(int id) //this occurs once you attempt to save changes
        {
            using (var dtbs = new MyProjectEntities())
            {
                var book1 = dtbs.book.Find(id); //take the id from that specified before in the model
                dtbs.book.Remove(book1);
                dtbs.SaveChanges(); //save changes
            }

            return Content("1"); // string 1
        }
    }
}