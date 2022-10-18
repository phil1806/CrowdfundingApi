using ADOLibrary;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
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

            if (dr["Id"] == null) throw new Exception("No User found");
            return new User() {
                Id = (int) dr["Id"],
                Nickname = dr["Nickname"]?.ToString() ?? "",
                Email = dr["Email"]?.ToString() ?? "",
                BirtDay = dr["Birthdate"] == null ? new DateTime() : DateTime.Parse(dr["Birthdate"].ToString())// (DateTime) dr["Birthdate"]

            };
        }

        public User Register(UserRegister user) {

            Command cmd = new Command("RegisterUser",true);
           
            cmd.AddParameter("@pdw", user.Password);
            cmd.AddParameter("@birthdate", user.BirtDay);
            cmd.AddParameter("@email", user.Email);
            cmd.AddParameter("@nickname", user.Nickname);
            cmd.AddParameter("@role", user.Role);
            return AdoLibCon.ExecuteReaderOnce(cmd, Converter);
            /*using (SqlConnection cnx = new SqlConnection(_connectionString)) {
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
                        Nickname = r["NickName"]?.ToString() ?? "",
                        Email = r["Email"]?.ToString() ?? "",

                    };

                }
            }*/
        }

        public void Update(User user) {
            Command cmd = new Command("UPDATE [Users] SET NickName = @nickname,Email = @email WHERE Id = @id");
            cmd.AddParameter("@nickname", user.Nickname);
            cmd.AddParameter("@id", user.Id);
            cmd.AddParameter("@email", user.Email);
            AdoLibCon.ExecuteScalar(cmd);
        }

        public void Delete(int id) {
            Command cmd = new Command("DELETE FROM [Users] WHERE Id = @p0");
            cmd.AddParameter("@p0", id);
            AdoLibCon.ExecuteScalar(cmd);
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
            try {
                return AdoLibCon.ExecuteReaderOnce(cmd, Converter);
            } catch (Exception e) {
                throw new Exception($"No {id} user");
            }
        }

        public User Login(UserLogin user) {


            Command cmd = new Command("Login", true);
            cmd.AddParameter("@email", user.Email);
            cmd.AddParameter("@pwd", user.Password);
            try {
                return AdoLibCon.ExecuteReaderOnce(cmd, Converter);
            } catch (Exception ex) {
                throw new Exception("invalid login - password");
            }

            /*
            using (SqlConnection cnx = new SqlConnection(_connectionString)) {
                using (SqlCommand cmd = cnx.CreateCommand()) {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Login";
                    cmd.Parameters.AddWithValue("@pwd", user.Password);
                    cmd.Parameters.AddWithValue("@email", user.Email);

                    cnx.Open();
                    SqlDataReader r = cmd.ExecuteReader();
                    r.Read();
                    return new User() {
                        Id = (int?)r?["Id"] ?? 404,
                        Nickname = r?["NickName"]?.ToString() ?? "",
                        Email = r?["Email"]?.ToString() ?? ""
                    };

                }
            }*/

        }
    }
}
