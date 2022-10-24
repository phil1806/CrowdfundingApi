using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories
{
    public class ContributionRepo : IContributionRepo
    {
        private string _connectionString;

        public ContributionRepo(IConfiguration c)
        {
            _connectionString = c.GetConnectionString("default");
        }

        protected ContributionModelDAL Converter(IDataReader reader)
        {
            return new ContributionModelDAL
            {
                Id = (int)reader["Id"],
                Montant = (decimal)reader["Montant"],
                IdUser = (int)reader["IdUserContributeur"],
                IdProject = (int)reader["IdProject"]
            };
        }
        public void Add(ContributionModelDAL contribution)
        {
            using (SqlConnection cnx =  new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "INSERT INTO Contributions (Montant, IdUser, IdProject) VALUES (@Montant, @IdUser, @IdProject)";
                    cmd.Parameters.AddWithValue("@Montant", contribution.Montant);
                    cmd.Parameters.AddWithValue("@IdUser", contribution.IdUser);
                    cmd.Parameters.AddWithValue("@IdProject", contribution.IdProject);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                   
                }
            }
        }

        public IEnumerable<ContributionModelDAL> GetAll()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Contributions";
                    cnx.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            yield return Converter(reader);
                        }
                    }
                }
            }
        }

        public ContributionModelDAL GetById(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Contributions WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", id);
                    cnx.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Converter(reader);
                        }
                        throw new Exception();
                    }
                }
            }
        }
    }
}
