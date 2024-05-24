using PJ_Socks_App.main.Models;
using PJ_Socks_App.main.Models.responses;
using PJ_Socks_App.main.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PJ_Socks_App.main.UI
{
    public partial class frmProductManagement : Form
    {   
        private readonly ProductService productService;
        private readonly ProductImageService productImageService;
        private lbThoat frmHome;
        private Product currentSelectedProduct;

        public frmProductManagement(lbThoat frmHome)
        {
            InitializeComponent();
            productService = new ProductService();
            productImageService = new ProductImageService();
            this.frmHome = frmHome;
            LoadDS();
            cbHighLight.DataSource = new List<KeyValuePair<int, string>>()
            {
            new KeyValuePair<int, string>(0, "Không nổi bật"),
            new KeyValuePair<int, string>(1, "Nổi bật")
            };
            cbHighLight.DisplayMember = "Value";
            cbHighLight.ValueMember = "Key";
        }



        private void DinhDangLuoi()
        {

            if (dgProduct.Columns.Count >= 10)
            {
                dgProduct.Columns[0].Width = 20;
                dgProduct.Columns[1].Width = 20;
                dgProduct.Columns[2].Width = 20;
                dgProduct.Columns[3].Width = 20;
                dgProduct.Columns[4].Width = 20;
                dgProduct.Columns[5].Width = 20;

                dgProduct.Columns[0].HeaderText = "Mã sản phẩm";
                dgProduct.Columns[1].HeaderText = "Tên sản phẩm";
                dgProduct.Columns[2].HeaderText = "Số lượng";
                dgProduct.Columns[3].HeaderText = "Giá";
                dgProduct.Columns[4].HeaderText = "Màu";
                dgProduct.Columns[5].HeaderText = "Thiết kế";

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
            
            dgProduct.DataSource = DGProduct.convert(productList);
        }

        private void frmProductManagement_Load(object sender, EventArgs e)
        {
            dgProduct.SelectionChanged += DataGridView1_SelectionChanged;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try 
            {
                string imageLocation = "";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*";
            
                if(openFileDialog.ShowDialog() == DialogResult.OK) {
                    imageLocation = openFileDialog.FileName;

                    Image.ImageLocation = openFileDialog.FileName;
                    
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("An Error Occured", "Error");
            }
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            if (currentSelectedProduct != null)
            {
                Description description = new Description(currentSelectedProduct);
                description.ShowDialog();
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgProduct.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgProduct.SelectedRows[0];

                var cellValue = selectedRow.Cells[0].Value;

                int productId = int.Parse(selectedRow.Cells[0].Value.ToString());

                currentSelectedProduct = productService.getProduct(productId);

                txtId.Text = currentSelectedProduct.Id.ToString();
                txtName.Text = currentSelectedProduct.Name;
                txtInventory.Text = currentSelectedProduct.Inventory.ToString();
                txtPrice.Text = currentSelectedProduct.Price.ToString();
                txtColor.Text = currentSelectedProduct.Color.ToString();
                txtDesign.Text = currentSelectedProduct.Design.ToString();
                if (currentSelectedProduct.Highlight)
                {
                    cbHighLight.SelectedValue = 1;
                }
                else
                {
                    cbHighLight.SelectedValue = 0;
                }
            }
        }

        private void dgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtId.Text != null){Product product = new Product() { Name = txtName.Text ,Price = int.Parse(txtPrice.Text),Inventory = int.Parse(txtInventory.Text),Color=txtColor.Text,Design=txtDesign.Text,Highlight=(cbHighLight.SelectedIndex==0)? false : true,Status = "true"};
            productService.insert(product);
                MessageBox.Show("Lưu thành công");
            }
            LoadDS();
            Reset();

        }

        private void Reset()
        {
            txtName.Text="";
            txtId.Text=null;
            txtPrice.Text=null;
            txtInventory.Text=null;
            txtColor.Text=null;
            txtDesign.Text=null;
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            txtName.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (pictureBox1.ImageLocation != null && currentSelectedProduct != null)
            {
                ProductImage image = new ProductImage()
                { Image = File.ReadAllBytes(Image.ImageLocation), CreatedAt = DateTime.Now, IsPrimary = true ,ProductId = currentSelectedProduct.Id};

                productImageService.insert(image);
            }
            MessageBox.Show("Sửa thành công");
        }
    }


}
