using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperTest_Fruit_SA.Repositories;
using DeveloperTest_Fruit_SA.Models;
using DeveloperTest_Fruit_SA.Database;
using System.Data;
using PagedList;

namespace DeveloperTest_Fruit_SA.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _productRepository;
        
        public ProductController(  )
        {
            _productRepository = new ProductRepo(new Db());
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = from Product in _productRepository.GetProducts()
                           select Product;
            return View(products);
        }
        public ViewResult Details(int id)
        {
            Product product = _productRepository.GetProductByID(id);
            return View(product);
        }
        public ActionResult Create()
        {
            return View(new Product());

        }
        public ActionResult ProductList(int? page, int? pageSize)
        {

            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            int defaSize = (pageSize ?? 10);

            ViewBag.psize = defaSize;
            ViewBag.PageSize = new List<SelectListItem>()
    {
        new SelectListItem() { Value="5", Text= "5" },
        new SelectListItem() { Value="10", Text= "10" },
        new SelectListItem() { Value="15", Text= "15" },
        new SelectListItem() { Value="25", Text= "25" },
        new SelectListItem() { Value="50", Text= "50" },
     };

         Db   db = new Db();
            IPagedList<Product> productsLst = null;
            productsLst = db.Products.OrderBy(x => x.id).ToPagedList(pageIndex, defaSize);


            return View(productsLst);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(product.imageFile.FileName);
                    string extension = System.IO.Path.GetExtension(product.imageFile.FileName);
                    product.image = "../Files" + fileName;
                    fileName = System.IO.Path.Combine(Server.MapPath("../Files/"), fileName);
                    product.imageFile.SaveAs(fileName);
                    using (Db db = new Db())

                        _productRepository.InsertProduct(product);
                    _productRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            Product product = _productRepository.GetProductByID(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productRepository.UpdateProduct(product);
                    _productRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(product);
        }
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Product product = _productRepository.GetProductByID(id);
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Product product = _productRepository.GetProductByID(id);
                _productRepository.DeleteProduct(id);
                _productRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}