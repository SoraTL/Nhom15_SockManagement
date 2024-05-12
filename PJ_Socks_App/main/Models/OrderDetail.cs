using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Models
{
    [Table(Name = "OrderDetails")]
    public class OrderDetail
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public int OrderId { get; set; }

        [Column]
        public int ProductId { get; set; }

        [Column]
        public int Quantity { get; set; }

        [Column]
        public decimal Price { get; set; }

        [Column]
        public string Status { get; set; }

        private EntityRef<Order> _order;

        [Association(Storage = "_order", ThisKey = "OrderId", OtherKey = "Id", IsForeignKey = true)]
        public Order Order
        {
            get { return this._order.Entity; }
            set { this._order.Entity = value; }
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
