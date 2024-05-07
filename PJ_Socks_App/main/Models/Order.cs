using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Models
{
    [Table(Name = "Orders")]
    public class Order
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string Address { get; set; }

        [Column]
        public DateTime CreatedAt { get; set; }

        [Column]
        public int AccountId { get; set; }

        private EntityRef<Account> _account;

        [Association(Storage = "_account", ThisKey = "AccountId", OtherKey = "Id", IsForeignKey = true)]
        public Account Account
        {
            get { return this._account.Entity; }
            set { this._account.Entity = value; }
        }
    }
}
