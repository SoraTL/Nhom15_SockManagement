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
    public partial class Description : Form
    {
        private Product product;
        private ProductService ProductService;


        public Description()
        {
            InitializeComponent();
        }

        public Description(Product product)
        {
            InitializeComponent();
            ProductService = new ProductService();
            this.product = product;
            lblProduct.Text = product.Name;
            txtDescripTion.Text = product.Description;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblProduct_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripTion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(!txtDescripTion.Equals(this.product.Description)){ ProductService.updateDescription(this.product.Id, txtDescripTion.Text); }
        }
    }
}
