using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YC.Database;

namespace YC.Web.Controllers
{
    public class OpenDataController : Controller
    {
        OpenData_DbContext db = new OpenData_DbContext();
        // GET: OpenData
        public ActionResult Index()
        {
            
            var models = db.OpenDatas
                .ToList();
            return View(models);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var model = db.OpenDatas.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(string id,YC.Models.OpenData input)
        {
            var model = db.OpenDatas.Find(id);
            model.下載連結 = input.下載連結;
            model.服務分類 = input.服務分類;
            model.資料集名稱 = input.資料集名稱;
            model.資料集描述 = input.資料集描述;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var model = db.OpenDatas.Find(id);
            //db.OpenDatas.Remove(model);
            //db.SaveChanges();
            return View(model);

        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DoDelete(string id)
        {
            var model = db.OpenDatas.Find(id);
            db.OpenDatas.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}