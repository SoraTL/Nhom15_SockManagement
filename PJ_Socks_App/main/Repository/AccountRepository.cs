using PJ_Socks_App.DBConnection;
using PJ_Socks_App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.Repository
{
    public class AccountRepository
    {
        private readonly string connectionString;

        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Account GetAccountById(int id)
        {
            string query = "SELECT * FROM Accounts WHERE Id = @Id";
            object[] parameters = { id };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new Account(row);
            }

            return null;
        }

        public Account GetAccount(string username, string password)
        {
            string query = "SELECT 1 FROM Accounts WHERE Username = " + username + " AND Password = " + password;
            object[] parameters = { username, password };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            if(data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new Account(row);
            }

            return null;

        }

        public List<Account> GetAllAccounts()
        {
            string query = "SELECT * FROM Accounts";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<Account> accounts = new List<Account>();

            foreach (DataRow row in data.Rows)
            {
                Account account = new Account(row);
                accounts.Add(account);
            }

            return accounts;
        }

        public void InsertAccount(Account account)
        {
            string query = "INSERT INTO Accounts (Name, Username, Password, Email) VALUES (@Name, @Username, @Password, @Email)";
            object[] parameters = { account.Name, account.Username, account.Password, account.Email };

            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

        public void UpdateAccount(Account account)
        {
            string query = "UPDATE Accounts SET Name = @Name, Username = @Username, Password = @Password, Email = @Email WHERE Id = @Id";
            object[] parameters = { account.Name, account.Username, account.Password, account.Email, account.Id };

            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

        public void DeleteAccount(int id)
        {
            string query = "DELETE FROM Accounts WHERE Id = @Id";
            object[] parameters = { id };

            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }
    }
}
