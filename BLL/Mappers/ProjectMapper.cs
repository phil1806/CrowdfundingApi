using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLLM = BLL.Models;
using DALM = DAL.Models;

namespace BLL.Mappers
{
    public static class ProjectMapper
    {
        public static BLLM.Project toBLL(this DALM.Project project)
        {
            return new BLLM.Project
            {
                Id = project.Id,
                Titre = project.Titre,
                Description = project.Description,
                Objectif = project.Objectif,
                CompteBQ = project.CompteBQ,
                DateDebut = project.DateDebut,
                DateFin = project.DateFin,
                TypeStatus = project.TypeStatus,
                ContributionTotal =project.ContributionTotal,
                Paliers = project.Paliers?.Select(x => x.toBllPallier())
            };

        }

        public static DALM.Project toDAL(this BLLM.Project project)
        {
            return new DALM.Project
            {
                Id = project.Id,
                Titre = project.Titre,
                Description = project.Description,
                Objectif = project.Objectif,
                CompteBQ = project.CompteBQ,
                DateDebut = project.DateDebut,
                DateFin = project.DateFin,
                TypeStatus =  project.TypeStatus,
                ContributionTotal = project.ContributionTotal,
                Paliers = project.Paliers.Select(x => x.toDalPallier())


            };

        }

        public static DALM.CreateProjectModel  toDALCreateProject(this BLLM.CreateProjectModel project)
        {
            return new DALM.CreateProjectModel
            {
                Id = project.Id,
                Titre = project.Titre,
                Description = project.Description,
                Objectif = project.Objectif,
                CompteBQ = project.CompteBQ,
                DateDebut = project.DateDebut,
                DateFin = project.DateFin,
                IdUserOwner = project.IdUserOwner,
                IdStatus = project.IdStatus,
                Paliers= project.Paliers.Select(x=>x.toDalPallier()), 

            };

        }

    }
}
