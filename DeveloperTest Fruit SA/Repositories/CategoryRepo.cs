using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperTest_Fruit_SA.Models;
using DeveloperTest_Fruit_SA.Database;
using System.Data.Entity;

namespace DeveloperTest_Fruit_SA.Repositories
{
    public class CategoryRepo :ICategory
    {
        private Db _context;
        public CategoryRepo(Db db)
        {
            this._context = db;
        }
        public IEnumerable<Category> GetCategory()
        {
            return _context.Categories.ToList();
        }
        public Category GetCategoryByID(int id)
        {
            return _context.Categories.Find(id);
        }
        public void InsertCategory( Category category)
        {
            _context.Categories.Add(category);
        }
        public void DeleteCategory(int categoryID)
        {
            Category category = _context.Categories.Find(categoryID);
            _context.Categories.Remove(category);
        }
        public void UpdateCategory(Category category)
        {
            _context.Entry(category
                ).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}