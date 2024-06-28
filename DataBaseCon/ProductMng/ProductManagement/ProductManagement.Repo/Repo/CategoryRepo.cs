using ProductManagement.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repo.Repo
{
    public class CategoryRepo
    {
        private ProductDb1Context db;
        public CategoryRepo(ProductDb1Context db1Context)
        {
            db = db1Context;
        }

        public IEnumerable<Category> GetCategories()
        {
                return db.Categories.ToList();
        }

        public Category GetCategories(int id)
        {
            using (ProductDb1Context db = new ProductDb1Context())
            {
                return db.Categories.FirstOrDefault(c => c.Id == id);
            }
        }
    }
}
