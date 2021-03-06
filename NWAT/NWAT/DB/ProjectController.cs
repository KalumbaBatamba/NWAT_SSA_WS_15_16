﻿using NWAT.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NWAT.DB
{
    public class ProjectController : DbController
    {

        public ProjectController() : base() { }
        public ProjectController(NWATDataContext dataContext)
            : base(dataContext) { }

        /// <summary>
        /// Gets the project by identifier from db.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// An instance of 'Project'
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        public Project GetProjectById(int id)
        {
            Project resultProject;

            resultProject = base.DataContext.Project.SingleOrDefault(project => project.Project_Id == id);
            return resultProject;
        }

        /// <summary>
        /// Gets all projects from database.
        /// </summary>
        /// <returns>
        ///  A linq table object with all projects from db
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        public List<Project> GetAllProjectsFromDB()
        {
            List<Project> projects;
            projects = base.DataContext.Project.ToList();
            return projects;
        }

        /// <summary>
        /// Checks if project identifier already exists.
        /// </summary>
        /// <param name="importProjId">The import proj identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 14.01.2016
        public bool CheckIfProjectIdAlreadyExists(int importProjId)
        {
            Project existingProj = GetProjectById(importProjId);
            return existingProj != null;
        }


        /// <summary>
        /// Imports the project into database.
        /// </summary>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 26.01.2016
        public bool ImportProjectIntoDb(Project importProject)
        {
            return InsertProjectIntoDb(importProject);
        }

        /// <summary>
        /// Inserts the project into database.
        /// </summary>
        /// <param name="newProject">The new project.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="NWATException">
        /// Das Projekt mit dem Namen -Projektname- existiert bereits in einem anderen Datensatz in der Datenbank.
        /// or
        /// Das Projekt konnte nicht in der Datenbank angelegt werden. 
        /// Bitte überprüfen Sie das übergebene Projekt Objekt.
        /// </exception>
        public bool InsertProjectIntoDb(Project newProject)
        {
            if (newProject != null)
            {
                // if insert Id is != 0 then this project will be imported at the index of insertId
                bool willBeImported = newProject.Project_Id != 0;

                string newProjectName = newProject.Name;
                if (!CheckIfProjectNameAlreadyExists(newProjectName))
                {
                    if (willBeImported)
                    {
                        if (CheckIfProjectIdAlreadyExists(newProject.Project_Id))
                        {
                            throw (new NWATException(MessageProjectIdAlreadyExists(newProject.Project_Id)));
                        }
                        else
                        {
                            base.DataContext.Project.InsertOnSubmit(newProject);
                            base.DataContext.SubmitChanges();
                        }
                    }
                    else
                    {
                        using (CurrentMasterDataIdsController masterDataIdsContr = new CurrentMasterDataIdsController())
                        {
                            CurrentMasterDataIds masterDataIdsSet = masterDataIdsContr.GetCurrentMasterDataIds();

                            int currentProjectId = masterDataIdsSet.CurrentProjectId;

                            // if you inserted a project manually and forgot to adjust the currentProjectId it will 
                            // increment to the free place and will use new id to insert new project
                            while (GetProjectById(currentProjectId) != null)
                            {
                                masterDataIdsContr.incrementCurrentCriterionId();
                                currentProjectId = masterDataIdsSet.CurrentCriterionId;
                            }

                            newProject.Project_Id = currentProjectId;
                            base.DataContext.Project.InsertOnSubmit(newProject);
                            base.DataContext.SubmitChanges();
                            masterDataIdsContr.incrementCurrentProjectId();
                        }
                    }
                }
                else
                {
                    throw (new NWATException(MessageProjectAlreadyExists(newProjectName)));
                }
            }
            else
            {
                throw (new NWATException(MessageProjectCouldNotBeSavedEmptyObject()));
            }

            Project newProjectFromDb = (from proj in base.DataContext.Project
                                            where proj.Name == newProject.Name
                                            && proj.Description == newProject.Description
                                            select proj).FirstOrDefault();

            return CheckIfEqualProjects(newProject, newProjectFromDb);
        }

        /// <summary>
        /// Updates the project in database.
        /// </summary>
        /// <param name="alteredProject">The altered project.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="NWATException">
        /// Das Projekt mit dem Namen -Projektname- existiert bereits in einem anderen Datensatz in der Datenbank.
        /// or
        /// Das Projekt konnte nicht in der Datenbank angelegt werden. 
        /// Bitte überprüfen Sie das übergebene Projekt Objekt.
        /// or 
        /// Das Project Object besitzt keine ID. Bitte überprüfen Sie das übergebene Object
        /// </exception>
        public bool UpdateProjectInDb(Project alteredProject)
        {
            if (!CheckIfProjectHasAnId(alteredProject))
                throw (new NWATException(MessageProjectHasNoId()));

            int projectId = alteredProject.Project_Id;
            Project projToUpdateFromDb = base.DataContext.Project.SingleOrDefault(proj => proj.Project_Id == projectId);

            if (projToUpdateFromDb != null)
            {
                string newProjectName = alteredProject.Name;
                if (!CheckIfProjectNameAlreadyExists(newProjectName, projectId))
                {
                    projToUpdateFromDb.Name = alteredProject.Name;
                    projToUpdateFromDb.Description = alteredProject.Description;
                }
                else
                {
                    throw (new NWATException(MessageProjectAlreadyExists(newProjectName)));
                }
            }
            else
            {
                throw (new NWATException(MessageProjectDoesNotExist(projectId) + "\n" +
                                                MessageProjectCouldNotBeSavedEmptyObject()));
            }
            base.DataContext.SubmitChanges();

            Project alteredCriterionFromDb = GetProjectById(projectId);
            return CheckIfEqualProjects(alteredProject, alteredCriterionFromDb);
        }

        /// <summary>
        /// Exports the project from database.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        /// Erstellt von Joshua Frey, am 26.01.2016
        public bool ExportProjectFromDb(int projectId)
        {
            return DeleteProjectFromDb(projectId);
        }

        /// <summary>
        /// Deletes the project from database.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>
        /// bool if deletion was successful
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        /// <exception cref="NWATException">
        /// "Das Projekt mit der Id X existiert nicht in der Datenbank."
        /// </exception>
        public bool DeleteProjectFromDb(int projectId)
        {
            Project delProject = (from proj in base.DataContext.Project
                                        where proj.Project_Id == projectId
                                        select proj).FirstOrDefault();
            if (delProject != null)
            {
                base.DataContext.Project.DeleteOnSubmit(delProject);
                base.DataContext.SubmitChanges();
            }
            else
            {
                throw (new NWATException(MessageProjectDoesNotExist(projectId)));
            }

            return GetProjectById(projectId) == null;
        }

        /// <summary>
        /// Checks if equal projects.
        /// </summary>
        /// <param name="projOne">The proj one.</param>
        /// <param name="projTwo">The proj two.</param>
        /// <returns>
        /// bool if given projects are equal
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        public bool CheckIfEqualProjects(Project projOne, Project projTwo)
        {

            bool equalName = CommonMethods.CompareStringWithoutWhitespaces(projOne.Name, projTwo.Name);
            bool equalDescription = CommonMethods.CompareStringWithoutWhitespaces(projOne.Description, projTwo.Description);

            return equalName && equalDescription;
        }

        /// <summary>
        /// Checks if project name already exists.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <returns>
        /// bool if project name already exists in db.
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        public bool CheckIfProjectNameAlreadyExists(String projectName)
        {
            Project projectWithExistingName = (from proj in base.DataContext.Project
                                               where proj.Name == projectName
                                               select proj).FirstOrDefault();
            if (projectWithExistingName != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if project name already exists.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="excludedId">The excluded identifier, which identifies the project, that should be updated.</param>
        /// <returns>
        /// bool if other project exist with name to which user want to update given project to.
        /// </returns>
        /// Erstellt von Joshua Frey, am 14.12.2015
        public bool CheckIfProjectNameAlreadyExists(String projectName, int excludedId)
        {
            Project projectWithExistingName = (from proj in base.DataContext.Project
                                               where proj.Name == projectName
                                               && proj.Project_Id != excludedId
                                               select proj).FirstOrDefault();
            if (projectWithExistingName != null)
                return true;
            else
                return false;
        }


        /*
         * Private Section
         */

        /// <summary>
        /// Checks if project has an identifier.
        /// </summary>
        /// <param name="proj">The proj.</param>
        /// <returns>
        /// bool if given Project has an id and it differs zero
        /// </returns>
        /// Erstellt von Joshua Frey, am 15.12.2015
        private bool CheckIfProjectHasAnId(Project proj)
        {
            if (proj.Project_Id == 0)
                return false;
            else
                return true;
        }


        /*
         Messages
         */

        private string MessageProjectCouldNotBeSavedEmptyObject()
        {
            return "Das Projekt konnte nicht in der Datenbank gespeichert werden." +
                   " Bitte überprüfen Sie das übergebene Projekt Objekt.";
        }

        private string MessageProjectAlreadyExists(string projectName)
        {
            return "Das Projekt mit dem Namen \"" + projectName +
                   "\" existiert bereits in einem anderen Datensatz in der Datenbank.";
        }

        private string MessageProjectIdAlreadyExists(int id)
        {
            return "Das Projekt mit der Id \"" + id.ToString() +
                   "\" existiert bereits in einem anderen Datensatz in der Datenbank.";
        }

        private string MessageProjectDoesNotExist(int projectId)
        {
            return "Das Projekt mit der Id \"" + projectId +
                   "\" existiert nicht in der Datenbank.";
        }

        private string MessageProjectHasNoId()
        {
            return "Das Project Object besitzt keine ID. Bitte überprüfen Sie das übergebene Object";
        }
    }
}
