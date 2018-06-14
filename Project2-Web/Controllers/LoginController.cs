using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using Project2_Web.Models;

namespace Project2_Web.Controllers
{
    public class LoginController : Controller
    {
        //Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Employee login, string ReturnUrl)
        {
            string message = "";
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var v = db.Employees.Where(a => a.FirstName == login.FirstName).FirstOrDefault();
                if(v != null)
                {
                    if (string.Compare(login.HomePhone, v.HomePhone) == 0)
                    {
                        int timeout = 525600; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.FirstName, true, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
                ViewBag.Message = message;
                return View();
            }
        }

        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}