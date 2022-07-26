using CRUDUsingEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingEF.Data
{
    
    public class ProductDAL
    {
        ApplicationDbContext db;
        public ProductDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Product> GetAllProducts()
        {
            return db.Products.ToList();
            //public IEnumerable<Product> GetAllProducts()  if u wnat to use IEnumerable
            //{
            //    return from p in db.Products select p;
            //}

        }
        public Product GetProductById(int id)
        {
            Product p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            return p;
        }
        public int AddProduct(Product prod)
        {
            // add prod object in the produts collections
            db.Products.Add(prod);
            // reflect the change in DB
            int result = db.SaveChanges();
            return result;
        }
        public int UpdateProduct(Product prod) // new data
        {
            int result = 0;
            // p object hold old data
            Product p = db.Products.Where(x => x.Id == prod.Id).FirstOrDefault();
            if (p != null)
            {
                p.Name = prod.Name;
                p.Price = prod.Price;
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteProduct(int id)
        {
            int result = 0;
            Product p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            if (p != null)
            {
                db.Products.Remove(p);
                result = db.SaveChanges();
            }
            return result;
        }
    }


}
