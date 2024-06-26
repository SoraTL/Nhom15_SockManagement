﻿using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Models
{
    [Table(Name = "ProductImages")]
    public class ProductImage
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public int ProductId { get; set; }

        [Column(DbType = "VARBINARY(MAX)")]
        public byte[] Image { get; set; }

        [Column]
        public string Description { get; set; }

        [Column]
        public bool IsPrimary { get; set; }

        [Column]
        public DateTime CreatedAt { get; set; }

        private EntityRef<Product> _product;

        [Association(Storage = "_product", ThisKey = "ProductId", OtherKey = "Id", IsForeignKey = true)]
        public Product Product
        {
            get { return this._product.Entity; }
            set { this._product.Entity = value; }
        }
    }
}
