using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BatchController : Controller
    {
        BATCH_MANAGEMENT_DBEntities db = new BATCH_MANAGEMENT_DBEntities();
        // GET: Batch
        public ActionResult See_All_Batch(string search)
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
                    var data = db.Database.SqlQuery<Batch_select>
                        ("SELECT B.COURSE_ID,B.BATCH_ID,A.COURSE_NAME,B.BATCH_NAME," +
                        "B.BATCH_DURATION,A.TEACHER_NAME FROM COURSE AS A JOIN BATCH " +
                        "AS B ON A.COURSE_ID = B.COURSE_ID ORDER BY A.COURSE_ID").ToList<Batch_select>().Where(model => model.BATCH_NAME.StartsWith(searchvalue)).ToList();
                    return View(data);
                }
                else
                {
                    var data = db.Database.SqlQuery<Batch_select>
                        ("SELECT B.COURSE_ID,B.BATCH_ID,A.COURSE_NAME,B.BATCH_NAME," +
                        "B.BATCH_DURATION,A.TEACHER_NAME FROM COURSE AS A JOIN BATCH " +
                        "AS B ON A.COURSE_ID = B.COURSE_ID ORDER BY A.COURSE_ID").ToList<Batch_select>();
                    return View(data);
                }
            }
        }

        [HttpGet]
        public ActionResult AddBatch(int id)
        {
            //var data = db.Database.SqlQuery<BATCH>("select course_id from course where course_id = " + id);
            //BATCH obj = new BATCH();
            //obj.COURSE_ID = id;
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddBatch(BATCH bATCH)
        {
            if(ModelState.IsValid == true)
            {
                db.BATCH_ADD_SP(bATCH.COURSE_ID, bATCH.BATCH_ID, bATCH.BATCH_NAME, bATCH.BATCH_DURATION);
                return RedirectToAction("See_All_Batch", "Batch");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit_Batch(int id)
        {
            var data = db.Database.SqlQuery<BATCH>("SELECT * FROM BATCH WHERE BATCH_ID = " + id);
            return View(data.FirstOrDefault<BATCH>());
        }
        [HttpPost]
        public ActionResult Edit_Batch(BATCH bATCH)
        {
            if(ModelState.IsValid == true)
            {
                db.BATCH_UPDATE_SP(bATCH.BATCH_ID,bATCH.BATCH_NAME,bATCH.BATCH_DURATION);
                return RedirectToAction("See_All_Batch", "Batch");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete_Batch(int id)
        {
            var data = db.Database.SqlQuery<BATCH>("SELECT * FROM BATCH WHERE BATCH_ID = " + id);
            return View(data.FirstOrDefault<BATCH>());
        }
        [HttpPost]
        public ActionResult Delete_Batch(string id)
        {
            if(ModelState.IsValid == true)
            {
                db.BATCH_DELETE_SP(int.Parse(id));
                return RedirectToAction("See_All_Batch", "Batch");
            }
            return View();
        }

        [HttpGet]
        public ActionResult SeeBatch(int id)
        {
            var no_of_batch = db.Database.SqlQuery<BATCH>("select * from batch where course_id = " + id);

            ViewBag.no_of_batch_present = no_of_batch.Count() + " no of batches are continued!";

            var data = db.SEE_SPECIFIC_BATCHES(id);
            return View(data);
        }
    }
}