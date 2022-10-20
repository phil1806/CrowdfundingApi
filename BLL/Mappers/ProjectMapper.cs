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
                Paliers= project.Paliers.Select(x=>x.toDALCreateProject()), 

            };

        }


        //Mapper  des paliers
        public static DALM.Paliers toDALCreateProject(this BLLM.Paliers paliers)
        {
            return new DALM.Paliers
            {
                Id = paliers.Id,
                Title = paliers.Title,
                Montant = paliers.Montant,
                Description = paliers.Description,
                IdProject = paliers.IdProject
               
            };

        }



    }
}
