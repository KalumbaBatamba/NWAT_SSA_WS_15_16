﻿namespace NWAT.Views
{
    partial class ProjCritParentAllocation_View
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
            this.comboBox_CritName = new System.Windows.Forms.ComboBox();
            this.btn_zuordnen = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_CritName
            // 
            this.comboBox_CritName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_CritName.FormattingEnabled = true;
            this.comboBox_CritName.Location = new System.Drawing.Point(43, 48);
            this.comboBox_CritName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_CritName.Name = "comboBox_CritName";
            this.comboBox_CritName.Size = new System.Drawing.Size(331, 28);
            this.comboBox_CritName.TabIndex = 3;
            this.comboBox_CritName.Text = "Vaterkriterium auswählen";
            // 
            // btn_zuordnen
            // 
            this.btn_zuordnen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_zuordnen.Location = new System.Drawing.Point(43, 102);
            this.btn_zuordnen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_zuordnen.Name = "btn_zuordnen";
            this.btn_zuordnen.Size = new System.Drawing.Size(102, 35);
            this.btn_zuordnen.TabIndex = 4;
            this.btn_zuordnen.Text = "zuordnen";
            this.btn_zuordnen.UseVisualStyleBackColor = true;
            this.btn_zuordnen.Click += new System.EventHandler(this.btn_zuordnen_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancle.Location = new System.Drawing.Point(180, 102);
            this.btn_cancle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(194, 35);
            this.btn_cancle.TabIndex = 5;
            this.btn_cancle.Text = "ohne Parent zuordnen";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // ProjCritParentAllocation_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 185);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_zuordnen);
            this.Controls.Add(this.comboBox_CritName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProjCritParentAllocation_View";
            this.Text = "ProjCritParentAllocation";
            this.Load += new System.EventHandler(this.ProjCritParentAllocation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_CritName;
        private System.Windows.Forms.Button btn_zuordnen;
        private System.Windows.Forms.Button btn_cancle;
    }
}