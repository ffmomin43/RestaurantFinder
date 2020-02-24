using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantFinder.WebUI.Controllers
{
    public class RestaurantSlotController : Controller
    {
        private readonly Lazy<IRestaurantSlotService> restaurantSlotService;
        private readonly Lazy<IRestaurantTablesService> restaurantTablesService;
        private readonly Lazy<ITableSlotMappingService> tableSlotMappingService;


        public RestaurantSlotController(
            Lazy<IRestaurantSlotService> restaurantSlotService,
          Lazy<ITableSlotMappingService> tableSlotMappingService,
             Lazy<IRestaurantTablesService> restaurantTablesService
            )

        {
            
            this.restaurantTablesService = restaurantTablesService;
            this.tableSlotMappingService = tableSlotMappingService;
            this.restaurantSlotService = restaurantSlotService;
        }


        // GET: RestaurantSlot
        public ActionResult Index()
        {
          var list=  restaurantSlotService.Value.GetAll();
            return View(list);
        }


        public ActionResult Create()
        {
            TableSlotVm tableSlotVm = new TableSlotVm();
            ViewBag.tables = restaurantTablesService.Value.GetAll().Count();
            ViewBag.slot = restaurantSlotService.Value.GetAll().Count();
            tableSlotVm.RestaurantSlot = restaurantSlotService.Value.GetAll().ToList();
            tableSlotVm.restaurantTable = restaurantTablesService.Value.GetAll().ToList();

            return View(tableSlotVm);
        }
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
        public ActionResult CreateResturantSlot()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateResturantSlot( RestaurantSlot restaurantSlot)
        {
            restaurantSlotService.Value.Add(restaurantSlot);
            restaurantSlotService.Value.Save();

            return View("Index");
        }

    }


}