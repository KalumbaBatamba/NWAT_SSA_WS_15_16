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
using NWAT.Printer;

namespace NWAT
{

    public partial class ProjCritProdFulfilment_View : Form
    {
        int PID = 0;
        private List<Fulfillment> _fulFill;

        public List<Fulfillment> FulFill
        {
            get { return _fulFill; }
            set { _fulFill = value; } 
        }

        private List<ProjectCriterion> _projCrits;

        public List<ProjectCriterion> ProjCrits
        {
            get { return _projCrits; }
            set { _projCrits = value; }
        }
        private Project _project;

        public Project Project
        {
            get { return _project; }
            set { _project = value; }
        }

        private ProjectController _projectCont;

        public ProjectController ProjectCont
        {
            get { return _projectCont; }
            set { _projectCont = value; }
        }


        int aktProd;
        static int formloaded = 1; 


  //      private ProjectController _projectController;


 //       private ProjectCriterionController projCritCont;

        public ProjCritProdFulfilment_View(int projectId)
        {
            int ProjectID = projectId;
            PID = projectId;
            this.ProjectCont = new ProjectController();
            this.Project = this.ProjectCont.GetProjectById(projectId);
            
           
            InitializeComponent();

        }

        private void ProjCritProdFulfilment_Form_Load(object sender, EventArgs e)
        {
            try{
            formloaded = 1;
            using (ProjectProductController Projverw = new ProjectProductController())
            {
                ProjectProduct projprod = (ProjectProduct)comboBox_ProjCritProdFulf.SelectedItem;
                List<ProjectProduct> ProdList = Projverw.GetAllProjectProductsForOneProject(Project.Project_Id); 
                List<Product> productsList = new List<Product>();
                foreach (ProjectProduct projProd in ProdList)
                {
                    productsList.Add(projProd.Product); 
                }
                comboBox_ProjCritProdFulf.DataSource = productsList;
                
                comboBox_ProjCritProdFulf.DisplayMember = "Name";
                comboBox_ProjCritProdFulf.SelectedIndex = -1;
            }
                    using (ProjectCriterionController proCriCont = new ProjectCriterionController())
                     {
                         ProjCrits = proCriCont.GetSortedCriterionStructure(Project.Project_Id);
                         using (CriterionController critCon = new CriterionController())
                         {
                             foreach (ProjectCriterion projCrit in ProjCrits)
                             {
                                 var singleCritId = critCon.GetCriterionById(projCrit.Criterion_Id);
                                 projCrit.Name = singleCritId.Name.ToString();
                             }
                         }
                         var CritBindingList = new BindingList<ProjectCriterion>(ProjCrits);
                         var CritSource = new BindingSource(CritBindingList, null);
                         dataGridView_ProjCritProdFulf.DataSource = ProjCrits;
                         dataGridView_ProjCritProdFulf.Columns.Remove("Project_Id");
                         dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Cardinal");
                         dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Percentage_Layer");
                         dataGridView_ProjCritProdFulf.Columns.Remove("Weighting_Percentage_Project");
                         dataGridView_ProjCritProdFulf.Columns.Remove("Criterion");
                         dataGridView_ProjCritProdFulf.Columns.Remove("ParentCriterion");
                         dataGridView_ProjCritProdFulf.Columns.Remove("Project");
                         DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                         dataGridView_ProjCritProdFulf.Columns.Add(chk);
                         chk.Name = "Erfüllung";
                         DataGridViewTextBoxColumn bem = new DataGridViewTextBoxColumn();
                         bem.Name = "Bemerkung";
                         dataGridView_ProjCritProdFulf.Columns.Add(bem);
                         dataGridView_ProjCritProdFulf.Columns[4].DisplayIndex = 0;
                         dataGridView_ProjCritProdFulf.Columns[3].DisplayIndex = 1;
                         dataGridView_ProjCritProdFulf.Columns[5].DisplayIndex = 2;
                         dataGridView_ProjCritProdFulf.Columns[1].DisplayIndex = 3;
                         dataGridView_ProjCritProdFulf.Columns[0].DisplayIndex = 4;
                         dataGridView_ProjCritProdFulf.Columns[2].DisplayIndex = 5;
                         dataGridView_ProjCritProdFulf.Columns[0].HeaderText = "C-ID";
                         dataGridView_ProjCritProdFulf.Columns[1].HeaderText = "Layer";
                         dataGridView_ProjCritProdFulf.Columns[2].HeaderText = "P-ID";
                         dataGridView_ProjCritProdFulf.Columns[3].HeaderText = "Name";
                         dataGridView_ProjCritProdFulf.Columns[4].Name = "Erfüllung";
                         dataGridView_ProjCritProdFulf.Columns["Name"].ReadOnly = true;
                         dataGridView_ProjCritProdFulf.Columns["Layer_Depth"].ReadOnly = true;
                         dataGridView_ProjCritProdFulf.Columns["Criterion_ID"].ReadOnly = true;
                         dataGridView_ProjCritProdFulf.Columns["Parent_Criterion_Id"].ReadOnly = true;
                        dataGridView_ProjCritProdFulf.Columns[0].Width = 50;
                         dataGridView_ProjCritProdFulf.Columns[1].Width = 50;
                         dataGridView_ProjCritProdFulf.Columns[2].Width = 50;
                         dataGridView_ProjCritProdFulf.Columns[4].Width = 50;
                         dataGridView_ProjCritProdFulf.Columns[3].Width = 150;
                         dataGridView_ProjCritProdFulf.Columns[5].Width = 200;
                         foreach (DataGridViewRow row in dataGridView_ProjCritProdFulf.Rows)
                         {
                             row.Cells["Erfüllung"].Value = false;
                         }

                     }
            }
            catch (Exception i)
            {
                MessageBox.Show("Ups da lief was schief");
            }
            this.dataGridView_ProjCritProdFulf.CellValidating += new
            DataGridViewCellValidatingEventHandler(dataGridView_ProjCritProdFulf_CellValidating);
            this.FormClosing += new FormClosingEventHandler(ProjCritProdFulfillment_View_FormClosing);
        }
        void ProjCritProdFulfillment_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            try{
            aktuellesProjekt_View back = new aktuellesProjekt_View(Project.Project_Id);
            back.Show();
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
        private void AddProjProdCritFulfilment()
        {
            try{
            Product selectedProd = (Product)comboBox_ProjCritProdFulf.SelectedItem;
            aktProd = selectedProd.Product_Id;
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }
        private void GetProjProdFromDB()
        {

        }
        private void GetProjCritsFromDB()
        {

        }

        private void btn_ProdFulfPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Product selectedItem = (Product)comboBox_ProjCritProdFulf.SelectedItem;
                if (selectedItem == null)
                {
                    MessageBox.Show("Bitte erst ein Produkt auswählen.");
                }
                else
                {
                    FulfPrint_View print = new FulfPrint_View(Project.Project_Id, selectedItem.Product_Id);
                    print.Show();
                }
            }
            
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        private void dataGridView_ProjCritProdFulf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ProjCritProdFulfSave_Click(object sender, EventArgs e)
        {
            try{
            if (comboBox_ProjCritProdFulf.SelectedIndex != -1)
            {
                using (FulfillmentController fulCont = new FulfillmentController())
                {
                    foreach (DataGridViewRow row in dataGridView_ProjCritProdFulf.Rows)
                    {
                        Fulfillment fulFi = new Fulfillment();
                        fulFi.Criterion_Id = (int)row.Cells[0].Value;
                        fulFi.Project_Id = Project.Project_Id;
                        int selectedIndex = comboBox_ProjCritProdFulf.SelectedIndex;
                        Product selectedValue = new Product();
                        selectedValue = (Product)comboBox_ProjCritProdFulf.SelectedItem;


                        fulFi.Product_Id = selectedValue.Product_Id;
                        fulFi.Comment = (string)row.Cells["Bemerkung"].Value;
                        if ((bool)row.Cells["Erfüllung"].Value == true)
                        {
                            fulFi.Fulfilled = true;
                        }
                        else if ((bool)row.Cells["Erfüllung"].Value == false)
                        {
                            fulFi.Fulfilled = false;
                        }

                        fulCont.UpdateFulfillmentEntry(fulFi);
                    }

                }
            }
            else 
            {
                MessageBox.Show("Sie müssen ein Produkt auswählen.");
            }
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        private void comboBox_ProjCritProdFulf_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
            if (formloaded > 2)
            {
                Product selectedValue = new Product();
                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                if (cmb.SelectedIndex > -1)
                {
                    selectedValue = (Product)cmb.SelectedValue;

                    if (selectedValue != null)
                    {
                        using (FulfillmentController fuFiCont = new FulfillmentController())
                        {
                            int i = 0;
                            var projProdFulf = fuFiCont.GetAllFulfillmentsForSingleProduct(PID, selectedValue.Product_Id);

                            foreach (Fulfillment singleProjProdFulf in projProdFulf)
                            {
                                int row = i;
                                bool selected = singleProjProdFulf.Fulfilled;
                                String note = singleProjProdFulf.Comment;
                                dataGridView_ProjCritProdFulf.Rows[row].Cells["Erfüllung"].Value = selected;
                                dataGridView_ProjCritProdFulf.Rows[row].Cells["Bemerkung"].Value = note;
                                i++;
                            }
                        }
                    }
                }
            }
            formloaded++;
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
       
        }
        private void updateGrid()
        {
   
        }
        private void dataGridView_ProjCritProdFulf_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try{
            if (e.ColumnIndex == 5)
            {
                dataGridView_ProjCritProdFulf.Rows[e.RowIndex].ErrorText = "";
                if (e.FormattedValue.ToString().Contains("|")){
                    MessageBox.Show("Das Zeichen: " + "| ist nicht erlaubt. Bitte ändern Sie Ihre Eingabe." );
                }
                {
                    
                }
            }
            }
            catch (Exception x)
            {
                MessageBox.Show("Ups da lief was schief");
            }
        }

        private void btn_ProjCritProdFulfCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
