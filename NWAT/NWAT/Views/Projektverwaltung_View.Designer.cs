﻿namespace NWAT
{
    partial class Projektverwaltung_View
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
            this.label_ProjectChoose = new System.Windows.Forms.Label();
            this.comboBox_SelectProject = new System.Windows.Forms.ComboBox();
            this.btn_ProjectShow = new System.Windows.Forms.Button();
            this.btn_ProjectUpdate = new System.Windows.Forms.Button();
            this.btn_ProjectExport = new System.Windows.Forms.Button();
            this.btn_ProjectStartCreate = new System.Windows.Forms.Button();
            this.btn_ProjectModify = new System.Windows.Forms.Button();
            this.btn_ProjImport = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_ProjectChoose
            // 
            this.label_ProjectChoose.AutoSize = true;
            this.label_ProjectChoose.Location = new System.Drawing.Point(14, 137);
            this.label_ProjectChoose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ProjectChoose.Name = "label_ProjectChoose";
            this.label_ProjectChoose.Size = new System.Drawing.Size(242, 20);
            this.label_ProjectChoose.TabIndex = 0;
            this.label_ProjectChoose.Text = "Vorhandenes Projekt auswählen:";
            this.label_ProjectChoose.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox_SelectProject
            // 
            this.comboBox_SelectProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_SelectProject.FormattingEnabled = true;
            this.comboBox_SelectProject.Location = new System.Drawing.Point(18, 163);
            this.comboBox_SelectProject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_SelectProject.Name = "comboBox_SelectProject";
            this.comboBox_SelectProject.Size = new System.Drawing.Size(448, 28);
            this.comboBox_SelectProject.TabIndex = 1;
            this.comboBox_SelectProject.Text = "Wählen Sie ein Projekt aus der Liste aus";
            this.comboBox_SelectProject.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectProject_SelectedIndexChanged);
            // 
            // btn_ProjectShow
            // 
            this.btn_ProjectShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjectShow.Location = new System.Drawing.Point(506, 254);
            this.btn_ProjectShow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ProjectShow.Name = "btn_ProjectShow";
            this.btn_ProjectShow.Size = new System.Drawing.Size(112, 35);
            this.btn_ProjectShow.TabIndex = 2;
            this.btn_ProjectShow.Text = "anzeigen";
            this.btn_ProjectShow.UseVisualStyleBackColor = true;
            this.btn_ProjectShow.Click += new System.EventHandler(this.btn_ProjectShow_Click);
            // 
            // btn_ProjectUpdate
            // 
            this.btn_ProjectUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjectUpdate.Location = new System.Drawing.Point(506, 300);
            this.btn_ProjectUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ProjectUpdate.Name = "btn_ProjectUpdate";
            this.btn_ProjectUpdate.Size = new System.Drawing.Size(112, 35);
            this.btn_ProjectUpdate.TabIndex = 3;
            this.btn_ProjectUpdate.Text = "ändern";
            this.btn_ProjectUpdate.UseVisualStyleBackColor = true;
            this.btn_ProjectUpdate.Click += new System.EventHandler(this.btn_ProjectUpdate_Click);
            // 
            // btn_ProjectExport
            // 
            this.btn_ProjectExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjectExport.Location = new System.Drawing.Point(506, 345);
            this.btn_ProjectExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ProjectExport.Name = "btn_ProjectExport";
            this.btn_ProjectExport.Size = new System.Drawing.Size(112, 35);
            this.btn_ProjectExport.TabIndex = 4;
            this.btn_ProjectExport.Text = "exportieren";
            this.btn_ProjectExport.UseVisualStyleBackColor = true;
            this.btn_ProjectExport.Click += new System.EventHandler(this.btn_ProjectExport_Click);
            // 
            // btn_ProjectStartCreate
            // 
            this.btn_ProjectStartCreate.Location = new System.Drawing.Point(18, 45);
            this.btn_ProjectStartCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ProjectStartCreate.Name = "btn_ProjectStartCreate";
            this.btn_ProjectStartCreate.Size = new System.Drawing.Size(450, 35);
            this.btn_ProjectStartCreate.TabIndex = 7;
            this.btn_ProjectStartCreate.Text = "Neues Projekt anlegen";
            this.btn_ProjectStartCreate.UseVisualStyleBackColor = true;
            this.btn_ProjectStartCreate.Click += new System.EventHandler(this.btn_ProjectStartCreate_Click);
            // 
            // btn_ProjectModify
            // 
            this.btn_ProjectModify.Location = new System.Drawing.Point(18, 258);
            this.btn_ProjectModify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ProjectModify.Name = "btn_ProjectModify";
            this.btn_ProjectModify.Size = new System.Drawing.Size(238, 35);
            this.btn_ProjectModify.TabIndex = 10;
            this.btn_ProjectModify.Text = "Projekt bearbeiten";
            this.btn_ProjectModify.UseVisualStyleBackColor = true;
            this.btn_ProjectModify.Click += new System.EventHandler(this.btn_ProjectModify_Click);
            // 
            // btn_ProjImport
            // 
            this.btn_ProjImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ProjImport.Location = new System.Drawing.Point(506, 389);
            this.btn_ProjImport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ProjImport.Name = "btn_ProjImport";
            this.btn_ProjImport.Size = new System.Drawing.Size(112, 35);
            this.btn_ProjImport.TabIndex = 11;
            this.btn_ProjImport.Text = "importieren";
            this.btn_ProjImport.UseVisualStyleBackColor = true;
            this.btn_ProjImport.Click += new System.EventHandler(this.btn_ProjImport_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.Location = new System.Drawing.Point(506, 195);
            this.btn_refresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(112, 35);
            this.btn_refresh.TabIndex = 12;
            this.btn_refresh.Text = "refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // Projektverwaltung_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 485);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_ProjImport);
            this.Controls.Add(this.btn_ProjectModify);
            this.Controls.Add(this.btn_ProjectStartCreate);
            this.Controls.Add(this.btn_ProjectExport);
            this.Controls.Add(this.btn_ProjectUpdate);
            this.Controls.Add(this.btn_ProjectShow);
            this.Controls.Add(this.comboBox_SelectProject);
            this.Controls.Add(this.label_ProjectChoose);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Projektverwaltung_View";
            this.Text = "Projektverwaltung";
            this.Load += new System.EventHandler(this.Projektverwaltung_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ProjectChoose;
        private System.Windows.Forms.ComboBox comboBox_SelectProject;
        private System.Windows.Forms.Button btn_ProjectShow;
        private System.Windows.Forms.Button btn_ProjectUpdate;
        private System.Windows.Forms.Button btn_ProjectExport;
        private System.Windows.Forms.Button btn_ProjectStartCreate;
        private System.Windows.Forms.Button btn_ProjectModify;
        private System.Windows.Forms.Button btn_ProjImport;
        private System.Windows.Forms.Button btn_refresh;
    }
}