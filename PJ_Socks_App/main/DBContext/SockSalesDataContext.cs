using PJ_Socks_App.main.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.DBContext
{
    public class SockSalesDataContext : DataContext
    {

        public Table<Account> Accounts;

        public SockSalesDataContext(string connection) : base(connection) { }
        public SockSalesDataContext() : base(@"Data Source=SORR\SQLEXPRESS;Initial Catalog=Sock_Selling;User ID=sa;Password=147852369;Connect Timeout=60;Encrypt=False") { }


    }
}
