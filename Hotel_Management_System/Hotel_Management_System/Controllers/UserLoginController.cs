﻿using Hotel_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hotel_Management_System.Controllers
{
    
    public class UserLoginController : Controller
    {
        public MyDbContext db = new MyDbContext();
        // GET: UserLogin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index (User u)
        {
                db.User.Add(u);
                db.SaveChanges();
                return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User us)
        {
            var  obj=db.User.Any(x=> x.WorkDomain==us.WorkDomain && x.UserName==us.UserName && x.Password==us.Password);
            if (us.WorkDomain == "Admin" && obj==true)
            {
                FormsAuthentication.SetAuthCookie(us.UserName, false);
                return RedirectToAction("Admin");
            }
            else if(us.WorkDomain== "Manager" && obj == true)
            {
                FormsAuthentication.SetAuthCookie(us.UserName, false);
                return RedirectToAction("Manager");
            }
            else if (us.WorkDomain == "Receptionist" &&  obj==true)
            {
                FormsAuthentication.SetAuthCookie(us.UserName, false);
                return RedirectToAction("Receptionist");
            }
            else
            {
                Console.WriteLine("No authorization... Found");
            }
            ModelState.AddModelError("", "Invalid Details..");
            return View();
        }
     
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Manager()
        {
            return View();
        }
        public ActionResult Receptionist()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}