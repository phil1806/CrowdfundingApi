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

        public User Register(UserRegister user) {
            using (SqlConnection cnx = new SqlConnection(_connectionString)) {
                using (SqlCommand cmd = cnx.CreateCommand()) {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "RegisterUser";
                    cmd.Parameters.AddWithValue("@pdw", user.Password);
                    cmd.Parameters.AddWithValue("@birthdate", user.BirtDay);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@nickname", user.Nickname);
                    cmd.Parameters.AddWithValue("@role", user.Role);

                    cnx.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    r.Read();
                    return new User() {
                        Id = (int)r["Id"],
                        Nickname = r["NickName"]?.ToString() ?? ""
                    };

                }
            }
        }

    }
}
