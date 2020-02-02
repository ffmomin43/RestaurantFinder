using RestaurantFinder.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantFinder.WebUI.Controllers
{
    public class CategoryMasterController : Controller
    {
        private readonly Lazy<ICategoryMasterService> categoryMasterService;

        public CategoryMasterController(
            Lazy<ICategoryMasterService> categoryMasterService
            )
        {
            this.categoryMasterService = categoryMasterService;
        }

        // GET: CategoryMaster
        public ActionResult Index()
        {
            var model = this.categoryMasterService.Value.GetAll();
            return View(model);
        }

        // GET: CategoryMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryMaster/Create
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

        // GET: CategoryMaster/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryMaster/Edit/5
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

        // GET: CategoryMaster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryMaster/Delete/5
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
