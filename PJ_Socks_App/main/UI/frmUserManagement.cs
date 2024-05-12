using PJ_Socks_App.main.Models;
using PJ_Socks_App.main.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJ_Socks_App.main.UI
{
    public partial class frmUserManagement : Form
    {
        private readonly PersonService personService;
        private lbThoat frmLogin;

        public frmUserManagement(lbThoat frmLogin)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
            personService = new PersonService();
            LoadKH();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DinhDangLuoi()
        {
            dgKhachHang.Columns[0].Width = 80;
            dgKhachHang.Columns[1].Width = 200;
            dgKhachHang.Columns[2].Width = 100;
            dgKhachHang.Columns[3].Width = 200;
            dgKhachHang.Columns[4].Width = 80;
            dgKhachHang.Columns[5].Width = 80;

            dgKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            dgKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dgKhachHang.Columns[2].HeaderText = "Email";
            dgKhachHang.Columns[3].HeaderText = "Phone";
            dgKhachHang.Columns[4].HeaderText = "Role";
            dgKhachHang.Columns[5].HeaderText = "Status";

            foreach (DataGridViewColumn column in dgKhachHang.Columns)
            {
                column.ReadOnly = false;

                dgKhachHang.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dgKhachHang.RowHeadersVisible = false;
                dgKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            }
        }
        private void LoadKH()
        {
            List < Person > listKhachHang = personService.GetUsers();
            dgKhachHang.DataSource = listKhachHang; 
        }

        private void dgKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgKhachHang.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgKhachHang.SelectedRows[0];

                txtId.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtName.Text = row.Cells["TenKhachHang"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
            }

        }

        private void YourForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin.Show();
            MessageBox.Show("Ứng dụng đã đóng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtId.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Person person = new Person() { Id = int.Parse(txtId.Text), Name = txtName.Text, Email = txtEmail.Text, Role = "user", Phone = txtPhone.Text, Status = "active" };
            personService.insert(person);
            LoadKH();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.frmLogin.Show();
            this.Close();
        }

        

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgKhachHang.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            personService.delete(id);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Person person = new Person() { Id = int.Parse(txtId.Text), Name = txtName.Text, Email=txtEmail.Text, Phone = txtPhone.Text, Role="user", Status="active" };
            personService.update(person);
            LoadKH();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void LoadSearchForDG()
        {
            List<Person> people = personService.FindByName(txtSearch.Text);

            dgKhachHang.DataSource = people;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
