using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAllProjects();
        IEnumerable<Project> GetValidProjects();
        Project GetProjectById(int id);
        bool CreateProject();

        bool ValidProject(int id);

        bool UpdateProject(int id, Project leProject);
        bool DeleteProject(int id);
    }
}
