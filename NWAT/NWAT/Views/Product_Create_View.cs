﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NWAT.DB;

namespace NWAT
{
    public partial class Product_Create_View : Form
    {
        private ProductController prodCont;
        public Product_Create_View()
        {
            this.prodCont = new ProductController();
            InitializeComponent();
        }

        private void Product_Create_Load(object sender, EventArgs e)
        {

        }

        private void btn_ProdCreate_Click(object sender, EventArgs e)
        {

        }
        private void CreateNewProduct()
        {

        }
    }
}
