﻿using NWAT.DB;
using NWAT.HelperClasses;
using System;
using System.Windows.Forms;
namespace NWAT
{
    public partial class Project_Create_View : Form
    {
        private Form parentView;
        private ProjectController projCont;
        public Project_Create_View(Form parentView)
        {
            this.parentView = parentView;
            this.projCont = new ProjectController();          
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Project_Create_Form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void Project_Create_Form_Load(object sender, EventArgs e)
        {

            this.FormClosing += new FormClosingEventHandler(Project_Create_View_FormClosing);
        }
        /// <summary>
        /// Handles the FormClosing event of the Project_Create_View control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        void Project_Create_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            try{
                this.parentView.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }


        private void CreateNewProject()
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btn_ProjCreate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// Erstellt von Veit Berg, am 27.01.16
        private void btn_ProjCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Project projCre = new Project();
                if (CommonMethods.CheckIfForbiddenDelimiterInDb(textBox_ProjNameCreate.Text) ||
                    CommonMethods.CheckIfForbiddenDelimiterInDb(textBox_ProjDescCreate.Text))
                {
                    MessageBox.Show(CommonMethods.MessageForbiddenDelimiterWasFoundInText());
                }
                else
                {
                    projCre.Name = textBox_ProjNameCreate.Text;
                    projCre.Description = textBox_ProjDescCreate.Text;
                    projCont.InsertProjectIntoDb(projCre);

                    this.Close();
                }
                
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
    }
}
