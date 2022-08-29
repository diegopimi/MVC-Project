using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models; // add models!!

namespace MyProject.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (MyProjectEntities dtbs = new MyProjectEntities())
                {
                    var lst = from d in dtbs.user
                              where d.email == user && d.password == password && d.idState == 1 && d.acctype == 1
                              select d;
                    var lst1 = from a in dtbs.user
                               where a.email == user && a.password == password && a.idState == 1 && a.acctype == 2 //Client or user1
                              select a;

                    if (lst.Count() > 0)
                    {
                        user user1 = lst.First();
                        Session["User"] = user1;
                        return Content("1");
                    }
                    if (lst1.Count() > 0)
                    {
                        user user1 = lst1.First(); //client
                        Session["User1"] = user1;
                        return Content("1");
                    }
                    else 
                    {
                        return Content("Invalid Credentials");
                    }
                }
                
            }
            catch (Exception ex)
            {
                return Content("An error occurred" + ex.Message);
            }
        }

    }

}