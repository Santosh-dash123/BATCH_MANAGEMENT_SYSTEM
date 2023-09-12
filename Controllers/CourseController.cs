using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        BATCH_MANAGEMENT_DBEntities db = new BATCH_MANAGEMENT_DBEntities();
        // GET: Course
        [HttpGet]
        public ActionResult Course_List(string searchby,string search)
        {
            if(@Session["UserName"] == null)
            {
                return RedirectToAction("Login_Page", "Login");
            }
            else
            {
                if(searchby == "coursename")
                {
                    string searchvalue = search.ToUpper().Trim();
                    var data = db.COURSE_SELECT_SP().Where(model => model.COURSE_NAME.StartsWith(searchvalue)).ToList();
                    return View(data);
                }
                else if(searchby == "teachername")
                {
                    string searchvalue = search.ToUpper().Trim();
                    var data = db.COURSE_SELECT_SP().Where(model => model.TEACHER_NAME.StartsWith(searchvalue)).ToList();
                    return View(data);
                }
                else
                {
                    return View(db.COURSE_SELECT_SP());
                }
            }

        }

        [HttpGet]
        public ActionResult Add_Course()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Course(COURSE course)
        {
            if(ModelState.IsValid == true)
            {
                db.COURSE_ADD_SP(course.COURSE_ID, course.COURSE_NAME, course.TEACHER_NAME);
                return RedirectToAction("Course_List","COURSE");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit_Course(int id)
        {
            var data = db.Database.SqlQuery<COURSE>("SELECT * FROM COURSE WHERE COURSE_ID = " + id+";");
            return View(data.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit_Course(COURSE course)
        {
            if(ModelState.IsValid == true)
            {
                db.COURSE_UPDATE_SP(course.COURSE_ID, course.COURSE_NAME, course.TEACHER_NAME);
                return RedirectToAction("Course_List");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete_Course(int id)
        {
            var data = db.Database.SqlQuery<COURSE>("SELECT * FROM COURSE WHERE COURSE_ID = " + id + ";");
            return View(data.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete_Course(string id)
        {
            if(ModelState.IsValid == true)
            {
                db.COURSE_DELETE_SP(int.Parse(id));
                return RedirectToAction("Course_List");
            }
            return View();
        }
    }
}