using ADOLibrary;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories {
    public class UserRepo : IUserRepo {

        private string _connectionString;

        private Connection AdoLibCon;

        public UserRepo(IConfiguration c) {
            _connectionString = c.GetConnectionString("default");

            //Init ADO LIB
            AdoLibCon = new Connection(_connectionString);
        }

        private User Converter(SqlDataReader dr) {
            return new User() {
                //Id = (int) dr["Id"],
                Id = (int?)dr["Id"] ?? 404,
                Nickname = dr["Nickname"]?.ToString() ?? "",
                Email = dr["Email"]?.ToString() ?? ""
            };
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

        public User Update(User user) {
            throw new NotImplementedException();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers() {

            // Classic way to execute SQL request
            /*using (SqlConnection cnx = new SqlConnection(_connectionString)) {
                using (SqlCommand cmd = cnx.CreateCommand()) {

                    cmd.CommandText = "SELECT * FROM [Users]";

                    cnx.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read()) {
                        yield return Converter(r);
                    }
                }
            }*/

            // Use ADO LIB to request SQL
            
            Command cmd = new Command("SELECT * FROM [Users]");
            return AdoLibCon.ExecuteReader(cmd, Converter);
            
        }

        public User GetUserById(int id) {

            // Classic way to execute SQL request
            /*using (SqlConnection cnx = new SqlConnection(_connectionString)) {
                using (SqlCommand cmd = cnx.CreateCommand()) {

                    cmd.CommandText = "SELECT * FROM [Users] WHERE Id = @p0";
                    cmd.Parameters.AddWithValue("@p0", id);

                    cnx.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    r.Read();
                    return Converter(r);

                }
            }*/

            // Use ADO LIB to request SQL
            
            Command cmd = new Command("SELECT * FROM [Users] WHERE Id = @p0");
            cmd.AddParameter("@p0", id);
            return AdoLibCon.ExecuteReaderOnce(cmd, Converter);
        }

        public User Login(UserLogin user) {
            
            Command cmd = new Command("Login", true);
            cmd.AddParameter("@email", user.Email);
            cmd.AddParameter("@pwd", user.Password);
            return AdoLibCon.ExecuteReaderOnce(cmd,Converter);

        }
    }
}
