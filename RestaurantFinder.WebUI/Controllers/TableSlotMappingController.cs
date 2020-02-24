using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantFinder.WebUI.Controllers
{
    public class TableSlotMappingController : Controller
    {
        private readonly Lazy<IRestaurantSlotService> restaurantSlotService;
        private readonly Lazy<IRestaurantTablesService> restaurantTablesService;
        private readonly Lazy<ITableSlotMappingService> tableSlotMappingService;


        public TableSlotMappingController(
            Lazy<IRestaurantSlotService> restaurantSlotService,
          Lazy<ITableSlotMappingService> tableSlotMappingService,
             Lazy<IRestaurantTablesService> restaurantTablesService
            )

        {

            this.restaurantTablesService = restaurantTablesService;
            this.tableSlotMappingService = tableSlotMappingService;
            this.restaurantSlotService = restaurantSlotService;
        }
        public ActionResult Index()
        {
          var list=  tableSlotMappingService.Value.GetAll();
            return View(list);
        }

        // GET: TableSlotMapping/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TableSlotMapping/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableSlotMapping/Create
        [HttpPost]
        public ActionResult Create(RestaurantSlotMapping restaurantSlotMapping)
        {
            try
            {
                tableSlotMappingService.Value.Add(restaurantSlotMapping);
                tableSlotMappingService.Value.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TableSlotMapping/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TableSlotMapping/Edit/5
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

        // GET: TableSlotMapping/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TableSlotMapping/Delete/5
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
