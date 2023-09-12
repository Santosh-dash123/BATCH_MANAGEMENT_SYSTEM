using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        BATCH_MANAGEMENT_DBEntities db = new BATCH_MANAGEMENT_DBEntities();

        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string name,string email,string message)
        {
            int value = db.ADD_USER_MESSAGE(name, email, message);
            if(value != 0)
            {
                ViewBag.SuccessMessage = "<script>alert('Message send successfully !');</script>";
                return View();
            }
            else
            {
                ViewBag.FailureMessage = "<script>alert('Message can't send to destination!');</script>";
                return View();
            }
        }

        [HttpGet]
        // GET: Login
        public ActionResult Login_Page()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login_Page(REGISTRATION_SELECT_SP_Result data)
        {
            if(ModelState.IsValid == true)
            {
                var credentials = db.REGISTRATION_SELECT_SP().Where(model => model.USER_NAME == data.USER_NAME.ToUpper() && model.USER_PASSWORD == data.USER_PASSWORD.ToUpper()).FirstOrDefault();

                if(credentials == null)
                {
                    ViewBag.FailureMessage = "Invalid Credentials !";
                    return View();
                }
                else
                {
                    Session["UserName"] = "Welcome " + data.USER_NAME.ToUpper();
                    ModelState.Clear();
                    return RedirectToAction("Course_List", "Course");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Add_User()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_User(Add_User user_data)
        {
            if(ModelState.IsValid == true)
            {
                db.REGISTRATION_ADD_SP(user_data.UserName,user_data.Password,user_data.Email,decimal.Parse(user_data.PhoneNumber));
                ViewBag.SuccessMessage = "<script>alert('User added successfully!');</script>";
                return RedirectToAction("Login_Page", "Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["UserName"] = null;
            Session.Abandon();
            return RedirectToAction("Login_Page", "Login");
        }
    }
}