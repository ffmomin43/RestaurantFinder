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
        private readonly Lazy<IUsersService> usersService;
        private readonly Lazy<IRestaurantService> restaurantService;
        private readonly Lazy<ITableSlotMappingService> tableSlotMappingService;


        public TableSlotMappingController(
            Lazy<IRestaurantSlotService> restaurantSlotService,
          Lazy<ITableSlotMappingService> tableSlotMappingService,
          Lazy<IRestaurantService> restaurantService,
          Lazy<IUsersService> usersService,
             Lazy<IRestaurantTablesService> restaurantTablesService
            )

        {

            this.restaurantTablesService = restaurantTablesService;
            this.tableSlotMappingService = tableSlotMappingService;
            this.usersService = usersService;
            this.restaurantService = restaurantService;
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
            TableSlotVm tableSlotVm = new TableSlotVm();
            ViewBag.tables = restaurantTablesService.Value.GetAll().Count();
            ViewBag.slot = restaurantSlotService.Value.GetAll().Count();
            tableSlotVm.RestaurantSlot = restaurantSlotService.Value.GetAll().ToList();
            tableSlotVm.restaurantTable = restaurantTablesService.Value.GetAll().ToList();
            string name = User.Identity.Name;
            int id = usersService.Value.userid(name);
            ViewBag.resturant = restaurantService.Value.GetAll().Where(x => x.UserId == id);

            return View(tableSlotVm);
        }

        // POST: TableSlotMapping/Create
        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            ViewBag.tables = restaurantTablesService.Value.GetAll().Count();
            ViewBag.slot = restaurantSlotService.Value.GetAll().Count();
            string[] slot = fc["RestaurantSlotId"].Split(',');
            string[] table = fc["TableId"].Split(',');
            for (int i = 0; i < table.Length; i++)
            {
                slot[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(Id => Convert.ToString((Id))).ToList();

                for (int j = 0; i < table.Length; i++)
                {
                    table[j].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(Id => Convert.ToString((Id))).ToList();



                    RestaurantSlotMapping restaurantSlot = new RestaurantSlotMapping();
                    restaurantSlot.RestaurantSlotId = Convert.ToInt32(slot[i]);
                    restaurantSlot.TableId = Convert.ToInt32(table[i]);

                    restaurantSlot.UniqueId = new Guid();
                    tableSlotMappingService.Value.Add(restaurantSlot);
                    restaurantSlotService.Value.Save();
                }
            }
            return View();

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
