using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialViewTest()
        {
            return PartialView("Index");
        }
        public ActionResult FileTest(int? dl)
        {
            if (dl==1)
            {
                return File(Server.MapPath("/Image/Csgo.png"), "image/png", "CSGO封面.png");
            }
            else {
                return File(Server.MapPath("/Image/Csgo.png"), "image/png");
            }
                   
        }
        public JsonResult JsonTest(int id)
        {
            repoProduct.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;
            var product = repoProduct.Find(id);
            return Json(product,JsonRequestBehavior.AllowGet);
        }
    }
}