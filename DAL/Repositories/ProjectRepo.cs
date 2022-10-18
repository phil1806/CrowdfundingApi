using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProjectRepo : IProject
    {
        //Prop
        private readonly string _connectionString;


        //Consktructeur
        public ProjectRepo(IConfiguration Iconfig)
        {
            _connectionString = Iconfig.GetConnectionString("default");
        }


        //Mapper de base de données vers DAL
        private Project Converter(IDataReader reader)
        {
            return new Project
            {
                Id = (int)reader["Id"],
                Titre = (string)reader["Titre"],
                Description = (string)reader["Description"],
                Objectif = (string)reader["Objectif"],
                CompteBQ =(string)reader["CompteBQ"],
                DateDebut = (DateTime)reader["DateDubut"],
                DateFin = (DateTime)reader["DateFin"],
                IdUserOwner = (int)reader["IdUserOwner"],
                IdStatus = (int)reader["IdStatus"]
            };
        }
        public bool CreateProject()
        {
            throw new NotImplementedException();
        }

        public bool DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "GetProjectsByFalg";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    /*
                        -- Attention en fonction du paramètre on definit le type de Projets de l'on recupère
                              -- Paramètre  0 pour => tous les projets validés et non validés
                              -- Paramètre  1 uniquement pour les projets en "Accepter " ou "EnCours"
                     */
                    cmd.Parameters.AddWithValue("Flag", 0); 
                    cnx.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Converter(reader);
                        }
                    }
                }
            }
        }

        public Project GetProjectById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetValidProjects()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProject(int id)
        {
            throw new NotImplementedException();
        }

        public bool ValidProject(int id)
        {
            throw new NotImplementedException();
        }
    }
}
