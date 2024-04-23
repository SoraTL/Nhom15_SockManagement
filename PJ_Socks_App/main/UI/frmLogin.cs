using PJ_Socks_App.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJ_Socks_App
{
    public partial class frmLogin : Form
    {

        private AccountRepository accountRepository = new AccountRepository("Data Source = SORR\\SQLEXPRESS; User ID = sa; Password=147852369;Initial Catalog = Lab3;\r\n");
        public event EventHandler LoginSuccess;

        public frmLogin()
        {
            InitializeComponent();
        }
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (!IsValidLogin(username, password))
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                txtPassword.Focus();
                return;
            }


        }

        private void btnSignup_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }


        private bool IsValidLogin(string username, string password)
        {
            if(accountRepository.GetAccount(username, password) != null)
            {
                return true;
            }
            return false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
