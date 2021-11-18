using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperTest_Fruit_SA.Models;

namespace DeveloperTest_Fruit_SA.Repositories
{
   public interface ICatetogory :IDisposable
    {
        IEnumerable<Category> GetCategory();
        Category GeCategoryByID(int categoryId);
        void InsertCategory(Category category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category category);
        void Save();
    }
}

    

