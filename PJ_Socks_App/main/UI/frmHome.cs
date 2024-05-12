using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace PJ_Socks_App.main.UI
{
    public partial class lbThoat : Form
    {
        private frmLogin loginForm;
        private frmUserManagement frmUserManagement;
        private frmProductManagement frmProductManagement;

        public lbThoat(frmLogin frmLogin)
        {
            InitializeComponent();
            this.loginForm = frmLogin;
        }

        private void lbLogOut_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbKhachHang_Click(object sender, EventArgs e)
        {
            frmUserManagement = new frmUserManagement(this);
            this.Hide();
            frmUserManagement.Show();
        }

        private void lbThoat_Load(object sender, EventArgs e)
        {

        }

        private void lbDMSP_Click(object sender, EventArgs e)
        {
            frmProductManagement = new  frmProductManagement(this);
            this.Hide();
            frmProductManagement.Show();
        }
    }
}
