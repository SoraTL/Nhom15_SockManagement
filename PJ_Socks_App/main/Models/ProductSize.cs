using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Models
{
    [Table(Name = "Product_Size")]
    public class ProductSize
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public int ProductId { get; set; }

        [Column]
        public int SizeId { get; set; }

        private EntityRef<Product> _product;

        [Association(Storage = "_product", ThisKey = "ProductId", OtherKey = "Id", IsForeignKey = true)]
        public Product Product
        {
            get { return this._product.Entity; }
            set { this._product.Entity = value; }
        }

        private EntityRef<Size> _size;

        [Association(Storage = "_size", ThisKey = "SizeId", OtherKey = "Id", IsForeignKey = true)]
        public Size Size
        {
            get { return this._size.Entity; }
            set { this._size.Entity = value; }
        }
    }
}
