using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperTest_Fruit_SA.Models;
using DeveloperTest_Fruit_SA.Database;
using System.Data.Entity;

namespace DeveloperTest_Fruit_SA.Repositories
{
    public class ProductRepo :IProduct
    {
        private Db _context;
        public ProductRepo(Db db)
        {
            this._context = db;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetProductByID(int id)
        {
            return _context.Products.Find(id);
        }
        public void InsertProduct(Product product)
        {
            _context.Products.Add(product);
        }
        public void DeleteProduct(int productID)
        {
            Product product = _context.Products.Find(productID);
            _context.Products.Remove(product);
        }
        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
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