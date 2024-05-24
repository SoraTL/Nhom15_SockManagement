using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Models
{
    [Table(Name = "Products")]
    public class Product
    {
        [Column(IsPrimaryKey = true,IsDbGenerated =true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public int Inventory { get; set; }

        [Column]
        public decimal Price { get; set; }

        [Column]
        public string Color { get; set; }
 
        [Column]
        public string Design { get; set; }

        [Column]
        public bool Highlight { get; set; }

        [Column]
        public string Description { get; set; }

        [Column]
        public int CategoryId { get; set; }
        [Column]
        public string Status { get; set; }

        private EntityRef<Category> _category;

        [Association(Storage = "_category", ThisKey = "CategoryId", OtherKey = "Id", IsForeignKey = true)]
        public Category Category
        {
            get { return this._category.Entity; }
            set { this._category.Entity = value; }
        }
    }
}
