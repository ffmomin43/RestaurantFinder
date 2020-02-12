using RestaurantFinder.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantFinder.WebUI.Controllers
{
    public class HomeBannerImagesController : Controller
    {
        private readonly Lazy<IHomeBannerImageService> homeBannerImageService;

        public HomeBannerImagesController(
           Lazy<IHomeBannerImageService> homeBannerImageService
            )
        {
            this.homeBannerImageService =homeBannerImageService;
        }
        // GET: HomeBannerImages
        public ActionResult Index()
        {
            var Banner = homeBannerImageService.Value.GetAll();
            return View(Banner);
        }

        // GET: HomeBannerImages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeBannerImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeBannerImages/Create
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

        // GET: HomeBannerImages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeBannerImages/Edit/5
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

        // GET: HomeBannerImages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeBannerImages/Delete/5
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
