using RestaurantFinder.BusinessLogic.Interface;
using RestaurantFinder.Models;
using RestaurantFinder.Repository;
using RestaurantFinder.WebUI.Common.logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;

namespace RestaurantFinder.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly Lazy<IUsersService> usersService;
        private readonly Lazy<ICategoryMasterService> categoryMaster;
        private readonly Lazy<IUserRolesService>userRolesService;
        private readonly Lazy<IHomeBannerImageService> homeBannerImageService;


        private readonly Lazy<IRestaurantService> restaurantService;

        private readonly Lazy<ILoggerFacade<LoginController>> logger;

        public LoginController(Lazy<IUsersService> usersService,
            Lazy<IUserRolesService> userRolesService,
             Lazy<IHomeBannerImageService> homeBannerImageService,
            Lazy<ICategoryMasterService> categoryMaster,
            Lazy<IRestaurantService> restaurantService,
            Lazy<ILoggerFacade<LoginController>> logger)
        {
            this.usersService = usersService;
            this.userRolesService = userRolesService;
            this.categoryMaster = categoryMaster;
            this.homeBannerImageService = homeBannerImageService;
            this.restaurantService = restaurantService;
            this.logger = logger;
        }


        public ActionResult Login()
        {
            




            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {


            string username = fc["username"];
            string Password = fc["Password"];

            if (usersService.Value.Checklogin(username, Password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                Session["name"] = fc["username"];
                string name =Convert.ToString( Session["name"]);
                int id = usersService.Value.userid(name);
                //check Restaurant list login user
                var list = restaurantService.Value.GetAll().Where(x => x.UserId == id).ToList();
                //if(User.IsInRole("Admin"))
                //{

                //    return View("DashBoardAdmin");
                //}

       
                //if user found then if work

              if (list.Count()>0 /*&& User.IsInRole("Owner")*/)
                {
                    return RedirectToAction("DashBoard", "Login");

                }
                 if(list.Count() == 0 /*&& User.IsInRole("Owner")*/)

                {
                    return RedirectToAction("Create", "Restaurant");
                   
                

                }

            }
           
            ViewBag.errorMsg = "Please Check UserName And Password";
            return View();


        }
        public ActionResult AdminLogin()

        {
            return View();
           
        }
        [HttpPost]
        public ActionResult AdminLogin(FormCollection fc)

        {

            string username = fc["username"];
            string Password = fc["Password"];

            if (usersService.Value.Checklogin(username, Password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                Session["name"] = fc["username"];
                string name = User.Identity.Name;
                int id = usersService.Value.userid(name);
                //check Restaurant list login user
                var list = restaurantService.Value.GetAll().Where(x => x.UserId == id).ToList();


                if (Roles.IsUserInRole("Admin"))
                {

                    //if user found then if work
                    return RedirectToAction("DashBoardAdmin", "Login");
                }
            }
            ViewBag.errorMsg = "Please Check UserName And Password";
            return View();


        }
       
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Signup(User user)
        {
           
               
           
            try

            {
                user.CreatedOn= DateTime.Now;
               


                int id =  usersService.Value.Insert(user);
               
                UserRole userRole = new UserRole();
                userRole.RoleID= 2;
                userRole.UserID = id;
                userRole.CreatedBy="System";
                userRole.UniqueId = new Guid();
                userRolesService.Value.Add(userRole);
                userRolesService.Value.Save();
                BuildEmailTemplate(id);



            }
            catch {

                return View();

            }
            

            return View();
        }
        public ActionResult ChangePassword(int regId)
        {
         var list=   usersService.Value.GetAll().Where(x=>x.ID==regId).SingleOrDefault();

            return View(list);
        }
        [HttpPost]
        public ActionResult ChangePassword(User user)
        {
           this.usersService.Value.Edit(user);
           this.usersService.Value.Save();

            return RedirectToAction("/Login");
        }
        public void BuildEmailTemplate(int regID)
        {
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "Text" + ".cshtml");
            var regInfo = usersService.Value.GetAll().Where(x => x.ID == regID).FirstOrDefault();
            var url = "https://localhost:44379/"+ "Login/ChangePassword?regId=" + regID;
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate("Your Account Is Successfully Created", body, regInfo.Email);
        }
        public static void BuildEmailTemplate(string subjectText, string bodyText, string sendTo)
        {
            string from, to, bcc, cc, subject, body;
            from = sendTo;
            to = sendTo.Trim();
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }

        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("umairshahbaz44@gmail.com","03244506847");
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult LockScreen()
        {
            return View();
        }
        public ActionResult ResetPassword()
        {
            return View();
        }
        public ActionResult DashBoard()
        {
            return View();
        }public ActionResult DashBoardAdmin()
        {
            ViewBag.totalCategory =categoryMaster.Value.GetAll().Count();
            ViewBag.TotalRestaurant =restaurantService.Value.GetAll().Count();
            ViewBag.User = usersService.Value.GetAll().Count();
            ViewBag.banner = homeBannerImageService.Value.GetAll().Count();
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
          
        }
        public ActionResult checkmail()
        {
            return View();

        }

    }
}