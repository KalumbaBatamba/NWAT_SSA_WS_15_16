﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWAT.DB;

namespace NWAT
{
    class Analysis
    {
        private FulfillmentController fulfillContr;
        private ProjectCriterionController projCritContr;

        public Analysis()
        {
            this.fulfillContr = new FulfillmentController();
            this.projCritContr = new ProjectCriterionController();
        }

        
        

        // TODO By Yann
        public void Analyse()
        {
            // this instance of project criterion controller is needed to work with the Project_Criterion table
            ProjectCriterionController projCritController = new ProjectCriterionController();

            // This method will return all project ctiterions for one project
            int projectId = 0;
            List<ProjectCriterion> projectCriterions = projCritController.GetAllProjectCriterionsForOneProject(projectId);

            // this method will give you all children of one project criterion (id)
            int parentId = 1;
            List<ProjectCriterion> children = projCritController.GetChildCriterionsByParentId(projectId, parentId);

            // this method will return all project Criterions, which don't have any parent_id --> so the base criterions will be returned
            List<ProjectCriterion> baseCriterions = projCritController.GetBaseProjectCriterions(projectId);


     
            
        }
    }

    // TODO By Yann
    class AnalysisCriterionResult
    {
        private String critName; 
        private String critDescription;
        private int cardinalWeighting;
        private double layerPercentageWeighting; 
        private double projectPercentageWeighting;
        List<ProductCriterionFulfillmentResult> productResults;
    }

    // TODO By Yann
    class ProductCriterionFulfillmentResult
    {
        int criterionId;
        string productName;
        double result;
    }
}
