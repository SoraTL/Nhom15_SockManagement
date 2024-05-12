using PJ_Socks_App.main.Models;
using PJ_Socks_App.main.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.main.DAO
{
    public class AccountService
    {
        private readonly AccountRepository accountRepository;

        public AccountService() 
        {
            accountRepository = new AccountRepository();
        }

        public bool ValidateUser(string username, string password)
        {
            return accountRepository.ValidateUser(username, password);
        }
    }
}
