using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ_Socks_App.Models
{
    public class Account
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public Account(int id, string name, string username, string password, string email)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Email = email;
        }

        public Account(DataRow row)
        {
            // Kiểm tra xem DataRow có null không trước khi truy cập dữ liệu
            if (row == null)
            {
                throw new ArgumentNullException(nameof(row));
            }

            // Trích xuất dữ liệu từ DataRow và gán cho các thuộc tính của Account
            if (row.Table.Columns.Contains("Id") && row["Id"] != DBNull.Value)
            {
                Id = Convert.ToInt32(row["Id"]);
            }

            if (row.Table.Columns.Contains("Name") && row["Name"] != DBNull.Value)
            {
                Name = row["Name"].ToString();
            }

            if (row.Table.Columns.Contains("Username") && row["Username"] != DBNull.Value)
            {
                Username = row["Username"].ToString();
            }

            if (row.Table.Columns.Contains("Password") && row["Password"] != DBNull.Value)
            {
                Password = row["Password"].ToString();
            }

            if (row.Table.Columns.Contains("Email") && row["Email"] != DBNull.Value)
            {
                Email = row["Email"].ToString();
            }
        }
    }

}
