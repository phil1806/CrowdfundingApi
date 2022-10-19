using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly  IProjectRepo _projectRepo;

        public ProjectService(IProjectRepo projectRepo)
        {
            _projectRepo = projectRepo;
        }
        public bool CreateProject()
        {
            throw new NotImplementedException();
        }

        public bool DeleteProject(int id)
        {
            return _projectRepo.DeleteProject(id);
        }

        public IEnumerable<Project> GetAllProjects()
        {
           
           return _projectRepo.GetAllProjects().Select(x=>x.toBLL());
        }

        public Project GetProjectById(int id)
        {
            return _projectRepo.GetProjectById(id).toBLL();
        }

        public IEnumerable<Project> GetValidProjects()
        {
            return _projectRepo.GetValidProjects().Select(x => x.toBLL());
        }

        public bool UpdateProject(int id, Project leProject)
        {
            return _projectRepo.UpdateProject(id, leProject.toDAL());
        }

        public bool ValidProject(int id)
        {
            return _projectRepo.ValidProject(id);
        }
    }
}
