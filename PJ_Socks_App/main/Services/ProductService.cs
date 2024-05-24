using PJ_Socks_App.main.Models;
using PJ_Socks_App.main.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Services
{
    public class ProductService
    {
        private readonly ProductRepository productRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public List<Product> getAll()
        {
            var products = productRepository.getAll();
            return products;
        } 

        public Product getProduct(int id)
        {
            return productRepository.getProduct(id);
        }

        public void insert(Product product)
        {
            productRepository.insert(product);
        }

        public void updateDescription(int productId, string description)
        {
            productRepository.updateDescription(productId, description);
        }

    }
}
