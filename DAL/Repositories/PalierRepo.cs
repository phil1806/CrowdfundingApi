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
    public class PalierRepo : IPalierRepo
    {
        //Prop's
        private readonly string _connectionString;

        //Constructeurs
        public PalierRepo(IConfiguration Iconfig)
        {
            _connectionString = Iconfig.GetConnectionString("default");
        }


        //Mappers 
        private Paliers Convert(IDataReader reader)
        {
            return new Paliers
            {
                Id =(int) reader["Id"],
                Title =(string) reader["Title"],
                Montant =(decimal) reader["Montant"],
                Description= (string)reader["Description"],
                IdProject = (int)reader["IdProject"]

            };
        }


        public int CreatePalier(Paliers palier)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "InsertPalier";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Title", palier.Title);
                    cmd.Parameters.AddWithValue("Montant", palier.Montant);
                    cmd.Parameters.AddWithValue("Description", palier.Description);
                    cmd.Parameters.AddWithValue("idProject", palier.IdProject);
                    cnx.Open();

                    return (int)cmd.ExecuteScalar();
                }

            }
          
        }

        public bool DeletePalier(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = @$"DELETE FROM Paliers
                                          WHERE Id =@id";

                    cmd.Parameters.AddWithValue("id", id);
                    cnx.Open();

                    return cmd.ExecuteNonQuery() > 0;
                   
                }
            }
        }

        public IEnumerable<Paliers> GetAllPaliers()
        {
            using (SqlConnection  cnx  = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd =  cnx.CreateCommand())
                {
                    cmd.CommandText = @$"SELECT * FROM Paliers";
                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Convert(reader);
                        }
                    }
                }
            }
        }

        public Paliers GetPalierById(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = @$"SELECT * FROM Paliers WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert(reader);
                        }
                        throw new Exception("Palier inexistant...");
                    }

                }
            }
        }

        public bool UpdatePalier(int id, Paliers P)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd =  cnx.CreateCommand())
                {
                    cmd.CommandText = @$"UPDATE Paliers SET 
                                        Title = @Title,
                                        Montant = @Montant,
                                        Description = @Description,
                                        IdProject = @IdProject
                                        WHERE Id =@Id;";

                    cmd.Parameters.AddWithValue("Id",id);
                    cmd.Parameters.AddWithValue("Title", P.Title);
                    cmd.Parameters.AddWithValue("Montant", P.Montant);
                    cmd.Parameters.AddWithValue("Description", P.Description);
                    cmd.Parameters.AddWithValue("IdProject", P.IdProject);

                    cnx.Open();

                   return cmd.ExecuteNonQuery() > 0;

                }

            }

           
        }
    }
}
