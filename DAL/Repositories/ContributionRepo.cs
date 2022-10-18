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
                UserId = (int)reader["UserId"],
                ProjectId = (int)reader["ProjectId"]

            };
        }
        public void Add(ContributionModelDAL contribution)
        {
            using (SqlConnection cnx =  new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddContribution";
                    cmd.Parameters.AddWithValue("@Montant", contribution.Montant);
                    cmd.Parameters.AddWithValue("@UserId", contribution.UserId);
                    cmd.Parameters.AddWithValue("@ProjectId", contribution.ProjectId);
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
                    cmd.CommandText = "SELECT * FROM Contributitons";
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
