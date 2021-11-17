using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperTest_Fruit_SA.Models;

namespace DeveloperTest_Fruit_SA.Repositories
{
   public interface IProduct : IDisposable
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int productId); 
        void InsertProduct(Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(Product product);
        void Save();
    }
}
