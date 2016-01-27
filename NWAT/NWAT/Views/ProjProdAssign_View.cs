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
    public partial class ProjProdAssign_View : Form
    {
        private List<Product> _allProds;

        public List<Product> AllProds
        {
            get { return _allProds; }
            set { _allProds = value; }
        }

        private List<ProjectProduct> _projProds;

        public List<ProjectProduct> ProjProds
        {
            get { return _projProds; }
            set { _projProds = value; }
        }
        private int _projectId;

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        private ProjectProductController projProdCont;

        public ProjProdAssign_View(int projectID)
        {
            ProjectId = projectID;
            this.projProdCont = new ProjectProductController();
            InitializeComponent();
        }

        private void ProjProdAssign_Form_Load(object sender, EventArgs e)
        {
            using (ProjectProductController proProCont = new ProjectProductController())
            {
                ProjProds = proProCont.GetAllProjectProductsForOneProject(ProjectId);
                using (ProductController prodCon = new ProductController())
                {
                    foreach (ProjectProduct projProd in ProjProds)
                    {
                        var singleProdId = prodCon.GetProductById(projProd.Product_Id);
                        projProd.Name = singleProdId.Name.ToString();
                    }
                }

            }
                

            using (ProductController prodCont = new ProductController())
            {
                AllProds = prodCont.GetAllProductsFromDb();

                if (ProjProds.Count != 0)
                {
                    foreach (ProjectProduct projProd in ProjProds)
                    {
                        Product allocatedProd = AllProds.Single(prod => prod.Product_Id == projProd.Product_Id);
                        AllProds.Remove(allocatedProd);
                    }
                }
            }
            dataGridView_prodAvail.Rows.Clear();
            var ProdBindingList = new BindingList<Product>(AllProds);
            var prodSource = new BindingSource(ProdBindingList, null);
            dataGridView_prodAvail.DataSource = AllProds;
            dataGridView_prodAvail.Columns["Producer"].HeaderText = "Hersteller";
            dataGridView_prodAvail.Columns["Product_Id"].HeaderText = "Produkt ID";
            dataGridView_prodAvail.Columns["Price"].HeaderText = "Preis";

            dataGridView_ProjProd.Rows.Clear();
       
            var ProjProdBindingList = new BindingList<ProjectProduct>(ProjProds);
            var projProdSource = new BindingSource(ProjProdBindingList, null);
            dataGridView_ProjProd.DataSource = ProjProds;
            dataGridView_ProjProd.Columns.Remove("Project_Id");
            dataGridView_ProjProd.Columns.Remove("Product");
            dataGridView_ProjProd.Columns.Remove("Project");
            dataGridView_ProjProd.Columns["Product_Id"].HeaderText = "Produkt ID"; 
            dataGridView_ProjProd.Columns[1].Width = 200;
            this.FormClosing += new FormClosingEventHandler(ProjProdAssign_View_FormClosing);
        }
        void ProjProdAssign_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            aktuellesProjekt_View back = new aktuellesProjekt_View(ProjectId);
            back.Show();
        }

        private void AddProdToProject()
        {

        }
        private void DeleteProdFromProject()
        {

        }
        private void GetAllProdsFromDB()
        {

        }

        private void btn_ProdToProj_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView_prodAvail.SelectedRows[0];
            int ProdId = (int)row.Cells[0].Value;
            string ProdName = (string)row.Cells[1].Value;
            int index = dataGridView_prodAvail.CurrentCell.RowIndex;

            ProjectProduct projProdToAllocate = new ProjectProduct()
            {
                Project_Id = ProjectId,
                Product_Id = ProdId,
            };
            AllProds.RemoveAt(index);
            ProjProds.Add(projProdToAllocate);

            dataGridView_prodAvail.DataSource = null;
            dataGridView_prodAvail.DataSource = AllProds;
           dataGridView_ProjProd.DataSource = null;
            using (ProductController prodCon = new ProductController())
            {
                foreach (ProjectProduct projProd in ProjProds)
                {
                    var singleProdId = prodCon.GetProductById(projProd.Product_Id);
                    projProd.Name = singleProdId.Name.ToString();
                }
            }


            dataGridView_ProjProd.DataSource = ProjProds;
            dataGridView_ProjProd.Columns.Remove("Project_Id");
            dataGridView_ProjProd.Columns.Remove("Product");
            dataGridView_ProjProd.Columns.Remove("Project");
            dataGridView_ProjProd.Columns[1].Width = 200;
            projProdCont.ChangeAllocationOfProjectProducstListInDb(ProjectId, ProjProds);
        }

        private void btn_ProjProdSave_Click(object sender, EventArgs e)
        {
            projProdCont.ChangeAllocationOfProjectProducstListInDb(ProjectId,ProjProds);
            this.Close();
        }

        private void btn_ProdToPool_Click(object sender, EventArgs e)
        {
            
            DataGridViewRow row = dataGridView_ProjProd.SelectedRows[0];
            int ProdId = (int)row.Cells[0].Value;
            int index = dataGridView_ProjProd.CurrentCell.RowIndex;
            ProjProds.RemoveAt(index);
            using (ProductController prodCont = new ProductController())
            {
                Product addProd = prodCont.GetProductById(ProdId);
                AllProds.Add(addProd);
                projProdCont.ChangeAllocationOfProjectProducstListInDb(ProjectId, ProjProds);
            }   
            dataGridView_prodAvail .DataSource = null;
            dataGridView_prodAvail.DataSource = AllProds;
            dataGridView_ProjProd.DataSource = null;
            dataGridView_ProjProd.DataSource = ProjProds;
            dataGridView_ProjProd.Columns.Remove("Project_Id");
            dataGridView_ProjProd.Columns.Remove("Product");
            dataGridView_ProjProd.Columns.Remove("Project");
            dataGridView_ProjProd.Columns[1].Width = 200;
        }

        private void btn_ProjProdCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
