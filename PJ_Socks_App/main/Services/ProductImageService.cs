using PJ_Socks_App.main.Models;
using PJ_Socks_App.main.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Services
{
    public class ProductImageService
    {
        private readonly ProductImageRepository productImageRepository;

        public ProductImageService()
        {
            productImageRepository = new ProductImageRepository();
        }

        public ProductImage GetImage(int id)
        {
            return productImageRepository.GetImage(id);
        }

        public void insert(ProductImage productImage)
        {
            productImageRepository.insert(productImage);
        }

    }
}
