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
    public partial class frmProductManagement : Form
    {   
        private readonly ProductService productService;
        private lbThoat frmHome;
        public frmProductManagement(lbThoat frmHome)
        {
            InitializeComponent();
            productService = new ProductService();
            this.frmHome = frmHome;
            DinhDangLuoi();
            LoadDS();
        }

        private void DinhDangLuoi()
        {

            if (dgProduct.Columns.Count >= 10)
            {
                dgProduct.Columns[0].Width = 20;
                dgProduct.Columns[1].Width = 20;
                dgProduct.Columns[2].Width = 20;
                dgProduct.Columns[3].Width = 20;
                dgProduct.Columns[4].Width = 80;
                dgProduct.Columns[5].Width = 80;
                dgProduct.Columns[6].Width = 80;
                dgProduct.Columns[7].Width = 80;
                dgProduct.Columns[8].Width = 80;
                dgProduct.Columns[9].Width = 80;

                dgProduct.Columns[0].HeaderText = "Mã sản phẩm";
                dgProduct.Columns[1].HeaderText = "Tên sản phẩm";
                dgProduct.Columns[2].HeaderText = "Số lượng";
                dgProduct.Columns[3].HeaderText = "Giá";
                dgProduct.Columns[4].HeaderText = "Màu";
                dgProduct.Columns[5].HeaderText = "Thiết kế";
                dgProduct.Columns[6].HeaderText = "Highlight";
                dgProduct.Columns[7].HeaderText = "Mô tả";
                dgProduct.Columns[8].HeaderText = "CategoryId";
                dgProduct.Columns[9].HeaderText = "Status";

                foreach (DataGridViewColumn column in dgProduct.Columns)
                {
                    column.ReadOnly = false;
                }

                dgProduct.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dgProduct.RowHeadersVisible = false;
                dgProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                MessageBox.Show("DataGridView không có đủ cột để định dạng");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadDG(List<Product> productList)
        {
            dgProduct.AutoGenerateColumns = false;

            dgProduct.Columns.Clear();

            dgProduct.Columns.Add("Id", "Mã sản phẩm");
            dgProduct.Columns.Add("Name", "Tên sản phẩm");
            dgProduct.Columns.Add("Inventory", "Số lượng");
            dgProduct.Columns.Add("Price", "Giá");
            dgProduct.Columns.Add("Color", "Màu");
            dgProduct.Columns.Add("Design", "Thiết kế");
            dgProduct.Columns.Add("Description", "Mô tả");

            dgProduct.DataSource = productList;
        }

        private void LoadDS()
        {
            List<Product> productList = productService.getAll();
            dgProduct.DataSource = productList;
        }

        private void frmProductManagement_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
