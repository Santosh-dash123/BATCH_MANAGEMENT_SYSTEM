using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        BATCH_MANAGEMENT_DBEntities db = new BATCH_MANAGEMENT_DBEntities();
        // GET: Student
        public ActionResult See_All_Student(string search)
        {
            if (@Session["UserName"] == null)
            {
                return RedirectToAction("Login_Page", "Login");
            }
            else
            {
                if(search != null)
                {
                    string searchvalue = search.ToUpper().Trim();
                    var data = db.Database.SqlQuery<Student_select>
                        ("SELECT B.BATCH_ID,B.BATCH_NAME,S.STUDENT_ID," +
                        "S.STUDENT_NAME,S.STUDENT_AGE,S.STUDENT_EMAILID " +
                        "FROM BATCH AS B JOIN STUDENT AS S ON B.BATCH_ID =" +
                        " S.BATCH_ID ORDER BY BATCH_ID").Where(model => model.STUDENT_NAME.StartsWith(searchvalue)).ToList();
                    return View(data);
                }
                else
                {
                    var data = db.Database.SqlQuery<Student_select>
                        ("SELECT B.BATCH_ID,B.BATCH_NAME,S.STUDENT_ID," +
                        "S.STUDENT_NAME,S.STUDENT_AGE,S.STUDENT_EMAILID " +
                        "FROM BATCH AS B JOIN STUDENT AS S ON B.BATCH_ID =" +
                        " S.BATCH_ID ORDER BY BATCH_ID");
                    return View(data);
                }
            }
        }

        [HttpGet]
        public ActionResult AddStudent(int id)
        {
            ViewBag.id = id;
            var collection = db.Database.SqlQuery<Batch_select>("SELECT B.COURSE_ID,B.BATCH_ID,A.COURSE_NAME,B.BATCH_NAME,B.BATCH_DURATION,A.TEACHER_NAME FROM COURSE AS A JOIN BATCH AS B ON A.COURSE_ID = B.COURSE_ID ORDER BY A.COURSE_ID").ToList<Batch_select>();
            ViewBag.course_name = collection.Where(obj => obj.BATCH_ID == id).SingleOrDefault()?.COURSE_NAME;
            ViewBag.batch_name = collection.Where(obj => obj.BATCH_ID == id).SingleOrDefault()?.BATCH_NAME;
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(STUDENT student)
        {
            if(ModelState.IsValid == true)
            {
                var no_of_student = db.Database.SqlQuery<STUDENT>("select * from student where batch_id = " + student.BATCH_ID);
                
                int no_of_student_present = no_of_student.Count();
                
                if(10 > no_of_student_present)
                {
                    db.STUDENT_ADD_SP(student.BATCH_ID, student.STUDENT_ID, student.STUDENT_NAME, student.STUDENT_AGE, student.STUDENT_EMAILID);
                    return View("See_All_Student");
                }
                else
                {
                    TempData["Message"] = "<script>alert('YOU CAN NOT ADD MORE THAN 10 STUDENT IN A BATCH!')</script>";
                    return RedirectToAction("See_All_Batch","Batch");
                }   
            }
            return RedirectToAction("See_All_Batch", "Batch");
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var data = db.Database.SqlQuery<STUDENT>("SELECT * FROM STUDENT WHERE STUDENT_ID = " + id);
            var collection = db.Database.SqlQuery<Edit_student>("SELECT B.BATCH_NAME,S.STUDENT_ID FROM BATCH AS B JOIN STUDENT AS S ON B.BATCH_ID = S.BATCH_ID");
            ViewBag.batch_name = collection.Where(obj => obj.STUDENT_ID == id).SingleOrDefault()?.BATCH_NAME;
            return View(data.FirstOrDefault<STUDENT>());
        }
        [HttpPost]
        public ActionResult EditStudent(STUDENT student)
        {
            if(ModelState.IsValid == true)
            {
                db.STUDENT_UPDATE_SP(student.STUDENT_ID, student.STUDENT_NAME, student.STUDENT_AGE, student.STUDENT_EMAILID);
               
                return RedirectToAction("See_All_Student", "Student");
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var data = db.Database.SqlQuery<STUDENT>("SELECT * FROM STUDENT WHERE STUDENT_ID = " + id);
            return View(data.FirstOrDefault<STUDENT>());
        }
        [HttpPost]
        public ActionResult DeleteStudent(string id)
        {
            if(ModelState.IsValid == true)
            {
                db.STUDENT_DELETE_SP(int.Parse(id));
                return RedirectToAction("See_All_Student", "Student");
            }
            return View();
        }

        [HttpGet]
        public ActionResult SeeStudent(int id)
        {
            var no_of_student = db.Database.SqlQuery<STUDENT>("select * from student where batch_id = " + id);

            ViewBag.no_of_student_present = no_of_student.Count() + " no of students are enrolled in that batch !";

            //var data = db.Database.SqlQuery<SEE_SPECIFIC_STUDENTS_Result>("SELECT * FROM STUDENT WHERE BATCH_ID = " + id);
            var data = db.SEE_SPECIFIC_STUDENTS(id);
            return View(data);
        }
    }
}