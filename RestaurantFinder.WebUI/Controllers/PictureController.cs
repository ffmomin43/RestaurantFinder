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
    public class PictureController : Controller
    {
         
        private readonly Lazy<IPictureService> pictureService;
        private readonly Lazy<ILoggerFacade<PictureController>> logger;

        public PictureController(Lazy<IPictureService> pictureService, Lazy<ILoggerFacade<PictureController>> logger)
        {
            this.pictureService = pictureService;
            this.logger = logger;
        }

        public JsonResult UploadPicture()
        {   
            JsonResult Result = new JsonResult();
            List<object> pictureresult = new List<object>();
            var picturess = Request.Files;
            for (int i = 0; i < picturess.Count; i++)
            {
                var pic = picturess[i];
                var picname = Guid.NewGuid() + Path.GetExtension(pic.FileName);
                var path = Server.MapPath("~/Images/Restaurant/") + picname;
                pic.SaveAs(path);
                var dbpic = new Picture();
                dbpic.url = picname;
                int picid =pictureService.Value.inserted(dbpic);

                pictureresult.Add(new { Id = picid, Urlpic = picname });
            }
            Result.Data = pictureresult;
            return Result;
        }
    }
}