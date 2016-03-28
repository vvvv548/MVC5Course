using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : BaseController
    {
        FabricsEntities db = new FabricsEntities();
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EDE()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EDE(EDEViewModel data)
        {
            return View(data);
        }
        public ActionResult CreateProduct()
        {            

            var product = new Product()
            {
                ProductName = "Dazzle",
                Active = true,
                Price = 20000,
                Stock = 10
            };
            
            db.Product.Add(product);
            db.SaveChanges();
            return View(product);
        }

        public ActionResult ReadProduct(bool? Active)
        {
            var data = db.Product.OrderByDescending(p => p.Price).AsQueryable();
            data = data
                .Where(p => p.ProductId > 1550);

            if (Active.HasValue)
            {
                data = data.Where(p => p.Active == Active);
            }
                

            return View(data);
        }
        public ActionResult OneProduct(int id)
        {
            var data = db.Product.Where(p => p.ProductId == id).FirstOrDefault();
            return View(data);

        }

        public ActionResult UpdateProduct(int id)
        {
            var onedata = db.Product.FirstOrDefault(p => p.ProductId == id);
            if (onedata == null)
            {
                return HttpNotFound();
            }
            onedata.Price = onedata.Price * 2;
            
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityError in ex.EntityValidationErrors)
                {
                    foreach (var error in entityError.ValidationErrors)
                    {
                        return Content(error.PropertyName + " : " + error.ErrorMessage);
                    }
                }                
            }

            return RedirectToAction("ReadProduct");
        }
        public ActionResult Delete(int id)
        {
            var data = db.Product.FirstOrDefault(p => p.ProductId == id);
            
            db.OrderLine.RemoveRange(data.OrderLine);
            db.Product.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ReadProduct");
        }
        public ActionResult ProductView()
        {
            //改善迴圈執行單筆刪除
            //db.Database.ExecuteSqlCommand(@"SELECT * FROM dbo.Product WHERE Active =@p0 AND
            //      ProductName like @p1", true, "%Yellow%");

            
            var data = db.Database.SqlQuery<ProductViewModel>(
                @"SELECT * FROM dbo.Product WHERE Active =@p0 AND
                  ProductName like @p1", true, "%Yellow%");
            return View(data);
        }
        public ActionResult ProductSP()
        {
            var data =db.GetProduct(true, "%Yellow%");
            return View(data);
        }
    }
}