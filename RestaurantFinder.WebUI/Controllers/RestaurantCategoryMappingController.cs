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
            var list = from catemapping in categoryMappingService.Value.GetAll()
                       join catemaster in categoryMasterService.Value.GetAll()
                       on catemapping.CategoryId equals catemaster.ID
                       join Res in restaurantService.Value.GetAll() on catemapping.RestaurantId
                       equals Res.ID
                       select new RestaurantCategorymappingVm

                       {
                           id = catemapping.ID,
                           CreateDate = catemapping.CreatedDate,
                           categoryName = catemaster.Name,
                           RestaurantName = Res.Name


                       };


            return View(list);
        }
        public ActionResult Create()
        {


            ViewBag.cate = categoryMasterService.Value.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection fc,int ? Resid)
        {
            if(fc.Count>0)
            { 
            string[] ids = fc["CategoryId"].Split(',');
           
            foreach (var item in ids)
            {

                RestaurantCategoryMapping restaurantCategoryMapping = new RestaurantCategoryMapping();
                restaurantCategoryMapping.RestaurantId = Convert.ToInt32(Resid);
                restaurantCategoryMapping.UniqueId = new Guid();
                restaurantCategoryMapping.CategoryId =Convert.ToInt32(item);
                restaurantCategoryMapping.UniqueId = new Guid();
                categoryMappingService.Value.Add(restaurantCategoryMapping);
                categoryMappingService.Value.Save();


            }
            }
            else


            {

                RestaurantCategoryMapping restaurantCategoryMapping = new RestaurantCategoryMapping();
                restaurantCategoryMapping.RestaurantId = Convert.ToInt32(Resid);
                restaurantCategoryMapping.UniqueId = new Guid();
                
                restaurantCategoryMapping.UniqueId = new Guid();
                categoryMappingService.Value.Add(restaurantCategoryMapping);
                categoryMappingService.Value.Save();
            }
            return RedirectToAction("Index","Restaurant");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.allres = restaurantService.Value.GetAll();
            ViewBag.allcate = categoryMasterService.Value.GetAll();
            var list = categoryMappingService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();
            return View(list);





        }
        [HttpPost]
        public ActionResult Edit(RestaurantCategoryMapping restaurantCategoryMapping)
        {
            restaurantCategoryMapping.UpdatedDate = DateTime.Now;
            restaurantCategoryMapping.UpdatedBy = "system";
            categoryMappingService.Value.Edit(restaurantCategoryMapping);
            categoryMappingService.Value.Save();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var list = categoryMappingService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();

            return View(list);
        }

        [HttpPost]
        public ActionResult Delete(RestaurantCategoryMapping restaurantCategoryMapping)
        {
            categoryMappingService.Value.Delete(restaurantCategoryMapping);
            categoryMappingService.Value.Save();
            return RedirectToAction("Index");

        }
    }
}