﻿namespace NWAT
{
    partial class Product_Update_View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_ProdPrize = new System.Windows.Forms.Label();
            this.textBox_ProdPrizeUpdate = new System.Windows.Forms.TextBox();
            this.textBox_ProdManuUpdate = new System.Windows.Forms.TextBox();
            this.label_ProdManu = new System.Windows.Forms.Label();
            this.btn_ProdUpdate = new System.Windows.Forms.Button();
            this.textBox_ProdNameUpdate = new System.Windows.Forms.TextBox();
            this.label_ProdName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_ProdPrize
            // 
            this.label_ProdPrize.AutoSize = true;
            this.label_ProdPrize.Location = new System.Drawing.Point(16, 137);
            this.label_ProdPrize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ProdPrize.Name = "label_ProdPrize";
            this.label_ProdPrize.Size = new System.Drawing.Size(48, 20);
            this.label_ProdPrize.TabIndex = 22;
            this.label_ProdPrize.Text = "Preis:";
            // 
            // textBox_ProdPrizeUpdate
            // 
            this.textBox_ProdPrizeUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ProdPrizeUpdate.Location = new System.Drawing.Point(21, 162);
            this.textBox_ProdPrizeUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_ProdPrizeUpdate.Name = "textBox_ProdPrizeUpdate";
            this.textBox_ProdPrizeUpdate.Size = new System.Drawing.Size(490, 26);
            this.textBox_ProdPrizeUpdate.TabIndex = 21;
            // 
            // textBox_ProdManuUpdate
            // 
            this.textBox_ProdManuUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ProdManuUpdate.Location = new System.Drawing.Point(21, 102);
            this.textBox_ProdManuUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_ProdManuUpdate.Name = "textBox_ProdManuUpdate";
            this.textBox_ProdManuUpdate.Size = new System.Drawing.Size(490, 26);
            this.textBox_ProdManuUpdate.TabIndex = 20;
            // 
            // label_ProdManu
            // 
            this.label_ProdManu.AutoSize = true;
            this.label_ProdManu.Location = new System.Drawing.Point(16, 77);
            this.label_ProdManu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ProdManu.Name = "label_ProdManu";
            this.label_ProdManu.Size = new System.Drawing.Size(81, 20);
            this.label_ProdManu.TabIndex = 19;
            this.label_ProdManu.Text = "Hersteller:";
            // 
            // btn_ProdUpdate
            // 
            this.btn_ProdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProdUpdate.Location = new System.Drawing.Point(549, 161);
            this.btn_ProdUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ProdUpdate.Name = "btn_ProdUpdate";
            this.btn_ProdUpdate.Size = new System.Drawing.Size(112, 35);
            this.btn_ProdUpdate.TabIndex = 18;
            this.btn_ProdUpdate.Text = "ändern";
            this.btn_ProdUpdate.UseVisualStyleBackColor = true;
            this.btn_ProdUpdate.Click += new System.EventHandler(this.btn_ProdUpdate_Click);
            // 
            // textBox_ProdNameUpdate
            // 
            this.textBox_ProdNameUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ProdNameUpdate.Location = new System.Drawing.Point(21, 42);
            this.textBox_ProdNameUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_ProdNameUpdate.Name = "textBox_ProdNameUpdate";
            this.textBox_ProdNameUpdate.Size = new System.Drawing.Size(490, 26);
            this.textBox_ProdNameUpdate.TabIndex = 16;
            // 
            // label_ProdName
            // 
            this.label_ProdName.AutoSize = true;
            this.label_ProdName.Location = new System.Drawing.Point(20, 15);
            this.label_ProdName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ProdName.Name = "label_ProdName";
            this.label_ProdName.Size = new System.Drawing.Size(108, 20);
            this.label_ProdName.TabIndex = 14;
            this.label_ProdName.Text = "Produktname:";
            // 
            // Product_Update_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 214);
            this.Controls.Add(this.label_ProdPrize);
            this.Controls.Add(this.textBox_ProdPrizeUpdate);
            this.Controls.Add(this.textBox_ProdManuUpdate);
            this.Controls.Add(this.label_ProdManu);
            this.Controls.Add(this.btn_ProdUpdate);
            this.Controls.Add(this.textBox_ProdNameUpdate);
            this.Controls.Add(this.label_ProdName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Product_Update_View";
            this.Text = "Produktdetails";
            this.Load += new System.EventHandler(this.Product_Update_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ProdPrize;
        private System.Windows.Forms.TextBox textBox_ProdPrizeUpdate;
        private System.Windows.Forms.TextBox textBox_ProdManuUpdate;
        private System.Windows.Forms.Label label_ProdManu;
        private System.Windows.Forms.Button btn_ProdUpdate;
        private System.Windows.Forms.TextBox textBox_ProdNameUpdate;
        private System.Windows.Forms.Label label_ProdName;
    }
}