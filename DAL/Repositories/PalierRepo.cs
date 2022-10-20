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


        public bool CreatePalier(Paliers Paliers)
        {
            throw new NotImplementedException();
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

        public bool UpdatePalier(int id)
        {
            throw new NotImplementedException();
        }
    }
}
