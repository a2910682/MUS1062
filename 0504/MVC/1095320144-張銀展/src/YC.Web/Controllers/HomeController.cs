using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YC.Database;

namespace YC.Web.Controllers
{
    public class HomeController : Controller
    {
        private YC.Repository.IRepository _rep;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string id)
        {
            ViewBag.Message = "Your application description page.";
            OpenData_DbContext db = new OpenData_DbContext();
            var model=db.OpenDatas.ToList();
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ImportDB()
        {
            _rep = new YC.Repository.OpenDataRepository();
            var datas = _rep.FindFromOpenData();
            datas.ToList().ForEach(x =>
            {
                _rep.Create(x);
            });
            return Content("OK");
        }
    }
}