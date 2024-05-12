using PJ_Socks_App.main.DBContext;
using PJ_Socks_App.main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.Repositories
{
    public class AccountRepository
    {
        private readonly SockSalesDataContext context;

        public AccountRepository() {
            context = SockSalesDataContext.GetInstance();
        }

        public bool UsernameExists(string username)
        {
            var usernameExists = context.Accounts.Any(a => a.Username == username);
            return usernameExists;
        }

        public Account Login(string usesrname, string password) {
            var account = context.Accounts.FirstOrDefault(a => a.Username == usesrname && a.Password == password);
            return account;
        }

        public bool ValidateUser(string username, string password)
        {
            var user = context.Accounts.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }



    }
}
