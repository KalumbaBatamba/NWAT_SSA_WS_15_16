﻿namespace NWAT
{
    partial class ProjCritStruUpdate_View
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgc_ProjCritID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_ProjCritIDParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_ProjCritName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_ProjCritDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ProjCritStruSave = new System.Windows.Forms.Button();
            this.btn_ProjCritStruCancle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgc_ProjCritID,
            this.dgc_ProjCritIDParent,
            this.dgc_ProjCritName,
            this.dgc_ProjCritDesc});
            this.dataGridView1.Location = new System.Drawing.Point(13, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(575, 520);
            this.dataGridView1.TabIndex = 0;
            // 
            // dgc_ProjCritID
            // 
            this.dgc_ProjCritID.HeaderText = "ID";
            this.dgc_ProjCritID.Name = "dgc_ProjCritID";
            this.dgc_ProjCritID.Width = 30;
            // 
            // dgc_ProjCritIDParent
            // 
            this.dgc_ProjCritIDParent.HeaderText = "Parent ID";
            this.dgc_ProjCritIDParent.Name = "dgc_ProjCritIDParent";
            this.dgc_ProjCritIDParent.Width = 80;
            // 
            // dgc_ProjCritName
            // 
            this.dgc_ProjCritName.HeaderText = "Name";
            this.dgc_ProjCritName.Name = "dgc_ProjCritName";
            this.dgc_ProjCritName.Width = 150;
            // 
            // dgc_ProjCritDesc
            // 
            this.dgc_ProjCritDesc.HeaderText = "Beschreibung";
            this.dgc_ProjCritDesc.Name = "dgc_ProjCritDesc";
            this.dgc_ProjCritDesc.Width = 270;
            // 
            // btn_ProjCritStruSave
            // 
            this.btn_ProjCritStruSave.Location = new System.Drawing.Point(597, 496);
            this.btn_ProjCritStruSave.Name = "btn_ProjCritStruSave";
            this.btn_ProjCritStruSave.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritStruSave.TabIndex = 1;
            this.btn_ProjCritStruSave.Text = "speichern";
            this.btn_ProjCritStruSave.UseVisualStyleBackColor = true;
            // 
            // btn_ProjCritStruCancle
            // 
            this.btn_ProjCritStruCancle.Location = new System.Drawing.Point(597, 525);
            this.btn_ProjCritStruCancle.Name = "btn_ProjCritStruCancle";
            this.btn_ProjCritStruCancle.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjCritStruCancle.TabIndex = 2;
            this.btn_ProjCritStruCancle.Text = "abbrechen";
            this.btn_ProjCritStruCancle.UseVisualStyleBackColor = true;
            // 
            // ProjCritStruUpdate_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.btn_ProjCritStruCancle);
            this.Controls.Add(this.btn_ProjCritStruSave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProjCritStruUpdate_View";
            this.Text = "Kriterienstruktur";
            this.Load += new System.EventHandler(this.ProjCritStruUpdate_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_ProjCritStruSave;
        private System.Windows.Forms.Button btn_ProjCritStruCancle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritIDParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_ProjCritDesc;
    }
}