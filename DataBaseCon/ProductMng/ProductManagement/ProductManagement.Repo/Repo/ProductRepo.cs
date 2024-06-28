using ProductManagement.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repo.Repo
{
    public class ProductRepo
    {
        private ProductDb1Context db;
        public ProductRepo(ProductDb1Context db1Context)
        {
            db = db1Context;
        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public List<Product> GetProductByCatId(int catId)
        {
            return db.Products.Where(p => p.CatId == catId).ToList();
        }

        public Product GetProductByPId(int productId)
        {
            return db.Products.Where(p => p.Id == productId).SingleOrDefault();
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DetachProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            
        }

        public void UpdateProduct(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
        }
    }
}
