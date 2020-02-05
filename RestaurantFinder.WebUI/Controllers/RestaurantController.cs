using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using RestaurantFinder.WebUI.Common.logger;
using System;
using System.Collections.Generic;
using System.IO;
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
            return PartialView();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(Restaurant  model)
        {
            try
                
            {

                Restaurant restaurant = new Restaurant();
                restaurant.Name = model.Name;
                restaurant.UniqueId = Guid.NewGuid();
                restaurant.AddressLine1 = model.AddressLine1;
                restaurant.AddressLine2 = model.AddressLine2;
                restaurant.Area = model.Area;
                restaurant.City = model.City;
                restaurant.PinCode = model.PinCode;
                restaurant.State = model.State;

                string filename = Path.GetFileNameWithoutExtension(model.imagefile.FileName);
                string extentsion = Path.GetExtension(model.imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extentsion;

                restaurant.ThumbnailImageUrl = "/Images/RestaurantBanners/" + filename;
                filename = Path.Combine(Server.MapPath("~/Images/RestaurantBanners/"), filename);

                model.imagefile.SaveAs(filename);

                //restaurant.RestaurantsImages = new List<RestaurantsImages>();

                //if (!string.IsNullOrEmpty(model.RestaurantsImages))
                //{
                //    restaurant.UniqueId = Guid.NewGuid();
                //var picidget =model.RestaurantsImages.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(Id => int.Parse(Id)).ToList();
                //restaurant.RestaurantsImages = new List<RestaurantsImages>();
                //restaurant.RestaurantsImages.AddRange(picidget.Select(x => new RestaurantsImages { PictureId = x }).ToList());

                //}

                this.restaurantService.Value.Add(restaurant);
                this.restaurantService.Value.Save();
                           
                return RedirectToAction("Index");

            }

            catch (Exception ex)
            {
                return RedirectToAction("");

            }

        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            var resturant = restaurantService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();
            RestaurantimagesVm model = new RestaurantimagesVm();
            model.Name = resturant.Name;
            model.AddressLine1 = resturant.AddressLine1;
            model.AddressLine2 = resturant.AddressLine2;
            model.Area = resturant.Area;
            model.City = resturant.City;
            model.PinCode = resturant.PinCode;
            model.State = resturant.State;
            model.restaurantsImage = resturant.RestaurantsImages;
            model.id = resturant.ID;
            return View(model);
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(RestaurantimagesVm model)
        {
            try
            {
                Restaurant restaurant = new Restaurant();
                restaurant.ID = model.id;
                restaurant.Name = model.Name;
                restaurant.AddressLine1 = model.AddressLine1;
                restaurant.AddressLine2 = model.AddressLine2;
                restaurant.Area = model.Area;
                restaurant.City = model.City;
                restaurant.State = model.State;
                restaurant.PinCode = model.PinCode;
                if (!string.IsNullOrEmpty(model.RestaurantsImages))
                {
                    var picidget = model.RestaurantsImages.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(Id => int.Parse(Id)).ToList();
                    restaurant.RestaurantsImages = new List<RestaurantsImages>();
                    restaurant.RestaurantsImages.AddRange(picidget.Select(x => new RestaurantsImages { PictureId = x }).ToList());
                }


                this.restaurantService.Value.Edit(restaurant);
                this.restaurantService.Value.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        // GET: Restaurant/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var resturant = restaurantService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault() ;

            return View(resturant);
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(Restaurant restaurant)
        {
            try
            {
                this.restaurantService.Value.Delete(restaurant);
                this.restaurantService.Value.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}