﻿using RestaurantFinder.BusinessLogic.Interface;
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
        private readonly Lazy<IUserRolesService>userRolesService;

        private readonly Lazy<IRestaurantService> restaurantService;
        private readonly Lazy<ILoggerFacade<LoginController>> logger;

        public LoginController(Lazy<IUsersService> usersService, Lazy<IUserRolesService> userRolesService, Lazy<IRestaurantService> restaurantService, Lazy<ILoggerFacade<LoginController>> logger)
        {
            this.usersService = usersService;
            this.userRolesService = userRolesService;
            this.restaurantService = restaurantService;
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
                string name = User.Identity.Name;
                int id = usersService.Value.userid(name);
                //check Restaurant list login user
              var list=  restaurantService.Value.GetAll().Where(x => x.UserId == id).ToList();
                //if user found then if work
                if (list.Count() > 0)
                {
                    
                    return RedirectToAction("DashBoard");
                }
                
                else

                {
                    return RedirectToAction("Create","Restaurant");

                }

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
              int id=  usersService.Value.Insert(user);
                UserRole userRole = new UserRole();
                userRole.ID = 2;
                userRole.UserID = id;
                userRolesService.Value.Add(userRole);
                userRolesService.Value.Save();
              
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