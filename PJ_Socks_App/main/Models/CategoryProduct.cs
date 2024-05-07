using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Models
{
    [Table(Name = "Category_Product")]
    public class CategoryProduct
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public int CategoryId { get; set; }

        [Column]
        public int ProductId { get; set; }

        private EntityRef<Category> _category;

        [Association(Storage = "_category", ThisKey = "CategoryId", OtherKey = "Id", IsForeignKey = true)]
        public Category Category
        {
            get { return this._category.Entity; }
            set { this._category.Entity = value; }
        }

        private EntityRef<Product> _product;

        [Association(Storage = "_product", ThisKey = "ProductId", OtherKey = "Id", IsForeignKey = true)]
        public Product Product
        {
            get { return this._product.Entity; }
            set { this._product.Entity = value; }
        }
    }
}
