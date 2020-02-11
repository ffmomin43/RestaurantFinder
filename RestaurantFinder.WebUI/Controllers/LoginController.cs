using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using RestaurantFinder.Repository;
using RestaurantFinder.WebUI.Common.logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RestaurantFinder.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly Lazy<IUsersService> usersService;
        private readonly Lazy<ILoggerFacade<LoginController>> logger;

        public LoginController(Lazy<IUsersService> usersService, Lazy<ILoggerFacade<LoginController>> logger)
        {
            this.usersService = usersService;
            this.logger = logger;
        }


        public ActionResult Login()
        {
            




            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {


            string username = fc["username"];
            string Password = fc["Password"];

            if (usersService.Value.Checklogin(username, Password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                Session["name"] = fc["username"]; 
                return RedirectToAction("DashBoard");

            }
            ViewBag.errorMsg = "Please Check UserName And Password";
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User user)
        {
           
               
           
            try

            {
                user.CreatedOn= DateTime.Now;
                usersService.Value.Add(user);
              
                usersService.Value.Save();
                
              
            }
            catch {

                return View();

            }
            

            return View();
        }
        public ActionResult LockScreen()
        {
            return View();
        }
        public ActionResult ResetPassword()
        {
            return View();
        }
        public ActionResult DashBoard()
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