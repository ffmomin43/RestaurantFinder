using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using RestaurantFinder.WebUI.Common.logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantFinder.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly Lazy<IUsersService> usersService;
        private readonly Lazy<IUserVisitingService> userVisitingService;




        private readonly Lazy<ILoggerFacade<UserController>> logger;

        public UserController(Lazy<IUsersService> usersService,
             Lazy<IUserVisitingService> userVisitingService,

            Lazy<ILoggerFacade<UserController>> logger)
        {
            this.usersService = usersService;

            this.logger = logger;
            this.userVisitingService = userVisitingService;
        }

        // GET: User
        public ActionResult Index()
        {
            var list = usersService.Value.GetAll();
            return View(list);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var list = usersService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();
            return View(list);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {

                this.usersService.Value.Edit(user);
                this.usersService.Value.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var list = usersService.Value.GetAll().Where(x => x.ID == id).Single();
            return View(list);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(User user)
        {
            try
            {
                usersService.Value.Delete(user);
                usersService.Value.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddUserVIsiting()
        {

            return View();

        }
        [HttpPost]
        public ActionResult AddUserVIsiting(UserVisiting userVisiting)
        {

            userVisitingService.Value.Add(userVisiting);
            userVisitingService.Value.Save();
            return View();

        }
    }

    }
