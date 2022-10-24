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
    public class ProjectRepo : IProjectRepo
    {
        //Prop
        private readonly string _connectionString;
        private readonly IPalierRepo palierService;


        //Consktructeur
        public ProjectRepo(IConfiguration Iconfig, IPalierRepo _palierService)
        {
            _connectionString = Iconfig.GetConnectionString("default");
            palierService = _palierService;
        }


        //Mapper de base de données vers DAL
        private Project Converter(IDataReader reader)
        {
            return new Project
            {
                Id = (int)reader["Id"],
                Titre = (string)reader["Titre"],
                Description = (string)reader["Description"],
                Objectif = (decimal)(reader["Objectif"]),
                CompteBQ = (string?)reader["CompteBQ"] ?? "",
                DateDebut = DateTime.Parse(reader["DateDebut"].ToString()),
                DateFin = DateTime.Parse(reader["DateFin"].ToString()),
                TypeStatus = (string)reader["TypeStatus"],
                ContributionTotal = (decimal?)reader["ContributionTotal"] ?? 0,

            };
        }

        private Project ConverterGetProjectById(IDataReader reader)
        {
            return new Project
            {
                Id = (int)reader["Id"],
                Titre = (string)reader["Titre"],
                Description = (string)reader["Description"],
                Objectif = (decimal)(reader["Objectif"]),
                CompteBQ = (string?)reader["CompteBQ"] ?? "",
                DateDebut = DateTime.Parse(reader["DateDebut"].ToString()),
                DateFin = DateTime.Parse(reader["DateFin"].ToString()),
                ContributionTotal = (decimal?)reader["ContributionTotal"] ?? 0,
                TypeStatus ="non existant"
            };
        }
        public int CreateProject(CreateProjectModel p)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                int idProject = 0;
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = @$"INSERT INTO Projects(Titre,Description , Objectif, CompteBQ,DateDebut,DateFin,IdUserOwner) 
                                         OUTPUT INSERTED.id VALUES (@Titre, @Description,@Objectif,@CompteBQ,@DateDebut,@DateFin,@IdUserOwner )";
                    cmd.Parameters.AddWithValue("Titre", p.Titre);
                    cmd.Parameters.AddWithValue("Description", p.Description) ;
                    cmd.Parameters.AddWithValue("Objectif", p.Objectif) ;
                    cmd.Parameters.AddWithValue("CompteBQ", p.CompteBQ);
                    cmd.Parameters.AddWithValue("DateDebut", p.DateDebut);
                    cmd.Parameters.AddWithValue("DateFin", p.DateFin);
                    cmd.Parameters.AddWithValue("IdUserOwner", p.IdUserOwner);
                    //cmd.Parameters.AddWithValue("IdStatus",p.IdStatus);

                    cnx.Open();
                    idProject =  (int)cmd.ExecuteScalar();
                  
                }

                int lastIdPalierWasInsert = 0;
                    foreach (Paliers palier in p.Paliers)
                    {

                        using (SqlCommand cmd = cnx.CreateCommand())
                    {

                        cmd.CommandText = "InsertPalier";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
           
                        cmd.Parameters.AddWithValue("Title", palier.Title);
                        cmd.Parameters.AddWithValue("Montant", palier.Montant);
                        cmd.Parameters.AddWithValue("Description", palier.Description);
                        cmd.Parameters.AddWithValue("idProject", idProject);

                        lastIdPalierWasInsert = (int)cmd.ExecuteScalar();

                    }

                }
                    return 1;
                

            }
        }

        public bool DeleteProject(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = $@"DELETE 
                                        FROM Projects
                                        WHERE Id =@Id";
                    cmd.Parameters.AddWithValue("Id", id);

                    cnx.Open();
                    return cmd.ExecuteNonQuery() > 0;

                }

            }
        }

        public IEnumerable<Project> GetAllProjects()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "GetProjectsByFlag";
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

        public Project  GetProjectById(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "GetProjetById";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdProject", id);
                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Project projet = ConverterGetProjectById(reader);
                            projet.Paliers = palierService.GetPalierByProjetId(projet.Id);
                            return projet;
                            //projet.Pal
                        }
                        throw new Exception("Project inexistant...");
                    }
                }
            }



        }


        /// <summary>
        /// elle revoit unique les projets validés ou ne cours
        /// </summary>
        /// <returns>IEnumerable de projet</returns>

        public IEnumerable<Project> GetValidProjects()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "GetProjectsByFlag";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    /*
                        -- Attention en fonction du paramètre on definit le type de Projets de l'on recupère
                              -- Paramètre  0 pour => tous les projets validés et non validés
                              -- Paramètre  1 uniquement pour les projets en "Accepter " ou "EnCours"
                     */
                    cmd.Parameters.AddWithValue("Flag", 1);
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

        public bool UpdateProject(int id , Project leProject) 
        { 
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = $@"UPDATE Projects SET
                                        Titre = @Titre,
                                        Description =@Description,
                                        Objectif =@Objectif,
                                        CompteBQ =@CompteBQ,
                                        DateDebut = @DateDebut,
                                        DateFin = @DateFin
                                        WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("Titre", leProject.Titre);
                    cmd.Parameters.AddWithValue("Description", leProject.Description);
                    cmd.Parameters.AddWithValue("Objectif", leProject.Objectif);
                    cmd.Parameters.AddWithValue("CompteBQ", leProject.CompteBQ);
                    cmd.Parameters.AddWithValue("DateDebut", leProject.DateDebut);
                    cmd.Parameters.AddWithValue("DateFin", leProject.DateFin);
                    cmd.Parameters.AddWithValue("Id", id);

                    cnx.Open();

                    cmd.ExecuteNonQuery() ;
                    return true;
                }
            }

           
        }

        /// <summary>
        /// Permet de valider par l'admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true ou false (reuissite ou echec )</returns>
        public bool ValidProject(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand  cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "validProject"; //Passer l'id du project
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProjectParams", id);
                    cnx.Open();

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }
    }
}
