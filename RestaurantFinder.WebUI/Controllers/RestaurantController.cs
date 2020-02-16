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
        private readonly Lazy<IUsersService> usersService;
        private readonly Lazy<ILoggerFacade<RestaurantController>> logger;

        public RestaurantController(Lazy<IRestaurantService> restaurantService, Lazy<IUsersService> usersService, Lazy<ILoggerFacade<RestaurantController>> logger)
        {
            this.restaurantService = restaurantService;
            this.usersService = usersService;
            this.logger = logger;
        }

        // GET: Restaurant
        public ActionResult checking()
        {
            return View();

        }
        public ActionResult Index()
        {
            string name = User.Identity.Name;
            int id = usersService.Value.userid(name);
            var model = restaurantService.Value.GetAll().Where(x=>x.UserId==id);
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
        public ActionResult Create(Restaurant  restaurant)
        {
            if (restaurantService.Value.IsExist(restaurant.Name))
            {
                ViewBag.checkname = "Name Already Exist";

            }
            else
            {



                if (restaurant.imagefile != null)



                {


                    
                        string name = User.Identity.Name;
                        int id = usersService.Value.userid(name);

                        restaurant.UniqueId = Guid.NewGuid();
                        restaurant.CreatedBy = "System";
                        string filename = Path.GetFileNameWithoutExtension(restaurant.imagefile.FileName);
                        string extentsion = Path.GetExtension(restaurant.imagefile.FileName);
                        filename = filename + DateTime.Now.ToString("yymmssfff") + extentsion;
                        restaurant.ThumbnailImageUrl = "/Images/Restaurant/" + filename;
                        filename = Path.Combine(Server.MapPath("~/Images/Restaurant/"), filename);
                        restaurant.imagefile.SaveAs(filename);
                    restaurant.UserId = id;



                    this.restaurantService.Value.Add(restaurant);
                        this.restaurantService.Value.Save();
                        return RedirectToAction("Create","RestaurantLocation", new { Resid = restaurant.ID });
                    
                }
            }
            
            return View();

        }
         

        
// GET: Restaurant/Edit/5
public ActionResult Edit(int id)
        {
            var resturant = restaurantService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();
           
            return View(resturant);
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            try
            {

                if (restaurant.imagefile != null)
                {
                    string name = User.Identity.Name;
                    int id = usersService.Value.userid(name);

                    restaurant.UniqueId = Guid.NewGuid();
                    restaurant.CreatedBy = "System";
                    string filename = Path.GetFileNameWithoutExtension(restaurant.imagefile.FileName);
                    string extentsion = Path.GetExtension(restaurant.imagefile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extentsion;
                    restaurant.ThumbnailImageUrl = "/Images/Restaurant/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/Restaurant/"), filename);
                    restaurant.imagefile.SaveAs(filename);
                    restaurant.UserId = id;



                    this.restaurantService.Value.Edit(restaurant);
                    this.restaurantService.Value.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
        
        
        
        public ActionResult RestaurantListAdmin()
        {
            string name = User.Identity.Name;
            int id = usersService.Value.userid(name);
            var model = restaurantService.Value.GetAll();
            return View(model);
        }
        
        public ActionResult EditRestaurantByAdmin(int id)
        {
            ViewBag.istrending = restaurantService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();

            var resturant = restaurantService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();

            return View(resturant);
        }
        [HttpPost]
        public ActionResult EditRestaurantByAdmin(Restaurant restaurant)
        {
            if(restaurant.IsTrending==true)
            {
                restaurant.UpdatedDate = DateTime.Now;
                restaurant.IsTrending = true;
                restaurantService.Value.Edit(restaurant);
                restaurantService.Value.Save();

            }
            else {
                restaurant.UpdatedDate = DateTime.Now;
                restaurantService.Value.Edit(restaurant);
            restaurantService.Value.Save();
            }
            return RedirectToAction("RestaurantListAdmin");
           
        }
    }


}