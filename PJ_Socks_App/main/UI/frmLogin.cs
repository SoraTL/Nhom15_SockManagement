using PJ_Socks_App.main.DAO;
using PJ_Socks_App.main.UI;
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

        public event EventHandler LoginSuccess;
        private readonly AccountService accountService;


        public frmLogin()
        {
            InitializeComponent();
            accountService = new AccountService();
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
            
            if (!accountService.ValidateUser(username, password))
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                txtUsername.Focus();
                return;
            }
            else
            {
                this.Hide();
                lbThoat frmHome = new lbThoat(this);
                frmHome.ShowDialog();
            }
        }
    }
}
