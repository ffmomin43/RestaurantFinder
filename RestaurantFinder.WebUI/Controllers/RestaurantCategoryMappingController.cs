using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantFinder.WebUI.Controllers
{
    public class RestaurantCategoryMappingController : Controller
    {

        
        private readonly Lazy<ICategoryMasterService> categoryMasterService;
        private readonly Lazy<IRestaurantCategoryMappingService> categoryMappingService;
        private readonly Lazy<IRestaurantService> restaurantService;

        public RestaurantCategoryMappingController(
            Lazy<ICategoryMasterService> categoryMasterService,
             Lazy<IRestaurantCategoryMappingService> categoryMappingService,
             Lazy<IRestaurantService> restaurantService
            )
        {
            this.categoryMasterService = categoryMasterService;
            this.categoryMappingService = categoryMappingService;
            this.restaurantService = restaurantService;
        }

        // GET: RestaurantCategoryMapping
        public ActionResult Index()
        {
     var  list=       from catemapping in categoryMappingService.Value.GetAll()
            join catemaster in categoryMasterService.Value.GetAll()
            on catemapping.CategoryId equals catemaster.ID
            join Res in restaurantService.Value.GetAll() on catemapping.RestaurantId
            equals Res.ID
            select new RestaurantCategorymappingVm

            {

                CreateDate = catemapping.CreatedDate,
                categoryName = catemaster.Name,
                RestaurantName = Res.Name


            };


            return View(list);
        }
        public ActionResult Create()
        {
            ViewBag.allres = restaurantService.Value.GetAll();
            ViewBag.allcate = categoryMasterService.Value.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(RestaurantCategoryMapping restaurantCategoryMapping)
        {
            categoryMappingService.Value.Add(restaurantCategoryMapping);
            categoryMappingService.Value.Save();
            return RedirectToAction("Index");
        }
    }
}