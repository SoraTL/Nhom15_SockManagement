using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Models
{
    [Table(Name = "SaleOff")]
    public class SaleOff
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string Description { get; set; }

        [Column]
        public DateTime StartDate { get; set; }

        [Column]
        public DateTime EndDate { get; set; }

        [Column]
        public decimal Discount { get; set; }

        [Column]
        public int ProductId { get; set; }

        private EntityRef<Product> _product;

        [Association(Storage = "_product", ThisKey = "ProductId", OtherKey = "Id", IsForeignKey = true)]
        public Product Product
        {
            get { return this._product.Entity; }
            set { this._product.Entity = value; }
        }
    }
}
