using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories {
    public class UserRepo : IUserRepo {

        private string _connectionString;

        public UserRepo(IConfiguration c) {
            _connectionString = c.GetConnectionString("default");
        }

        public void Register(UserRegister user) {
            using (SqlConnection cnx = new SqlConnection(_connectionString)) {
                using (SqlCommand cmd = cnx.CreateCommand()) {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "RegisterUser";
                    cnx.Open();
                    cmd.ExecuteScalar();
                    //throw new NotImplementedException(user.ToString());
                    //TODO use procedure registerUser
                    /*cmd.CommandText = @$"  ";
                    cmd.Parameters.AddWithValue("p1", m.Title);
                    cmd.Parameters.AddWithValue("p2", m.Synopsis);
                    cmd.Parameters.AddWithValue("p3", m.ReleaseYear);
                    cmd.Parameters.AddWithValue("p4", m.PEGI);*/

                }
            }
        }

    }
}
