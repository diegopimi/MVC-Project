using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Controllers;
using MyProject.Models;

namespace MyProject.Filters
{
    public class VerifySession : ActionFilterAttribute //heredity
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext) //force to do something, enters before access controller since occurs OnAction
        {
            var user1 = (user)HttpContext.Current.Session["User"]; //'user' is the field from our table, evaluate session
            var user2 = (user)HttpContext.Current.Session["User1"]; //'user' is the field from our table, evaluate session
            if (user1 == null && user2 ==null)
            {
       
                if (filterContext.Controller is AccessController == false) //thus controller is HomeController, without this if, it would cycle all the time in this filter
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index"); //then redirect to login.. root
                }

            }
            else
            {
                if (filterContext.Controller is AccessController == true) 
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index"); 
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}