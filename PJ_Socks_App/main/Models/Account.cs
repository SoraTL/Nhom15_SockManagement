using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Models
{
    [Table(Name = "Accounts")]
    public class Account
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public int PersonId { get; set; }

        [Column]
        public string Username {  get; set; }

        [Column]
        public string Password { get; set; }

        [Column]
        public string Status { get; set; }
    }
}
