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
    public partial class Product_Update_View : Form
    {

        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        private ProductController _productCont;

        public ProductController ProductCont
        {
            get { return _productCont; }
            set { _productCont = value; }
        }
        
        public Product_Update_View(int productId)
        {

            using (ProductController ProdUpdView = new ProductController()) 
            {
                this.Product = ProdUpdView.GetProductById(productId);
            }

            InitializeComponent();
        }
        


      
        private void Product_Update_Form_Load(object sender, EventArgs e)
        {
            String ProdName = this.Product.Name;
            String ProdProducer = this.Product.Producer;
            double ProdPrice = this.Product.Price.Value;
            textBox_ProdNameUpdate.Text = this.Product.Name;
            textBox_ProdManuUpdate.Text = this.Product.Producer;
            textBox_ProdPrizeUpdate.Text = String.Format("{0:0.00}", this.Product.Price);
            this.FormClosing += new FormClosingEventHandler(Product_Update_View_FormClosing);
        }
        void Product_Update_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            Produktverwaltung_View back = new Produktverwaltung_View();
            back.Show();
        }


        private void btn_ProdUpdate_Click(object sender, EventArgs e)
        {
            using (ProductController prodUpdate = new ProductController()) 
            {
                Product prodNew = prodUpdate.GetProductById(Product.Product_Id);
                prodNew.Product_Id = this.Product.Product_Id;
                prodNew.Name = textBox_ProdNameUpdate.Text;
                prodNew.Producer = textBox_ProdManuUpdate.Text;

            double check;
              if (prodNew.Name.Contains("|") || prodNew.Producer.Contains("|"))
             {
                 MessageBox.Show("Das Zeichen: | ist nicht erlaubt. Bitte ändern Sie Ihre Eingabe");
             }
            else 
             {
                if (Double.TryParse(textBox_ProdPrizeUpdate.Text, out check))
                {
                    prodNew.Price = Convert.ToDouble(textBox_ProdPrizeUpdate.Text);
                    prodUpdate.UpdateProductInDb(prodNew);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Der Preis darf nur aus Zahlen bestehen!");
                }
             }
            }
        }
        private void UpdateProduct()
        {

        }
    }
}
