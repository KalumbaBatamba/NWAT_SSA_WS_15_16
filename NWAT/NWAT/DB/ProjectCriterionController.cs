﻿using NWAT.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NWAT.DB
{
    public class ProjectCriterionController : DbController
    {
        public ProjectCriterionController() : base() { }
        public ProjectCriterionController(NWATDataContext dataContext)
            : base(dataContext) { }

        /// <summary>
        /// Gets the project criterion by ids.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns>
        /// An instance of 'ProjectCriterion' 
        /// </returns>
        /// Erstellt von Joshua Frey, am 18.12.2015
        public ProjectCriterion GetProjectCriterionByIds(int projectId, int criterionId)
        {
            ProjectCriterion resultProjectCriterion = base.DataContext.ProjectCriterion.SingleOrDefault(projectCriterion => projectCriterion.Criterion_Id == criterionId 
                                                                              && projectCriterion.Project_Id == projectId);
            return resultProjectCriterion;
        }

        /// <summary>
        /// Gets all project criterions for one project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        /// A list of all project criterions of one project
        /// </returns>
        /// Erstellt von Joshua Frey, am 21.12.2015
        public List<ProjectCriterion> GetAllProjectCriterionsForOneProject(int projectId)
        {
            var resultProjectCriterions = base.DataContext.ProjectCriterion.Where(projectCriterion => projectCriterion.Project_Id == projectId).ToList();
            return resultProjectCriterions;
        }

        /// <summary>
        /// Gets the child criterions by project identifier and parent identifier.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns>
        /// A list with all project criterions where project id = given project id and parent id = given parent id
        /// </returns>
        /// Erstellt von Joshua Frey, am 21.12.2015
        public List<ProjectCriterion> GetChildCriterionsByParentId(int projectId, int parentId)
        {
            List<ProjectCriterion> resultProjectCriterions = base.DataContext.ProjectCriterion.Where(projectCriterion => projectCriterion.Parent_Criterion_Id == parentId
                                                                                                     && projectCriterion.Project_Id == projectId).ToList();
            return resultProjectCriterions;
        }


        /// <summary>
        /// Gets the base project criterions.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        /// A list of all base criterions in first layer.
        /// </returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        public List<ProjectCriterion> GetBaseProjectCriterions(int projectId)
        {
            List<ProjectCriterion> baseCriterions = base.DataContext.ProjectCriterion.Where(projectCrit => projectCrit.Project_Id == projectId 
                                                                                                        && projectCrit.Parent_Criterion_Id == null).ToList();
            return baseCriterions;
        }


        /// <summary>
        /// Gets all project criterions which have given criterion as parent.
        /// Is used, when a criterion should be deleted in master table, but still has children in any project
        /// </summary>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        public List<ProjectCriterion> GetAllProjectCriterionsWhichHaveGivenCriterionAsParent(int criterionId)
        {
            return base.DataContext.ProjectCriterion.Where(projCrit => projCrit.Parent_Criterion_Id == criterionId).ToList();
        }

        /// <summary>
        /// Checks if project criterion already exists.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 20.01.2016
        public bool CheckIfProjectCriterionAlreadyExists(int projectId, int criterionId)
        {
            ProjectCriterion existingProjCrit = GetProjectCriterionByIds(projectId, criterionId);
            return existingProjCrit != null;
        }

        /// <summary>
        /// Gets the highest layer number in project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 20.01.2016
        public int GetHighestLayerNumberInProject(int projectId)
        {
            ProjectCriterion projCritWithHighestLayerNum = base.DataContext.ProjectCriterion.OrderByDescending(projCrit => projCrit.Layer_Depth).FirstOrDefault();
            return projCritWithHighestLayerNum.Layer_Depth;
        }


        /// <summary>
        /// Updates all project criterions. Is used to get a better performance when you update in balance view and structure view
        /// </summary>
        /// <param name="allChangedProjectCriterions">All changed project criterions.</param>
        /// Erstellt von Joshua Frey, am 28.01.2016
        public void UpdateAllProjectCriterions(int projectId, List<ProjectCriterion>allChangedProjectCriterions)
        {
            UpdateAllProjectCriterionDataSets(projectId, allChangedProjectCriterions);
            UpdateLayerDepthForAllProjectCriterions(projectId);
            UpdateAllPercentageLayerWeightings(projectId);
            UpdateAllPercentageProjectWeightings(projectId);
        }


        /// <summary>
        /// Updates all changed project criterions in der DB data sets.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="allChangedProjectCriterions">All changed project criterions.</param>
        /// Erstellt von Joshua Frey, am 28.01.2016
        public void UpdateAllProjectCriterionDataSets(int projectId, List<ProjectCriterion> allChangedProjectCriterions)
        {
            var projCritsFromDb = base.DataContext.ProjectCriterion.Where(projCrit => projCrit.Project_Id == projectId);

            foreach (var changedProjCrit in allChangedProjectCriterions)
            {
                var dbProjCrit = projCritsFromDb.Single(projCrit => projCrit.Criterion_Id == changedProjCrit.Criterion_Id);
                dbProjCrit.Parent_Criterion_Id = changedProjCrit.Parent_Criterion_Id;
                dbProjCrit.Layer_Depth = changedProjCrit.Layer_Depth;
                dbProjCrit.Weighting_Cardinal = changedProjCrit.Weighting_Cardinal;
                dbProjCrit.Weighting_Percentage_Layer = changedProjCrit.Weighting_Percentage_Layer;
                dbProjCrit.Weighting_Percentage_Project = changedProjCrit.Weighting_Percentage_Project;
            }

            base.DataContext.SubmitChanges();
        }

        /// <summary>
        /// Updates the project criterion in database.
        /// </summary>
        /// <param name="alteredProjectCriterion">The altered project criterion.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        /// <exception cref="NWATException"></exception>
        public bool UpdateProjectCriterionInDb(ProjectCriterion alteredProjectCriterion)
        {
            bool updateSuccess;
            updateSuccess = UpdateProjectCriterionDataSet(alteredProjectCriterion);
            if (!updateSuccess)
            {
                throw new NWATException(MessageUpdateProjectCriterionFailed(alteredProjectCriterion.Criterion.Name));
            }

            int projectId = alteredProjectCriterion.Project_Id;
            UpdateLayerDepthForSingleProjectCriterion(projectId, alteredProjectCriterion.Criterion_Id);
            UpdateAllPercentageLayerWeightings(projectId);
            UpdateAllPercentageProjectWeightings(projectId);

            return updateSuccess; 
        }

        /// <summary>
        /// Exports the project criterion from database.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 26.01.2016
        public bool ExportProjectCriterionFromDb(int projectId, int criterionId)
        {
            return DeleteProjectCriterionFromDb(projectId, criterionId, true);
        }

        /// <summary>
        /// Deletes the project criterion from database.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 26.01.2016
        public bool DeleteProjectCriterionFromDb(int projectId, int criterionId)
        {
            return DeleteProjectCriterionFromDb(projectId, criterionId, false);
        }

        /// <summary>
        /// Deletes the project criterion from database. This can also be called when a master criterion should be deleted
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 04.01.2016
        public bool DeleteProjectCriterionFromDb(int projectId, int criterionId, bool isExported)
        {
            bool success;
            success = DeleteProjectCriterionDataSet(projectId, criterionId);
            if (!success)
            {
                throw new NWATException(MessageDeleteProjectCriterionFailed(criterionId.ToString()));
            }
            if (!isExported)
            {
                UpdateAllPercentageLayerWeightings(projectId);
                UpdateAllPercentageProjectWeightings(projectId);
            }


            return success;
        }
        
        /// <summary>
        /// Changes the allocation of project criterions in database.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="newProjectCriterionList">The new project criterion list.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        public bool ChangeAllocationOfProjectCriterionsInDb(int projectId, List<ProjectCriterion> newProjectCriterionList)
        {
            bool deallocationSuccessful = true;
            bool allocationSuccessful = true;

            List<ProjectCriterion> projCritlistFromDb = GetAllProjectCriterionsForOneProject(projectId);

            List<ProjectCriterion> newToAdd = GetNewProjectCriterionsWhichWereAllocated(projCritlistFromDb, newProjectCriterionList);
            foreach (ProjectCriterion projCrit in newToAdd)
            {
                allocationSuccessful = AllocateCriterion(projectId, projCrit);
            }


            List<ProjectCriterion> oldToDelete = GetOldProjectCriterionsWhichWereDeallocated(projCritlistFromDb, newProjectCriterionList);
            
            foreach (ProjectCriterion projCrit in oldToDelete)
            {
                // check if project criterion does still exist
                // if not, the criterion was a child Criterion and was deleted in any loop before by deletion of its parent criterion
                if (projCrit.Criterion_Id != 0)
                {
                    deallocationSuccessful = DeallocateCriterionAndAllChildCriterions(projectId, projCrit);
                }
            }
            
             
            return deallocationSuccessful && allocationSuccessful;
        }

        /// <summary>
        /// Imports the project criterion.
        /// </summary>
        /// <param name="importProjectCriterion">The import project criterion.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 20.01.2016
        public bool ImportProjectCriterion(ProjectCriterion importProjectCriterion)
        {
            return InsertProjectCriterionIntoDb(importProjectCriterion, true);
        }


        /// <summary>
        /// Kriterienstruktur sortieren um richtige Ausgabe an Printer Klassen übergeben zu können
        /// </summary>
        /// Erstellt von Adrian Glasnek
        /// 

        public List<ProjectCriterion> GetSortedCriterionStructure(int projectId)
        {
            List<ProjectCriterion> sortedCriterionStructure = new List<ProjectCriterion>();

            List<ProjectCriterion> baseCriterion = GetBaseProjectCriterions(projectId);

            //Methode bekommt alle Basis Kriterien (aus Ebene 1), Projekt Id und Liste sortedCriterionStructure übergeben
            FillSortedStructureList(projectId, baseCriterion, ref sortedCriterionStructure);

            //Gibt die Liste mit den sortierten Kriterien zurück
            return sortedCriterionStructure;
        }


        /// <summary>
        /// Deallocates the criterion and all child criterions from project. This includes the entries in the fulfillment table
        /// User will be asked, if children should be deallocated
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="projCrit">The proj crit.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 13.01.2016
        public bool DeallocateCriterionAndAllChildCriterions(int projectId, ProjectCriterion projCrit)
        {
            return DeallocateCriterionAndAllChildCriterions(projectId, projCrit, false);
        }

        /// <summary>
        /// Deallocates the criterion and all child criterions from project. This includes the entries in the fulfillment table
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="projCrit">The proj crit.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 04.01.2016
        public bool DeallocateCriterionAndAllChildCriterions(int projectId, ProjectCriterion projCrit, bool forceDeallocationOfChildren)
        {
            int projectCriterionId = projCrit.Criterion_Id;
            // checks if criterion has any children criterion (is a parent criterion)
            List<ProjectCriterion> eventualChildCriterions = GetChildCriterionsByParentId(projectId, projectCriterionId);
            bool deletionPermitted = true;
            if (eventualChildCriterions.Count > 0)
            {
                string decisionMessage = MessageUserDecisionOfDeallocatingAllChildCriterions(projCrit, eventualChildCriterions);
                const string caption = "Kriterienentkopplung";

                // only ask user if children should be deallocated when forceDeallocationOfChildre = false
                if (!forceDeallocationOfChildren)
                {
                    var result = MessageBox.Show(decisionMessage, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        deletionPermitted = false;
                    }
                }

                if (deletionPermitted)
                {
                    foreach (ProjectCriterion childProjCrit in eventualChildCriterions)
                    {
                        deletionPermitted = DeallocateCriterionAndAllChildCriterions(projectId, childProjCrit, forceDeallocationOfChildren);
                    }
                }
            }
            string projCritName = projCrit.Criterion.Name;
            if (deletionPermitted)
            {
                // delete all fulfillment entries which point to this project criterion
                bool fulfillmentDeletionSuccessfull;
                using (FulfillmentController fulfillmentContr = new FulfillmentController())
                {
                    fulfillmentDeletionSuccessfull = fulfillmentContr.DeleteAllFulfillmentsForOneCriterionInOneProject(projectId, projCrit.Criterion_Id);
                }

                if (fulfillmentDeletionSuccessfull && DeleteProjectCriterionFromDb(projectId, projectCriterionId))
                {
                    if (!forceDeallocationOfChildren)
                    {
                        MessageBox.Show("Das Kriterium " + projCritName + " wurde erfolgreich vom Projekt entkoppelt.");
                    }

                    return true;
                }
                else
                {
                    MessageBox.Show("Bei dem Löschvorgang ist ein Fehler aufgetreten.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Löschen von " + projCritName + " konnte nicht durchgeführt werden, weil ein Löschvorgang vom Benutzer abgelehnt wurde.");
                return false;
            }
        }

      

        /*
        * Private Section
        */

        /// <summary>
        /// Methode mit einer rekursiven foreach-Schleife um alle Kindes Kinder zu erfassen
        /// </summary>
        /// Erstellt von Adrian Glasnek
        /// 

        private void FillSortedStructureList(int projectId, List<ProjectCriterion> siblingCriterions, ref List<ProjectCriterion> sortedCriterionStructure)
        {
            foreach (ProjectCriterion sibling in siblingCriterions)
            {
                sortedCriterionStructure.Add(sibling);

                List<ProjectCriterion> childrenCriterions = GetChildCriterionsByParentId(projectId, sibling.Criterion_Id);

                //Rekursive if Abfrage bzw. Methodenaufruf um alle Kinder und Kindeskinder zu bekommen

                if (childrenCriterions.Count > 0)
                {
                    FillSortedStructureList(projectId, childrenCriterions, ref sortedCriterionStructure);
                }
            }
            
        }

        private bool InsertProjectCriterionIntoDb(ProjectCriterion newProjectCriterion)
        {
            return InsertProjectCriterionIntoDb(newProjectCriterion, false);
        }

        /// <summary>
        /// Inserts the project criterion into database.
        /// </summary>
        /// <param name="newProjectCriterion">The new project criterion.</param>
        /// <returns>
        /// bool if insertion was sucessfully
        /// </returns>
        /// Erstellt von Joshua Frey, am 22.12.2015
        /// <exception cref="NWATException">
        /// </exception>
        private bool InsertProjectCriterionIntoDb(ProjectCriterion newProjectCriterion, bool isImported)
        {
            bool success;
            try
            {
                success = InsertProjectCriterionDataSet(newProjectCriterion, isImported);
            }
            catch (Exception e)
            {
                throw (e);
            }
            if (success)
            {
                int projectId = newProjectCriterion.Project_Id;

                if(!isImported)
                {
                    UpdateLayerDepthForSingleProjectCriterion(projectId, newProjectCriterion.Criterion_Id);
                    UpdateAllPercentageLayerWeightings(projectId);
                    UpdateAllPercentageProjectWeightings(projectId);
                }
            }
            return success;
        }

        /// <summary>
        /// Inserts the project criterion data set into Db
        /// </summary>
        /// <param name="newProjectCriterion">The new project criterion.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        /// <exception cref="NWATException">
        /// </exception>
        private bool InsertProjectCriterionDataSet(ProjectCriterion newProjectCriterion, bool isImported)
        {
            if (newProjectCriterion != null)
            {
                int projectId = newProjectCriterion.Project_Id;
                int criterionId = newProjectCriterion.Criterion_Id;

                if (!isImported)
                {
                    // set equal weighting when inserting a new project criterion
                    newProjectCriterion.Weighting_Cardinal = 1;
                    // set default layer depth to 1
                    newProjectCriterion.Layer_Depth = 1;
                }
                // if == null then this project criterion does not exist yet and it can be inserted into db
                if (!CheckIfProjectCriterionAlreadyExists(projectId, criterionId))
                {
                    base.DataContext.ProjectCriterion.InsertOnSubmit(newProjectCriterion);
                    base.DataContext.SubmitChanges();
                }

                // project criterion already exists --> throw exception
                else
                {
                    ProjectCriterion alreadyExistingProjectCriterion = this.GetProjectCriterionByIds(projectId, criterionId);
                    string projectName = alreadyExistingProjectCriterion.Project.Name;
                    string criterionName = alreadyExistingProjectCriterion.Criterion.Name;
                    throw (new NWATException((MessageProjectCriterionAlreadyExists(projectName, criterionName))));
                }
                return checkIfSameProjectCriterions(newProjectCriterion, this.GetProjectCriterionByIds(projectId, criterionId));
            }
            else
            {
                throw (new NWATException(MessageProjectCriterionCouldNotBeSavedEmptyObject()));
            }
        }


        /// <summary>
        /// Updates the project criterion data set.
        /// </summary>
        /// <param name="alteredProjectCriterion">The altered project criterion.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private bool UpdateProjectCriterionDataSet(ProjectCriterion alteredProjectCriterion)
        {
            int projectId = alteredProjectCriterion.Project_Id;
            int criterionId = alteredProjectCriterion.Criterion_Id;
            ProjectCriterion resultProjectCriterion = base.DataContext.ProjectCriterion.SingleOrDefault(projectCriterion => projectCriterion.Criterion_Id == criterionId
                                                                           && projectCriterion.Project_Id == projectId);
            resultProjectCriterion.Parent_Criterion_Id = alteredProjectCriterion.Parent_Criterion_Id;
            resultProjectCriterion.Weighting_Cardinal = alteredProjectCriterion.Weighting_Cardinal;
            resultProjectCriterion.Layer_Depth = alteredProjectCriterion.Layer_Depth;
            resultProjectCriterion.Weighting_Percentage_Layer = alteredProjectCriterion.Weighting_Percentage_Layer;
            resultProjectCriterion.Weighting_Percentage_Project = alteredProjectCriterion.Weighting_Percentage_Project;
            base.DataContext.SubmitChanges();

            ProjectCriterion changedProjCritFromDb = GetProjectCriterionByIds(alteredProjectCriterion.Project_Id, alteredProjectCriterion.Criterion_Id);

            bool successfulUpdate = checkIfSameProjectCriterions(alteredProjectCriterion, changedProjCritFromDb);

            return successfulUpdate;

        }


        /// <summary>
        /// Deletes the project criterion data set.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="criterionId">The criterion identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private bool DeleteProjectCriterionDataSet(int projectId, int criterionId)
        {
            ProjectCriterion delProjCrit = (from projCrit in base.DataContext.ProjectCriterion
                                            where projCrit.Project_Id == projectId
                                            && projCrit.Criterion_Id == criterionId
                                            select projCrit).FirstOrDefault();
            base.DataContext.ProjectCriterion.DeleteOnSubmit(delProjCrit);
            base.DataContext.SubmitChanges();

            return GetProjectCriterionByIds(projectId, criterionId) == null;
        }

        /// <summary>
        /// Allocates the criterion.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="projCrit">The proj crit.</param>
        /// <returns>
        /// bool if insertions in projectCriterion table and fulfillment table were successful
        /// </returns>
        /// Erstellt von Joshua Frey, am 04.01.2016
        /// <exception cref="NWATException"></exception>
        private bool AllocateCriterion(int projectId, ProjectCriterion projCrit)
        {
            bool insertionProjectCritionSuccessful = true;
            bool insertionFulfillmentSuccessful = true;

            int projCritId = projCrit.Criterion_Id;
            if (projCritId != 0 && projCrit.Project_Id != 0)
            {
                insertionProjectCritionSuccessful = InsertProjectCriterionIntoDb(projCrit);

                // get all project products for insertion to fulfillment table
                List<ProjectProduct> allProjectProducts;
                using (ProjectProductController projProdCont = new ProjectProductController())
                {
                    allProjectProducts = projProdCont.GetAllProjectProductsForOneProject(projectId);
                }

                // insert criterions into fulfillment table for each product
                using (FulfillmentController fulfillContr = new FulfillmentController())
                {
                    foreach (ProjectProduct projProd in allProjectProducts)
                    {
                        int productId = projProd.Product_Id;

                        // new fulfillment which will be inserted into fulfillment table.
                        // default values for Fulfilled and Comment (false and null)
                        Fulfillment newFulfillment = new Fulfillment()
                        {
                            Project_Id = projectId,
                            Product_Id = productId,
                            Criterion_Id = projCritId,
                            Fulfilled = false,
                            Comment = null
                        };

                        if (!fulfillContr.InsertFullfillmentInDb(newFulfillment))
                        {
                            insertionFulfillmentSuccessful = false;
                            throw (new NWATException(CommonMethods.MessageInsertionToFulFillmentTableFailed(productId, projCritId)));
                        }
                    }
                }
            }
            return insertionFulfillmentSuccessful && insertionProjectCritionSuccessful;
        }

        /// <summary>
        /// Updates all percentage layer weightings for one project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// Erstellt von Joshua Frey, am 04.01.2016
        private void UpdateAllPercentageLayerWeightings(int projectId)
        {
            // calculate all weightings for the base layer
            List<ProjectCriterion> baseProjectCriterions = GetBaseProjectCriterions(projectId);
            CalculatePercentageLayerWeighting(ref baseProjectCriterions);

            // write calculated weightings back to db
            UpdateAllProjectCriterionDataSets(projectId, baseProjectCriterions);

            // calculate all weightings for all child project criterions
                       
            List<ProjectCriterion> allProjectCriterions = GetAllProjectCriterionsForOneProject(projectId);

            foreach (ProjectCriterion projCrit in allProjectCriterions)
            {
                List<ProjectCriterion> eventualChildrenOfCurrentProjCriterion = GetChildCriterionsByParentId(projectId, projCrit.Criterion_Id);
                if (eventualChildrenOfCurrentProjCriterion.Count > 0)
                {
                    CalculatePercentageLayerWeighting(ref eventualChildrenOfCurrentProjCriterion);
                    foreach (ProjectCriterion childProjCrit in eventualChildrenOfCurrentProjCriterion)
                    {
                        ProjectCriterion projCritToChangeInCompleteList = allProjectCriterions.Single(
                            projCritToChange => projCritToChange.Criterion_Id == childProjCrit.Criterion_Id);
                        projCritToChangeInCompleteList.Weighting_Percentage_Layer = childProjCrit.Weighting_Percentage_Layer;
                    }
                }
            }
            UpdateAllProjectCriterionDataSets(projectId, allProjectCriterions);
        }

        /// <summary>
        /// Updates all percentage project weighting2.
        /// </summary>
        /// Erstellt von Joshua Frey, am 20.01.2016
        private void UpdateAllPercentageProjectWeightings(int projectId)
        {
            List<ProjectCriterion> allProjCritsForOneProject = GetAllProjectCriterionsForOneProject(projectId);

            foreach (ProjectCriterion currentProjCrit in allProjCritsForOneProject)
            {
                currentProjCrit.Weighting_Percentage_Project = UpdatePercentageProjectWeightingForOneCriterion(currentProjCrit);
            }
            UpdateAllProjectCriterionDataSets(projectId, allProjCritsForOneProject);
        }

        /// <summary>
        /// Updates the percentage project weighting for one criterion.
        /// </summary>
        /// <param name="projectCrit">The project crit.</param>
        /// Erstellt von Joshua Frey, am 20.01.2016
        private double UpdatePercentageProjectWeightingForOneCriterion(ProjectCriterion projectCrit)
        {
            int projectId = projectCrit.Project_Id;
            int criterionId = projectCrit.Criterion_Id;

            double percentageProjectWeightingValue = 1;
            List<ProjectCriterion> allProjectCriterions = GetAllProjectCriterionsForOneProject(projectId);
            ProjectCriterion involvedProjCriterion;
            involvedProjCriterion = allProjectCriterions.Single(projCrit => projCrit.Criterion_Id == criterionId);

            bool hasParent = false;

            // traverse all parent criterions and multiply their layer weightings
            do
            {
                // multiplies weightingvalue by percentageLayerWeighting of current involved proj crit
                percentageProjectWeightingValue *= involvedProjCriterion.Weighting_Percentage_Layer.Value;
                if (involvedProjCriterion.Parent_Criterion_Id != null && involvedProjCriterion.Parent_Criterion_Id.Value != 0)
                {
                    int parentCritId = involvedProjCriterion.Parent_Criterion_Id.Value;
                    hasParent = true;
                    involvedProjCriterion = allProjectCriterions.Single(projCrit => projCrit.Criterion_Id == parentCritId);
                }
                else
                {
                    hasParent = false;
                }
            } while (hasParent);

            return Math.Round(percentageProjectWeightingValue, 6, MidpointRounding.ToEven);
        }

        //// Esrstellt von Weloko Tchokoua
        //public void UpdateAllPercentageProjectWeightings(int projectId)
        //{
        //    // calculate all weightings for the base layer

        //    List<ProjectCriterion> baseProjectCriterions = GetBaseProjectCriterions(projectId);
        //    CalculatePercentageProjectWeighting(ref baseProjectCriterions);

        //    // write calculated weightings back to db

        //    foreach (ProjectCriterion baseProjCrit in baseProjectCriterions)
        //    {
        //        UpdateProjectCriterionDataSet(baseProjCrit);
        //    }

        //    // calculate all weightings for all child project criterions

        //    List<ProjectCriterion> allProjectCriterions = GetAllProjectCriterionsForOneProject(projectId);

        //    foreach (ProjectCriterion projCrit in allProjectCriterions)
        //    {
        //        List<ProjectCriterion> eventualChildrenOfCurrentProjCriterion = GetChildCriterionsByParentId(projectId, projCrit.Criterion_Id);
        //        if (eventualChildrenOfCurrentProjCriterion.Count > 0)
        //        {
        //            CalculatePercentageProjectWeighting(ref eventualChildrenOfCurrentProjCriterion);
        //            foreach (ProjectCriterion childProjCrit in eventualChildrenOfCurrentProjCriterion)
        //            {
        //                UpdateProjectCriterionDataSet(childProjCrit);
        //            }
        //        }
        //    }

        //}




        /// <summary>
        /// Checks if same project criterions.
        /// </summary>
        /// <param name="projCritOne">The proj crit one.</param>
        /// <param name="projCritTwo">The proj crit two.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private static bool checkIfSameProjectCriterions(ProjectCriterion projCritOne, ProjectCriterion projCritTwo)
        {
            bool sameParentCritId = projCritOne.Parent_Criterion_Id == projCritTwo.Parent_Criterion_Id;
            bool sameLayerDepth = projCritOne.Layer_Depth == projCritTwo.Layer_Depth;
            bool sameCardinalWeighting = projCritOne.Weighting_Cardinal == projCritTwo.Weighting_Cardinal;
            bool samePercentageLayerWeighting = projCritOne.Weighting_Percentage_Layer == projCritTwo.Weighting_Percentage_Layer;
            bool samePercentageProjectWeighting = projCritOne.Weighting_Percentage_Project == projCritTwo.Weighting_Percentage_Project;

            return sameCardinalWeighting &&
                   sameLayerDepth &&
                   sameParentCritId &&
                   samePercentageLayerWeighting &&
                   samePercentageProjectWeighting;
        }

        /// <summary>
        /// Updates the lyer depth for all project criterions.
        /// </summary>
        /// Erstellt von Joshua Frey, am 28.01.2016
        private void UpdateLayerDepthForAllProjectCriterions(int projectId)
        {
            var allProjectCriterionsInDb = base.DataContext.ProjectCriterion.Where(projCrit => projCrit.Project_Id == projectId);
            foreach (var projCritFromDb in allProjectCriterionsInDb)
            {
                int calculatedLayerDepth = GetLayerDepthForSingleProjectCriterion(projCritFromDb, allProjectCriterionsInDb.ToList());
                projCritFromDb.Layer_Depth = calculatedLayerDepth;
            }
            base.DataContext.SubmitChanges();
        }

        /// <summary>
        /// Calculates the layer depth of the Criterion and updates it in Database;
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="projCritId">The proj crit identifier.</param>
        /// Erstellt von Joshua Frey, am 12.01.2016
        private void UpdateLayerDepthForSingleProjectCriterion(int projectId, int projCritId)
        {
            // base criterions are on layer one. So the lowest layer a criterion can exist in, is 1

            List<ProjectCriterion> allProjectCriterions = GetAllProjectCriterionsForOneProject(projectId);
            ProjectCriterion involvedProjCriterion;
            involvedProjCriterion = allProjectCriterions.Single(projCrit => projCrit.Criterion_Id == projCritId);

            int layerCounter = GetLayerDepthForSingleProjectCriterion(involvedProjCriterion, allProjectCriterions);

            ProjectCriterion projCritToUpdate = allProjectCriterions.Single(projCrit => projCrit.Criterion_Id == projCritId);
            projCritToUpdate.Layer_Depth = layerCounter;
                UpdateProjectCriterionDataSet(projCritToUpdate);
        }

        /// <summary>
        /// Gets the layer depth for single project criterion.
        /// </summary>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 28.01.2016
        private int GetLayerDepthForSingleProjectCriterion(ProjectCriterion involvedProjCriterion, List<ProjectCriterion> allProjectCriterionsForThisProject)
        {
            bool hasParent = false;
            int layerCounter = 1;
            // traverse all parent criterion and count them in layerCounter
            do
            {
                // check if involvedProjCriterion has a parent
                if (involvedProjCriterion.Parent_Criterion_Id != null && involvedProjCriterion.Parent_Criterion_Id.Value != 0)
                {
                    int parentCritId = involvedProjCriterion.Parent_Criterion_Id.Value;
                    hasParent = true;
                    // for each parent inkrement counter
                    layerCounter++;
                    // parent is new involvedProjCriterion now
                    involvedProjCriterion = allProjectCriterionsForThisProject.Single(projCrit => projCrit.Criterion_Id == parentCritId);
                }
                else
                {
                    hasParent = false;
                }
            } while (hasParent);
            return layerCounter;
        }


        /// <summary>
        /// Calculates the percentage layer weighting for one Layer. 
        /// </summary>
        /// <param name="projectCriterionsInOneLayer">Reference of a IEnumerable of the project criterions in one layer.</param>
        /// Erstellt von Joshua Frey, am 04.01.2016
        public void CalculatePercentageLayerWeighting(ref List<ProjectCriterion> projectCriterionsInOneLayer)
        {
            int sumOfCardinalWeightings = 0;
            foreach (ProjectCriterion projCrit in projectCriterionsInOneLayer)
            {
                sumOfCardinalWeightings += projCrit.Weighting_Cardinal;
            }

            foreach (ProjectCriterion projCrit in projectCriterionsInOneLayer)
            {
                // provide that there is nothing is divided by zero
                if (sumOfCardinalWeightings == 0)
                {
                    projCrit.Weighting_Percentage_Layer = 0;
                }
                else
                {
                    double percentageLayerWeighting = (double)projCrit.Weighting_Cardinal / (double)sumOfCardinalWeightings;
                    projCrit.Weighting_Percentage_Layer = Math.Round(percentageLayerWeighting, 6, MidpointRounding.ToEven);
                }
            }
        }

       

        //// Erstellt von Weloko Tchokoua
        //public void CalculatePercentageProjectWeighting(ref List<ProjectCriterion> resultProjectCriterions)
        //{
        //    int projectId = 0;
        //   //List<ProjectCriterion> allProjectCriterions = GetAllProjectCriterionsForOneProject(projectId);
        //    List<ProjectCriterion> papa = GetBaseProjectCriterions(projectId);
        //    List<ProjectCriterion> basecrit = GetBaseProjectCriterions(projectId);
        //    float sumweightinglayeronecrit = 0;
        //    float sumweigthinglayerseconddepth =0;
        //    float parentprojectweightinglayer =0;
        //    //double parentprojectfirstlayer = 0;

        //    foreach (ProjectCriterion all in resultProjectCriterions)
        //        foreach (ProjectCriterion parent in papa)
        //        {
        //            List<ProjectCriterion> childcrit = GetChildCriterionsByParentId(projectId, parent.Criterion_Id);

        //            foreach (ProjectCriterion son in childcrit)
        //            {

        //                if (parent.Criterion_Id == son.Parent_Criterion_Id)
        //                {
        //                    UpdateAllPercentageLayerWeightings(projectId);
        //                    UpdateLayerDepthForProjectCriterion(projectId, all.Criterion_Id);
        //                    int maxlayer = int.MaxValue;
        //                    maxlayer = Math.Max(all.Layer_Depth, maxlayer) + 1;
        //                    for (all.Layer_Depth = 1; all.Layer_Depth <= maxlayer; all.Layer_Depth--)
        //                    {

        //                        sumweightinglayeronecrit += (float)son.Weighting_Percentage_Layer.Value;
        //                        parentprojectweightinglayer = sumweightinglayeronecrit * (float)parent.Weighting_Percentage_Layer.Value;

        //                        parent.Weighting_Percentage_Project = parentprojectweightinglayer;
        //                        foreach (ProjectCriterion papaohneparent in basecrit)
        //                        {
        //                            while (son.Layer_Depth == 2)
        //                            {
        //                                sumweigthinglayerseconddepth += (float)son.Weighting_Percentage_Project;
        //                                papaohneparent.Weighting_Percentage_Project = sumweigthinglayerseconddepth;
        //                            }


        //                        }


        //                    }
        //                }

        //            }



        //        }
            
            
        //}

        /// <summary>
        /// Checks if parent exists in project as project criterion.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="parentCritId">The parent crit identifier.</param>
        /// <returns>
        /// bool which says if given parent is a projectCriterion
        /// </returns>
        /// Erstellt von Joshua Frey, am 22.12.2015
        private bool CheckIfParentExistsInProjectAsProjectCriterion(int projectId, int parentCritId)
        {
            ProjectCriterion resultProjectCriterion = base.DataContext.ProjectCriterion.FirstOrDefault(projectCriterion => projectCriterion.Project_Id == projectId && projectCriterion.Criterion_Id == parentCritId);
            if (resultProjectCriterion == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Gets the old project criterions which were deallocated in a new list. This list contains all project criterions
        /// which have to be deleted in the db table
        /// </summary>
        /// <param name="listFromDb">The list from database.</param>
        /// <param name="newProjectCriterionList">The new project criterion list.</param>
        /// <returns>
        /// A list that contains all project criterions
        /// which have to be deleted in the db table
        /// </returns>
        /// Erstellt von Joshua Frey, am 28.12.2015
        private List<ProjectCriterion> GetOldProjectCriterionsWhichWereDeallocated(List<ProjectCriterion> listFromDb,
                                                                                   List<ProjectCriterion> newProjectCriterionList)
        {
            List<ProjectCriterion> resultProjCritList = new List<ProjectCriterion>();
            
            foreach(ProjectCriterion projCritFromDb in listFromDb)
            {
                ProjectCriterion projCritExistingInBothList = newProjectCriterionList.SingleOrDefault(newProjCrit => 
                                                                    newProjCrit.Criterion_Id == projCritFromDb.Criterion_Id);
                if (projCritExistingInBothList == null)
                {
                    resultProjCritList.Add(projCritFromDb);
                }
            }
            return resultProjCritList;
        }

        /// <summary>
        /// Gets the new project criterions which were allocated in a new list. This list contains all project criterions
        /// which have to be inserted into the db table
        /// </summary>
        /// <param name="listFromDb">The list from database.</param>
        /// <param name="newProjectCriterionList">The new project criterion list.</param>
        /// <returns> 
        /// A list that contains all project criterions
        /// which have to be inserted in the db table
        /// </returns>
        /// Erstellt von Joshua Frey, am 28.12.2015
        private List<ProjectCriterion> GetNewProjectCriterionsWhichWereAllocated(List<ProjectCriterion> listFromDb, 
                                                                                 List<ProjectCriterion> newProjectCriterionList)
        {
            List<ProjectCriterion> resultProjCritList = new List<ProjectCriterion>();

            foreach (ProjectCriterion newAllocatedCrit in newProjectCriterionList)
            {
                ProjectCriterion projCritExistingInBothLists = listFromDb.SingleOrDefault(allocatedCritInDb =>
                                                    allocatedCritInDb.Criterion_Id == newAllocatedCrit.Criterion_Id);
                if (projCritExistingInBothLists == null)
                {
                    resultProjCritList.Add(newAllocatedCrit);
                }
            }

            return resultProjCritList;
        }


        /*
         Messages
         */
        private string MessageProjectCriterionCouldNotBeSavedEmptyObject()
        {
            return "Das Projektkriterium konnte nicht in der Datenbank gespeichert werden." +
                   " Bitte überprüfen Sie das übergebene Projektkriterium Objekt.";
        }

        private string MessageProjectCriterionAlreadyExists(string projectName, string criterionName)
        {
            return "Das Kriterium mit dem Namen \"" + criterionName +
                   "\" ist bereits dem Projekt \"" + projectName + "\" zugeordnet";
        }


        private static string MessageUserDecisionOfDeallocatingAllChildCriterions(ProjectCriterion projCrit, List<ProjectCriterion> eventualChildCriterions)
        {
            string critName = projCrit.Criterion.Name;
            // user is asked if he wants to deallocate the subordinated criterions
            string decisionMessage = @"Dem Kriterium " + critName + " sind noch folgende Kriterien untergeordnet: \n";
            foreach (ProjectCriterion childProjCrit in eventualChildCriterions)
            {
                decisionMessage += childProjCrit.Criterion.Name + "\n";
            }
            decisionMessage += "Wenn Sie das Kriterium dem Projekt entziehen, werden auch alle untergeordneten Kriterien dem Projekt entzogen\n" +
                "Des Weiteren werden alle Erfüllungseinträge mit den betroffenen Kriterien für dieses Projekt entfernt.\n" +
                "Möchten Sie das Kriterium " + critName + " und dessen Unterkriterien vom Projekt entkoppeln?";
            return decisionMessage;
        }

        private string MessageUpdateProjectCriterionFailed(string critName)
        {
            return String.Format(@"Das Projekt Kriteriums {0} konnte nicht in der Datenbank geändert werden.", critName);
        }

        private string MessageDeleteProjectCriterionFailed(string critName)
        {
            return String.Format(@"Das Projekt Kriteriums {0} konnte nicht aus der Datenbank gelöscht werden.", critName);
        }
     

    }
}
