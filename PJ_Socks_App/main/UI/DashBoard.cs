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
        private Form currentChildForm;

        public lbThoat(frmLogin frmLogin)
        {
            InitializeComponent();
            this.loginForm = frmLogin;
        }

        public void OpenChhildForm(Form childForm)
        {
            if(this.currentChildForm != null)
            {
                currentChildForm.Close();
            }
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Panel_Body.Controls.Add(childForm);
            Panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            this.currentChildForm = childForm;
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
            OpenChhildForm(frmUserManagement);
        }

        private void lbThoat_Load(object sender, EventArgs e)
        {

        }

        private void lbDMSP_Click(object sender, EventArgs e)
        {
            frmProductManagement = new  frmProductManagement(this);
            OpenChhildForm(frmProductManagement);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Panel_Body_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
