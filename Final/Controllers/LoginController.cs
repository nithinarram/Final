using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinalCaseStudy.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //[Authorize]
        //[MyExceptionFilter]
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "Login", "Index"));
                //return View("Error");
            }
        }
        
        public ActionResult Admin()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "Login", "Admin"));
                //return View("Error");
            }
        }
        public ActionResult Index1()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "Login", "Index1"));
                //return View("Error");
            }
        }

        [HttpPost]
        public ActionResult ValidateAdmin(AdminLoginModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.AdminId == "Nithin" && obj.Password == "N123")
                    {
                        FormsAuthentication.SetAuthCookie(obj.AdminId, true);
                        // Session["username"] = obj.UserName;
                        return RedirectToAction("Home", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid AdminId Or Password");
                        ViewBag.Message = "Invalid AdminId Or Password";
                        return View("Admin");
                    }
                }
                else
                    return View("Admin", obj);
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "Login", "Admin"));
                //return View("Error");
            }
        }

    }
}