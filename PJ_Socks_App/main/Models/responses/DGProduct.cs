using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Models.responses
{
    public class DGProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Inventory { get; set; }

        public decimal Price { get; set; }

        public string Color { get; set; }

        public string Design { get; set; }


        public static List<DGProduct> convert(List<Product> products)
        {
            List<DGProduct> result = new List<DGProduct>();

            foreach (Product product in products)
            {
                DGProduct d = new DGProduct()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Color = product.Color,
                    Design = product.Design,
                    Inventory = product.Inventory,
                    Price = product.Price
                };

                result.Add(d);
            }

            return result;
        }

    }
}
