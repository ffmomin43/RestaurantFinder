using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Create(HomeBannerImage homeBannerImage)
        {
            try
            {
                if (homeBannerImage.imagefile != null)
                {
                    homeBannerImage.UniqueId = Guid.NewGuid();
                    homeBannerImage.CreatedBy = "System";
                    string filename = Path.GetFileNameWithoutExtension(homeBannerImage.imagefile.FileName);
                    string extentsion = Path.GetExtension(homeBannerImage.imagefile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extentsion;
                    homeBannerImage.Url = "/Images/RestaurantBanners/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/RestaurantBanners/"), filename);
                    homeBannerImage.imagefile.SaveAs(filename);



                    this.homeBannerImageService.Value.Add(homeBannerImage);
                    this.homeBannerImageService.Value.Save();
                }
                
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
         var list=   homeBannerImageService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();
            return View(list);
        }

        // POST: HomeBannerImages/Edit/5
        [HttpPost]
        public ActionResult Edit(HomeBannerImage homeBannerImage)
        {
            try
            {
                if (homeBannerImage.imagefile != null)
                {
                    homeBannerImage.UniqueId = Guid.NewGuid();
                    homeBannerImage.UpdatedDate = DateTime.Now;
                    homeBannerImage.UpdatedBy = "System";
                    string filename = Path.GetFileNameWithoutExtension(homeBannerImage.imagefile.FileName);
                    string extentsion = Path.GetExtension(homeBannerImage.imagefile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extentsion;
                    homeBannerImage.Url = "/Images/RestaurantBanners/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/RestaurantBanners/"), filename);
                    homeBannerImage.imagefile.SaveAs(filename);



                    this.homeBannerImageService.Value.Edit(homeBannerImage);
                    this.homeBannerImageService.Value.Save();
                }


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
          var list=  homeBannerImageService.Value.GetAll().Where(x => x.ID == id).SingleOrDefault();
            return View(list);
        }

        // POST: HomeBannerImages/Delete/5
        [HttpPost]
        public ActionResult Delete(HomeBannerImage homeBannerImage)
        {
            try
            {
                homeBannerImageService.Value.Delete(homeBannerImage);
                homeBannerImageService.Value.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
