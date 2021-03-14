using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult User()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "UserLogin", "User"));
                //return View("Error");
            }
        }
        public ActionResult User1()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "UserLogin", "User"));
                //return View("Error");
            }
        }
        public ActionResult Signup1()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "UserLogin", "User"));
                //return View("Error");
            }
        }
        public JsonResult City2()
        {
           FinalCaseEntities ctx = new FinalCaseEntities();
            var data = from a in ctx.Branches.ToList()
                       select a.bcity;
            List<string> City = new List<string>();
            foreach (var item in data)
            {
                string temp = item as string;
                City.Add(item);
            }
            List<string> dist = City.Distinct().ToList();
            return Json(dist,
                JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ValidateUser(UserLoginModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FinalCaseEntities ctx = new FinalCaseEntities();
                    int cnt = 0;
                    foreach (var item in ctx.Customers)
                    {
                        if (obj.UserId == item.Userid && obj.Password == item.password)
                        {
                            cnt++;
                            break;
                        }
                    }
                    if (cnt != 0)
                    {
                        ViewBag.msg = "Signed In Successfully";
                        var rows = from a in ctx.Carts
                                   select a;
                        foreach (var row in rows)
                        {
                            ctx.Carts.Remove(row);
                        }
                        ctx.SaveChanges();
                        Session["City"] = Request.Form["usercity"];
                        Session["Id"] = Request.Form["UserId"];
                        return RedirectToAction("Home", "User");

                    }
                    else
                    {

                        //ModelState.AddModelError("", "Invalid UserId Or Password");
                        //ViewBag.msg="Invalid UserId Or Password";
                        ViewBag.Message = "Invalid UserId Or Password";
                        return View("User1");
                    }
                }
                else
                    return View("User", obj);
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "UserLogin", "User"));
                //return View("Error");
            }
        }
        [HttpPost]
        public JsonResult Signup2(Customer u1)
        {
            FinalCaseEntities ctx = new FinalCaseEntities();
            int cnt = 0;
            //string p = Request.Form["Password"].ToString();
            //string p1= Request.Form["repeat-pass"].ToString();
            //if (p == p1)
            //{
                foreach (var item in ctx.Customers)
                {
                    if (u1.Userid == item.Userid)
                    {
                        //txtId.Text = "";
                        //txtPwd.Text = "";
                        break;
                    }
                    cnt++;
                }
                if (cnt == ctx.Customers.Count())
                {
                    Customer u = new Customer()
                    {
                        Userid = u1.Userid,
                        password = u1.password
                    };
                    ctx.Customers.Add(u);
                    ctx.SaveChanges();
                  
                    ViewBag.Message="Registered Successfully";
                }
            //}
            return Json(u1, JsonRequestBehavior.AllowGet);
            
        }
    }
}