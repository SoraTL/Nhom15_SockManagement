using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Models
{
    [Table(Name = "Sizes")]
    public class Size
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public int SizeNumber { get; set; }

        [Column]
        public string Status { get; set; }
    }
}
