﻿namespace NWAT
{
    partial class Product_Show
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
            this.label_ProdNameShow = new System.Windows.Forms.Label();
            this.label_ProdManuShow = new System.Windows.Forms.Label();
            this.label_ProdPrizeShow = new System.Windows.Forms.Label();
            this.label_ProdDescShow = new System.Windows.Forms.Label();
            this.label_ProdName = new System.Windows.Forms.Label();
            this.label_ProdManu = new System.Windows.Forms.Label();
            this.label_ProdPrize = new System.Windows.Forms.Label();
            this.label_ProdDesc = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_ProdNameShow
            // 
            this.label_ProdNameShow.AutoSize = true;
            this.label_ProdNameShow.Location = new System.Drawing.Point(138, 33);
            this.label_ProdNameShow.Name = "label_ProdNameShow";
            this.label_ProdNameShow.Size = new System.Drawing.Size(181, 13);
            this.label_ProdNameShow.TabIndex = 0;
            this.label_ProdNameShow.Text = "Name des anzuzeigenden Produktes";
            // 
            // label_ProdManuShow
            // 
            this.label_ProdManuShow.AutoSize = true;
            this.label_ProdManuShow.Location = new System.Drawing.Point(138, 73);
            this.label_ProdManuShow.Name = "label_ProdManuShow";
            this.label_ProdManuShow.Size = new System.Drawing.Size(122, 13);
            this.label_ProdManuShow.TabIndex = 1;
            this.label_ProdManuShow.Text = "Hersteller des Produktes";
            // 
            // label_ProdPrizeShow
            // 
            this.label_ProdPrizeShow.AutoSize = true;
            this.label_ProdPrizeShow.Location = new System.Drawing.Point(138, 107);
            this.label_ProdPrizeShow.Name = "label_ProdPrizeShow";
            this.label_ProdPrizeShow.Size = new System.Drawing.Size(101, 13);
            this.label_ProdPrizeShow.TabIndex = 2;
            this.label_ProdPrizeShow.Text = "Preis des Produktes";
            // 
            // label_ProdDescShow
            // 
            this.label_ProdDescShow.AutoSize = true;
            this.label_ProdDescShow.Location = new System.Drawing.Point(138, 140);
            this.label_ProdDescShow.Name = "label_ProdDescShow";
            this.label_ProdDescShow.Size = new System.Drawing.Size(143, 13);
            this.label_ProdDescShow.TabIndex = 3;
            this.label_ProdDescShow.Text = "Beschreibung des Produktes";
            // 
            // label_ProdName
            // 
            this.label_ProdName.AutoSize = true;
            this.label_ProdName.Location = new System.Drawing.Point(10, 33);
            this.label_ProdName.Name = "label_ProdName";
            this.label_ProdName.Size = new System.Drawing.Size(73, 13);
            this.label_ProdName.TabIndex = 4;
            this.label_ProdName.Text = "Produktname:";
            // 
            // label_ProdManu
            // 
            this.label_ProdManu.AutoSize = true;
            this.label_ProdManu.Location = new System.Drawing.Point(10, 73);
            this.label_ProdManu.Name = "label_ProdManu";
            this.label_ProdManu.Size = new System.Drawing.Size(54, 13);
            this.label_ProdManu.TabIndex = 5;
            this.label_ProdManu.Text = "Hersteller:";
            // 
            // label_ProdPrize
            // 
            this.label_ProdPrize.AutoSize = true;
            this.label_ProdPrize.Location = new System.Drawing.Point(10, 107);
            this.label_ProdPrize.Name = "label_ProdPrize";
            this.label_ProdPrize.Size = new System.Drawing.Size(33, 13);
            this.label_ProdPrize.TabIndex = 6;
            this.label_ProdPrize.Text = "Preis:";
            // 
            // label_ProdDesc
            // 
            this.label_ProdDesc.AutoSize = true;
            this.label_ProdDesc.Location = new System.Drawing.Point(10, 140);
            this.label_ProdDesc.Name = "label_ProdDesc";
            this.label_ProdDesc.Size = new System.Drawing.Size(75, 13);
            this.label_ProdDesc.TabIndex = 7;
            this.label_ProdDesc.Text = "Beschreibung:";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(337, 256);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 8;
            this.btn_Close.Text = "schliessen";
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // Product_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label_ProdDesc);
            this.Controls.Add(this.label_ProdPrize);
            this.Controls.Add(this.label_ProdManu);
            this.Controls.Add(this.label_ProdName);
            this.Controls.Add(this.label_ProdDescShow);
            this.Controls.Add(this.label_ProdPrizeShow);
            this.Controls.Add(this.label_ProdManuShow);
            this.Controls.Add(this.label_ProdNameShow);
            this.Name = "Product_Show";
            this.Text = "Produkt anzeigen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ProdNameShow;
        private System.Windows.Forms.Label label_ProdManuShow;
        private System.Windows.Forms.Label label_ProdPrizeShow;
        private System.Windows.Forms.Label label_ProdDescShow;
        private System.Windows.Forms.Label label_ProdName;
        private System.Windows.Forms.Label label_ProdManu;
        private System.Windows.Forms.Label label_ProdPrize;
        private System.Windows.Forms.Label label_ProdDesc;
        private System.Windows.Forms.Button btn_Close;
    }
}