using Final.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
       // [Authorize]
        //[HandleError]
        public ActionResult Home()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "Admin", "Home"));
                //return View("Error");
            }
        }
        public ActionResult AddRest()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "Admin", "AddRest"));
            }
        }

        public JsonResult Restaurants2(Restaurant r1)
        {


           FinalCaseEntities ctx =
                                 new FinalCaseEntities();
            List<Rest> listRest = new List<Rest>();
            foreach (var item in ctx.Restaurants.ToList())
            {
                if ( r1.Rname == item.Rname)
                {
                    Rest ri = new Rest();
                    ri.Rname = item.Rname;
                    ri.Category = item.Category;
                    ri.Rimage = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Rimages));
                    listRest.Add(ri);
                }
            }
            return Json(listRest,
                   JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddRestaurant2(Restaurant r1, HttpPostedFileBase pfile1)
        {
            try
            {
                FinalCaseEntities ctx = new FinalCaseEntities();
                BinaryReader brd = new BinaryReader(pfile1.InputStream);
                byte[] bt = brd.ReadBytes((int)pfile1.InputStream.Length);
                r1.Rimages = bt;
                ctx.Restaurants.Add(r1);
                ctx.SaveChanges();
                ViewBag.Message = "Restaurant Added";
                return RedirectToAction("AddRest");
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "Admin", "AddRest"));
               
            }
        }
        public JsonResult Branch3(Branch f1)
        {
            FinalCaseEntities ctx = new FinalCaseEntities();
            List<Mybranch> listM = new List<Mybranch>();
            foreach (var item in ctx.Branches.ToList())
            {
                if (f1.Rname == item.Rname && f1.bcity == item.bcity&&f1.Location==item.Location)
                {
                    Mybranch m = new Mybranch();
                    m.Rname = item.Rname;
                    m.bcity = item.bcity;
                    m.Location = item.Location;
                    m.bimage = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.bimage));
                    m.bphonenum = item.bphonenum;
                    listM.Add(m);
                }
            }
            var data1 = from a in ctx.Branches.ToList() where a.Rname == f1.Rname && a.bcity == f1.bcity && a.Location == f1.Location select new { a.bphonenum, a.bimage };
            // Menu s = data1.ToList().FirstOrDefault(i => i.Itemsname == f1.Itemsname);

            return Json(listM,
                  JsonRequestBehavior.AllowGet);
        }

        public JsonResult Restaurants3(Branch r1)
        {
            FinalCaseEntities ctx =
                                  new FinalCaseEntities();
            List<Mybranch> listRest = new List<Mybranch>();
            foreach (var item in ctx.Branches.ToList())
            {
                if (r1.Rname == item.Rname)
                {
                    Mybranch ri = new Mybranch();
                    ri.Rname = item.Rname;
                    ri.bcity = item.bcity;
                    ri.Location = item.Location;
                    ri.bimage = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.bimage));
                    listRest.Add(ri);
                }
            }
            return Json(listRest,
                   JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult FinalUpdateBranch(Branch r1, HttpPostedFileBase pfile3)
        {
            FinalCaseEntities ctx = new FinalCaseEntities();
            // Session["Loc"] = Request.Form["loc"];
            string newlocation = Request.Form["Location1"].ToString();
            string newcity = Request.Form["bcity1"].ToString();
            //r1.Location = newlocation;
            if (pfile3 != null)
            {
                BinaryReader brd = new BinaryReader(pfile3.InputStream);
                byte[] bt = brd.ReadBytes((int)pfile3.InputStream.Length);
                foreach (var item in ctx.Branches)
                {
                    if (r1.Rname == item.Rname && r1.bcity == item.bcity && r1.Location==item.Location)
                    {
                        item.bimage = bt;
                        item.bphonenum = (Int64)r1.bphonenum;
                        item.Location = newlocation;
                        break;
                    }
                }
            }
            else
            {
                
                var obj = ctx.Branches.FirstOrDefault(i => i.Rname == r1.Rname && r1.bcity == i.bcity && i.Location == r1.Location);
                obj.bphonenum = (Int64)r1.bphonenum;
               obj.Location = newlocation;
                obj.bcity = newcity;
                ctx.SaveChanges();
                
            }
            return RedirectToAction("EditRest");
        }
        public ActionResult AddBranch()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "Admin", "AddRest"));
            }
        }
        //public JsonResult  Check(Branch b1)
        //{
        //   // string n = Request.Form["Rname"].ToString();
        //    //string n1 = Request.Form["bcity"].ToString();
        //    //string n2 = Request.Form["Location"].ToString();
        //    int d;
        //    int f;
        //    FinalCaseEntities ctx = new FinalCaseEntities();
        //    foreach (var item in ctx.Branches)
        //    {
        //        if (item.Rname == b1.Rname && item.bcity == b1.bcity && item.Location == b1.Location)
        //        {
        //            d = 0;
        //            //break;
        //        }
        //        else
        //        {
        //            d = 1;
        //         }
        //        //return Json(d, JsonRequestBehavior.AllowGet);
        //    }
        //    f = 0;
        //    return Json(-1,JsonRequestBehavior.AllowGet);

        //}
            [HttpPost]
        public ActionResult AddBranch2(Branch b1, HttpPostedFileBase pfile1)
        {
            
            FinalCaseEntities ctx = new FinalCaseEntities();
            var data = ctx.Branches.FirstOrDefault(i => i.Location == b1.Location && i.bcity == b1.bcity && i.Rname == b1.Rname);
            if (data == null)
            {
                //    try
                //{
                BinaryReader brd = new BinaryReader(pfile1.InputStream);
                byte[] bt = brd.ReadBytes((int)pfile1.InputStream.Length);
                b1.bimage = bt;
                ctx.Branches.Add(b1);
                 ctx.SaveChanges();
                ViewBag.Message = "Branch Added";
                TempData["Success"] = "Branch Added";
                return RedirectToAction("AddBranch");
            }
            TempData["Error"] = "Duplicate branch !!";
            return RedirectToAction("AddBranch");
            //catch (Exception ex)
            //{
            //    return View("Error",
            //        new HandleErrorInfo(ex, "Admin", "AddBranch"));

            //}
        }
        
        public JsonResult GetAllName()
        {
            FinalCaseEntities stx = new FinalCaseEntities();
            var d = from a in stx.Restaurants.ToList()
                    select a.Rname;
            return Json(d.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddMenu()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "Admin", "AddRest"));
            }
        }
        [HttpPost]
        public ActionResult AddMenu2(Menu b1, HttpPostedFileBase pfile1)
        { 
            FinalCaseEntities ctx = new FinalCaseEntities();
            string cat = Request.Form["type"].ToString();
            try
            {
                foreach (var item in ctx.Restaurants)
                {
                    Menu obj = new Menu();
                    if (cat == "Veg&Nonveg")
                    {
                        BinaryReader brd = new BinaryReader(pfile1.InputStream);
                        byte[] bt = brd.ReadBytes((int)pfile1.InputStream.Length);
                        b1.Itemimage = bt;
                        ctx.Menus.Add(b1);
                        break;
                    }
                    else
                    {
                        if (item.Rname == b1.Rname && item.Category == b1.Foodtype)
                        {
                            BinaryReader brd = new BinaryReader(pfile1.InputStream);
                            byte[] bt = brd.ReadBytes((int)pfile1.InputStream.Length);
                            b1.Itemimage = bt;
                            ctx.Menus.Add(b1);
                            break;
                        }
                        else
                        {
                            ViewBag.Message = "wrong";
                        }
                    }
                }
                ctx.SaveChanges();
                ViewBag.Message = "Menu Added";
                return RedirectToAction("AddMenu");
            }
            catch (Exception ex)
            {
                return View("Error",
                    new HandleErrorInfo(ex, "Admin", "AddBranch"));
                //return View("Error");
            }
        }
        
        public JsonResult GetAllMenu(Menu m1)
        {
            FinalCaseEntities stx = new FinalCaseEntities();
            var d = from a in stx.Menus.ToList()
                    where a.Rname == m1.Rname
                    select a.Rname;
            return Json(d.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Menu3(Menu f1)
        {
            FinalCaseEntities ctx =new FinalCaseEntities();
            List<Mymenu> listMenu = new List<Mymenu>();
            foreach (var item in ctx.Menus.ToList())
            {
                if (f1.Rname == item.Rname)
                {
                    Mymenu m = new Mymenu();
                    m.Itemsname = item.Itemsname;
                    m.price = (int)item.price;
                    m.Itemimage = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Itemimage));
                    m.Foodtype = item.Foodtype;
                    listMenu.Add(m);
                }
            }
            var data1 = from a in ctx.Menus.ToList() where (a.Rname == f1.Rname) select a.Itemsname ;
            return Json(listMenu,
                  JsonRequestBehavior.AllowGet);
        }
        public JsonResult Menu5(Menu f1)
        {
            FinalCaseEntities ctx = new FinalCaseEntities();
            List<Mymenu> listMenu = new List<Mymenu>();
            foreach (var item in ctx.Menus.ToList())
            {
                if (f1.Rname == item.Rname)
                {
                    Mymenu m = new Mymenu();
                    m.Itemsname = item.Itemsname;
                    m.price = (int)item.price;
                    m.Itemimage = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Itemimage));
                    m.Foodtype = item.Foodtype;
                    listMenu.Add(m);
                }
            }
            var data1 = from a in ctx.Menus.ToList() where (a.Rname == f1.Rname) select a.Itemsname;
            data1 = data1.Distinct();
            return Json(data1,
                  JsonRequestBehavior.AllowGet);
        }
        public JsonResult Menu4(Menu f1)
        {
            FinalCaseEntities ctx = new FinalCaseEntities();
            List<Mymenu> listMenu = new List<Mymenu>();
            foreach (var item in ctx.Menus.ToList())
            {
                if (f1.Rname == item.Rname&&f1.Itemsname==item.Itemsname)
                {
                    Mymenu m = new Mymenu();
                    m.Itemsname = item.Itemsname;
                    m.price = (int)item.price;
                    m.Itemimage = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Itemimage));
                    m.Foodtype = item.Foodtype;
                    listMenu.Add(m);
                }
            }
            var data1 = from a in ctx.Menus.ToList() where a.Rname == f1.Rname && a.Itemsname==f1.Itemsname select new { a.Itemsname,a.price};
            // Menu s = data1.ToList().FirstOrDefault(i => i.Itemsname == f1.Itemsname);
          
            return Json(listMenu,
                  JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditMenu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FinalUpdateMenu(Menu r1, HttpPostedFileBase pfile1)
        {
            FinalCaseEntities ctx = new FinalCaseEntities();
      
            if (pfile1 != null)
            {
                BinaryReader brd = new BinaryReader(pfile1.InputStream);
                byte[] bt = brd.ReadBytes((int)pfile1.InputStream.Length);
                foreach (var item in ctx.Menus)
                {
                    if (r1.Rname == item.Rname &&r1.Itemsname == item.Itemsname)
                    {
                        item.Itemimage = bt;
                        item.price = (int)r1.price;
                        break;
                    }
                }
            }
            else
            {
               foreach (var item in ctx.Menus)
                {
                   if (r1.Rname == item.Rname && r1.Itemsname == item.Itemsname)
                   {
                      item.price = (int)r1.price;
                       break;
                  }
              }
           }
            ctx.SaveChanges();
            return RedirectToAction("EditMenu");
        }
      
        public JsonResult DelItem2(Menu f1)
        {
           FinalCaseEntities ctx = new FinalCaseEntities();
            foreach (var item in ctx.Menus)
            {
                if (f1.Rname == item.Rname && f1.Itemsname == item.Itemsname)
                {
                    ctx.Menus.Remove(item);
                    break;
                }
            }
            ctx.SaveChanges();
            return Json(f1);
        }
        public ActionResult EditRest()
        {
            return View();
        }
        public JsonResult GetAllName1()
        {
            FinalCaseEntities stx = new FinalCaseEntities();
            var d = from a in stx.Branches.ToList()
                    select a.Rname;
            d = d.Distinct().ToList();
            return Json(d.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllCity(Branch b1)
        {
            FinalCaseEntities stx = new FinalCaseEntities();
            var d = from a in stx.Branches.ToList() where a.Rname ==b1.Rname
                    select a.bcity;
            d = d.Distinct().ToList();
            return Json(d.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Rest5(Restaurant b1)
        {
            FinalCaseEntities stx = new FinalCaseEntities();
            var d = from a in stx.Restaurants.ToList()
                    where a.Rname == b1.Rname
                    select a.Category;
            d = d.Distinct().ToList();
            return Json(d.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllLoc(Branch b1)
        {
            FinalCaseEntities stx = new FinalCaseEntities();
            var d = from a in stx.Branches.ToList()
                    where a.Rname == b1.Rname && a.bcity==b1.bcity
                    select a.Location;
            d = d.Distinct().ToList();
            return Json(d.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DelBranch2(Branch r1)
        {
          FinalCaseEntities ctx = new FinalCaseEntities();
            foreach (var item in ctx.Menus)
            {
                if (r1.Rname == item.Rname )
                {
                    ctx.Menus.Remove(item);
                }
            }
            ctx.SaveChanges();
            foreach (var item2 in ctx.Branches)
            {
                if (r1.Rname == item2.Rname && r1.bcity == item2.bcity && r1.Location == item2.Location)
                {
                    ctx.Branches.Remove(item2);
                    break;
                }
            }
            ctx.SaveChanges();
            return Json(r1);
        }
    }
}