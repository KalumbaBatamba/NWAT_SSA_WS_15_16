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
    public partial class Criterion_Create_View : Form
    {

        private CriterionController critCont;
        public Criterion_Create_View()
        {
         this.critCont = new CriterionController();
            InitializeComponent();
        }

        private void btn_CritCreate_Click(object sender, EventArgs e)
        {

        }
        private void CreateNewCrit()
        {

        }

        private void Criterion_Create_Form_Load(object sender, EventArgs e)
        {

        }
    }
}