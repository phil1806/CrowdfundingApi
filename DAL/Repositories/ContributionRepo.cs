using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories
{
    internal class ContributionRepo : IContributionRepo
    {
        private string _connectionString;

        public ContributionRepo(IConfiguration c)
        {
            _connectionString = c.GetConnectionString("default");
        }
        public Contribution Add(ContributionModelDAL contribution)
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
                   
                }
            }
        }

        public IEnumerable<Contribution> GetAll()
        {
            
        }

        public Contribution GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
