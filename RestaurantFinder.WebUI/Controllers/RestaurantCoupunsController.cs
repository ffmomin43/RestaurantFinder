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
    [Authorize]
    public class RestaurantCoupunsController : Controller
    {
        private readonly Lazy<IRestaurantService> restaurantService;
        private readonly Lazy<IRestaurantCouponMasterService> couponMasterService;
        private readonly Lazy<ILoggerFacade<RestaurantCoupunsController>> logger;

        public RestaurantCoupunsController(Lazy<IRestaurantCouponMasterService> couponMasterService, Lazy<IRestaurantService> restaurantService, Lazy<ILoggerFacade<RestaurantCoupunsController>> logger)
        {
            this.couponMasterService = couponMasterService;
            this.restaurantService = restaurantService;
            this.logger = logger;
        }
        // GET: RestaurantCoupuns
        public ActionResult Index()
        {
          var coupouns=  couponMasterService.Value.GetAll();
            return View(coupouns);
        }

        // GET: RestaurantCoupuns/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RestaurantCoupuns/Create
        public ActionResult Create()
        {

            ViewBag.resturant = restaurantService.Value.GetAll();
            return View();
        }

        // POST: RestaurantCoupuns/Create
        [HttpPost]
        public ActionResult Create(RestaurantCouponsMaster restaurantCouponsMaster)
        {
            try
            {

                couponMasterService.Value.Add(restaurantCouponsMaster);
                couponMasterService.Value.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantCoupuns/Edit/5
        public ActionResult Edit(int id)
        {
            var coupuns = couponMasterService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();
            return View(coupuns);
        }

        // POST: RestaurantCoupuns/Edit/5
        [HttpPost]
        public ActionResult Edit(RestaurantCouponsMaster restaurantCouponsMaster)
        {
            try
            {
                couponMasterService.Value.Edit(restaurantCouponsMaster);
                couponMasterService.Value.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantCoupuns/Delete/5
        public ActionResult Delete(int id)
        {
            var coupons = couponMasterService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();
            return View(coupons);
        }

        // POST: RestaurantCoupuns/Delete/5
        [HttpPost]
        public ActionResult Delete(RestaurantCouponsMaster restaurantCouponsMaster) 
        {
            try
            {
                couponMasterService.Value.Delete(restaurantCouponsMaster);
                couponMasterService.Value.Save();
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
