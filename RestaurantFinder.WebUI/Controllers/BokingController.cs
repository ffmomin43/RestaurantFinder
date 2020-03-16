using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantFinder.WebUI.Controllers
{
    public class BokingController : Controller
    {
        private readonly Lazy<IRestaurantSlotService> restaurantSlotService;
        private readonly Lazy<IRestaurantTablesService> restaurantTablesService;
        private readonly Lazy<ITableSlotMappingService> tableSlotMappingService;
        private readonly Lazy<IRestaurantBookingService> restaurantBookingService;
        private readonly Lazy<IRestaurantService> restaurantService;
        private readonly Lazy<IUsersService> usersService;


        public BokingController(
            Lazy<IRestaurantSlotService> restaurantSlotService,
          Lazy<ITableSlotMappingService> tableSlotMappingService,
          Lazy<IRestaurantBookingService> restaurantBookingService,
          Lazy<IRestaurantService> restaurantService,
          Lazy<IUsersService> usersService,
             Lazy<IRestaurantTablesService> restaurantTablesService
            )

        {

            this.restaurantTablesService = restaurantTablesService;
            this.tableSlotMappingService = tableSlotMappingService;
            this.restaurantSlotService = restaurantSlotService;
            this.restaurantService = restaurantService;
            this.restaurantBookingService = restaurantBookingService;
            this.usersService = usersService;
        }

        // GET: Boking
        public ActionResult Index()
        {
            string name = User.Identity.Name;
            int id = usersService.Value.userid(name);
           string getid = id.ToString();
            var list = from bookingres in restaurantBookingService.Value.GetAll().ToList()

                       join r in restaurantService.Value.GetAll().ToList() on bookingres.RestaurantID equals r.ID
                       join rtable in restaurantTablesService.Value.GetAll().ToList() on bookingres.TableID equals rtable.ID
                       join slot in restaurantSlotService.Value.GetAll().ToList() on bookingres.Slotid equals slot.ID
                       where r.UserId == id
                       select new BookingUserRestaurantList

                       {
                           RestaurantId = bookingres.RestaurantID,
                           Tableid = bookingres.TableID,
                           BookingDate = bookingres.BookingDate,
                           UserId = bookingres.UserId,
                           RestaurantName = r.Name,
                           Restaurantimage = r.ThumbnailImageUrl,
                           NoOfPerson = rtable.TableCapacity,
                           slotname = slot.SlotName,
                           Bookingid = bookingres.UniqueId.ToString().Split('-')[0]






                       };
            return View(list);
        }

        // GET: Boking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Boking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boking/Create
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

        // GET: Boking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Boking/Edit/5
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

        // GET: Boking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Boking/Delete/5
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
