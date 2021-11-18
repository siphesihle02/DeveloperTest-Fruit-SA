using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperTest_Fruit_SA.Models;
using DeveloperTest_Fruit_SA.Database;
using DeveloperTest_Fruit_SA.Repositories;
using System.Data;

namespace DeveloperTest_Fruit_SA.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepo(new Db());
        }
        // GET: Product
        public ActionResult Index()
        {
            var category = from Category in _categoryRepository.GetCategory()
                           select Category;
            return View(category);
        }
        public ViewResult Details(int id)
        {
            Category category  = _categoryRepository.GetCategoryByID(id);
            return View(category);
        }
        public ActionResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryRepository.InsertCategory(category);
                    _categoryRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            Category category = _categoryRepository.GetCategoryByID(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryRepository.UpdateCategory(category);
                    _categoryRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(category);
        }
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Category category = _categoryRepository.GetCategoryByID(id);
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Category category = _categoryRepository.GetCategoryByID(id);
                _categoryRepository.DeleteCategory(id);
                _categoryRepository.Save();
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
        // GET: Category
       
    }
}