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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableVM> lst = null;
            using (MyProjectEntities dtbs = new MyProjectEntities())
            {
                lst = (from d in dtbs.user
                      where d.idState == 1 //active
                      orderby d.email
                      select new UserTableVM
                      {
                          Email = d.email,
                          Id = d.id
                      }).ToList();
            }

            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(); //take us to view
        }

        [HttpPost] //specify u want this method to go in as post
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid) // global object, check all validations for true
            {
                return View(model); // return me to view (filled with model)
            }

            using (var dtbs = new MyProjectEntities())
            {
                user user1 = new user();
                user1.idState = 1; //active
                user1.email = model.Email;
                user1.password = model.Password;

                dtbs.user.Add(user1); //add it to database
                dtbs.SaveChanges(); //save
            }

            return Redirect(Url.Content("~/User/")); //redirect us to list of users
        }

        // if there is no http tag, its get by default
        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel(); //create model

            using (var dtbs = new MyProjectEntities())
            {
                var user1 = dtbs.user.Find(Id); // assign user values to those from the user with specified ID
                model.Email = user1.email;
                model.Id = user1.id;
            }

            return View(); //return to view
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model) //this occurs once you attempt to save changes
        {
            if (!ModelState.IsValid) //validate everything
            {
                return View(model); 
            }

            using (var dtbs = new MyProjectEntities())
            {
                var user1 = dtbs.user.Find(model.Id); //take the id from that specified before in the model
                user1.email = model.Email; //assign its data to user1 ,remember user1 is an object

                if(model.Password!=null && model.Password.Trim() !="") // if password field is changed...
                {
                    user1.password = model.Password; // assign new password
                }

                dtbs.Entry(user1).State = System.Data.Entity.EntityState.Modified; //modify changes
                dtbs.SaveChanges(); //save changes
            }

            return Redirect(Url.Content("~/User/")); //redirect us to user
        }

        [HttpPost]
        public ActionResult Delete(int id) //this occurs once you attempt to save changes
        { 
            using (var dtbs = new MyProjectEntities())
            {
                var user1 = dtbs.user.Find(id); //take the id from that specified before in the model
                user1.idState = 3; //Deleted status
                dtbs.Entry(user1).State = System.Data.Entity.EntityState.Modified; //modify changes
                dtbs.SaveChanges(); //save changes
            }

            return Content("1"); // string 1
        }
    }
}