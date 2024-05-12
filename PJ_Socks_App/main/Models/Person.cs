using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Models
{
    [Table(Name = "Persons")]
    public class Person
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Role { get; set; }
        [Column]
        public string Email {  get; set; }
        [Column]
        public string Phone { get; set; }
        [Column]
        public string Status { get; set; }

    }
}
