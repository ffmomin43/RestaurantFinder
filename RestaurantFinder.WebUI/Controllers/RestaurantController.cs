﻿using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.WebUI.Common.logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantFinder.WebUI.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly Lazy<IRestaurantService> restaurantService;
        private readonly Lazy<ILoggerFacade<RestaurantController>> logger;

        public RestaurantController(Lazy<IRestaurantService> restaurantService, Lazy<ILoggerFacade<RestaurantController>> logger)
        {
            this.restaurantService = restaurantService;
            this.logger = logger;
        }

        // GET: Restaurant
        public ActionResult checking()
        {
            return View();
            
        }
        public ActionResult Index()
        {
            var model = restaurantService.Value.GetAll();
            return View(model);
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
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

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}