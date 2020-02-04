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
    public class CategoryMasterController : Controller
    {
        private readonly Lazy<ICategoryMasterService> categoryMasterService;

        public CategoryMasterController(
            Lazy<ICategoryMasterService> categoryMasterService
            )
        {
            this.categoryMasterService = categoryMasterService;
        }

        // GET: CategoryMaster
        public ActionResult Index()
        {
            var model = this.categoryMasterService.Value.GetAll();
            return View(model);
        }

        // GET: CategoryMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryMaster/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CategoryMaster/Create
        [HttpPost]
        public ActionResult Create(CategoryMaster categoryMaster)
        {
            try
            {
                // TODO: Add insert logic here
               
                

                if (categoryMaster.imagefile != null)
                {
                    categoryMaster.UniqueId = Guid.NewGuid();
                    categoryMaster.CreatedBy = "System";
                    string filename = Path.GetFileNameWithoutExtension(categoryMaster.imagefile.FileName);
                    string extentsion = Path.GetExtension(categoryMaster.imagefile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extentsion;
                    categoryMaster.ThumbnailImageUrl = "/Images/categories/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/categories/"), filename);
                    categoryMaster.imagefile.SaveAs(filename);
                    


                    this.categoryMasterService.Value.Add(categoryMaster);
                    this.categoryMasterService.Value.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryMaster/Edit/5
        public ActionResult Edit(int id)
        {
           var CategoryMaster=categoryMasterService.Value.GetAll().Where(x=>x.ID==id).SingleOrDefault();
            return View(CategoryMaster);
        }

        // POST: CategoryMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryMaster categoryMaster)
        {
            try
            {

                if (categoryMaster.imagefile != null)
                {
                    categoryMaster.UniqueId = Guid.NewGuid();
                    categoryMaster.CreatedBy = "System";
                    string filename = Path.GetFileNameWithoutExtension(categoryMaster.imagefile.FileName);
                    string extentsion = Path.GetExtension(categoryMaster.imagefile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extentsion;
                    categoryMaster.ThumbnailImageUrl = "/Images/categories/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/categories/"), filename);
                    categoryMaster.imagefile.SaveAs(filename);



                    this.categoryMasterService.Value.Edit(categoryMaster);
                    this.categoryMasterService.Value.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryMaster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryMaster/Delete/5
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
