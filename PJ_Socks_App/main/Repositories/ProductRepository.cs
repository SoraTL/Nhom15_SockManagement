using PJ_Socks_App.main.DBContext;
using PJ_Socks_App.main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Repositories
{
    public class ProductRepository
    {
        private readonly SockSalesDataContext context;

        public ProductRepository()
        {
            context = SockSalesDataContext.GetInstance();
        }

        public List<Product> getAll()
        {
            var products = context.Products.ToList();
            return products;
        }

        public Product getProduct(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public void insert(Product product)
        {
            context.Products.InsertOnSubmit(product);
            context.SubmitChanges();
        }

        public void updateDescription(int productId,  string description)
        {
            var product = getProduct(productId);
            product.Description = description;
            context.SubmitChanges();
        }
    }
}
