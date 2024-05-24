using PJ_Socks_App.main.DBContext;
using PJ_Socks_App.main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PJ_Socks_App.main.Repositories
{
    public class ProductImageRepository
    {
        private readonly SockSalesDataContext context;

        public ProductImageRepository()
        {
            context = SockSalesDataContext.GetInstance();
        }

        public ProductImage GetImage(int id)
        {

            var image = context.ProductImages.FirstOrDefault(x => x.Id == id);

            return image;

        }

        public void insert(ProductImage image)
        {
            var Image = GetImage(image.Id);
            
            if(Image == null)
            {
                context.ProductImages.InsertOnSubmit(image);
                context.SubmitChanges();
            }
            else
            {
                MessageBox.Show("Image is co");
            }
        }

        public ProductImage FindByProductId(int productId)
        {
            var image = context.ProductImages.FirstOrDefault(i => i.ProductId == productId);
            if(image != null)
            {
                return image;
            }
            return null;
        }

        public byte[] GetProductImage(int productId)
        {
            var image = context.ProductImages
                                .Where(pi => pi.ProductId == productId && pi.IsPrimary)
                                .Select(pi => pi.Image)
                                .FirstOrDefault();

            if (image == null)
            {
                throw new Exception("Image not found.");
            }

            return image;
        }

    }
}
